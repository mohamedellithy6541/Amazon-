using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amozon.Core.Entites
{
    public class CustomerBasket
    {
        public string Id { get; set; }
        public List< BasketItem> items{ get; set;}=new List< BasketItem>();
        public string PaymenetId { get; set; }
        public string ClintSecerit { get; set; }
        public int? DeliveyMethodId { get; set; }
        public decimal ShippingCost { get; set; }

        public CustomerBasket(string id)
        {
            Id = id;
        }

    }
}
