using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.WebAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public long Price { get; set; }
        public string Description { get; set; }

        public  int PageNo { get; set; }
        public int PageSize { get; set; }

        public bool IsDeleted { get; set; }
    }
}
