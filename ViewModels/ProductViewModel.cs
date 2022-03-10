using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WahalafreeAPI.ViewModels
{
    public class ProductViewModel
    {
        public Guid productId { get; set; }
        public string name { get; set; }
        public string imageUrl{ get; set;}
        public int stockLevel { get; set; }
        public double price { get; set; }
        public string justLanded { get; set; }
        public string productDesc { get; set; }
    }
}
