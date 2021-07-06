using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBridge.WebAPI.Business.Contracts;
using ShopBridge.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.WebAPI.Business.Managers
{
    public class ItemManager: IItemManager
    {

        private readonly ShopContext _context;

        public ItemManager(ShopContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Item>>> GetItemList(Item objItem)
        {
            return await _context.ItemList
                .Where(x=>x.IsDeleted==false)
                .Skip((objItem.PageNo-1)*objItem.PageSize)
                .Take(objItem.PageSize)
                .ToListAsync()
                ;
        }

        
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.ItemList.FindAsync(id);

            

            return item;
        }

        public async Task<ActionResult<Item>> PutItem(int id, Item item)
        {
            
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return item;
        }

        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            _context.ItemList.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                var item = await _context.ItemList.FindAsync(id);
                item.IsDeleted = true;


                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(" Error while deleting Item: "+ex.Message);
            }
          
            return null;
          
        }

        private bool ItemExists(int id)
        {
            return _context.ItemList.Any(e => e.Id == id);
        }
    }

}

