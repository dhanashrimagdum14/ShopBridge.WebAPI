using Microsoft.AspNetCore.Mvc;
using ShopBridge.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.WebAPI.Business.Contracts
{
   public interface IItemManager
    {
        Task<ActionResult<IEnumerable<Item>>> GetItemList(Item item);
        Task<ActionResult<Item>> GetItem(int id);
        Task<ActionResult<Item>> PutItem(int id, Item item);
        Task<ActionResult<Item>> PostItem(Item item);
        Task<IActionResult> DeleteItem(int id);
    }
}
