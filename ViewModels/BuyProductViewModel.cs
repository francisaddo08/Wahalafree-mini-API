﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WahalafreeAPI.ViewModels
{
    public class BuyProductViewModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public int stockLevel { get; set; }
        public double price { get; set; }
    }
}
