using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBridge.WebAPI.Business.Contracts;
using ShopBridge.WebAPI.Models;

namespace ShopBridge.WebAPI.Controllers
{
    [Route("api/Items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ShopContext _context;
        private readonly IItemManager _itemManager;

        public ItemsController(ShopContext context, IItemManager itemManager)
        {
            _context = context;
            this._itemManager = itemManager;
        }


        //lists items from inventory
        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemList(Item item)
        {
            return await this._itemManager.GetItemList(item);
           
        }


        //get signle item from id
        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            return await this._itemManager.GetItem(id);
        }


        //update item from inventory
        [HttpPut("{id}")]
        public async Task<ActionResult<Item>> PutItem(int id, Item item)
        {
            return await this._itemManager.PutItem(id,item);
        }

        //add new item to inventory 
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            return await this._itemManager.PostItem(item);
        }


        //deleting item from inventory
        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            return await this._itemManager.DeleteItem(id);
        }

    }
}
