using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.WebAPI.Models
{
    public class ShopContext: DbContext
    {
       public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {

        }

        public DbSet<Item> ItemList { get; set; }
    }
}
