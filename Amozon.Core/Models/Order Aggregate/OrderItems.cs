using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amozon.Core.Entites.Order_Aggregate
{
    public class OrderItems:BaseEntity
    {
        public OrderItems()
        {
            
        }

        public OrderItems(ProductItemOrder product, decimal Price, int quantity)
        {
            Product = product;
            Price = Price;
            Quantity = quantity;
        }

        public ProductItemOrder Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }


    }
}
