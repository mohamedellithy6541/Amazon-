﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amozon.Core.Entites
{
    public class BasketItem:BaseEntity
    {
        public string productName { get; set; }
       public int? Quantity { get; set; }
        public decimal Cost { get; set; }
        public string PictureUrl { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
    }
}
