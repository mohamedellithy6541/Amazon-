using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amozon.Core.Entites.Order_Aggregate
{
    public class DeliveryMethod:BaseEntity
    {
        public DeliveryMethod()
        {
        }

        public DeliveryMethod(string shortNmae, string description, decimal cost, string deliveryTime)
        {
            ShortName = shortNmae;
            Description = description;
            Cost = cost;
            DeliveryTime = deliveryTime;
        }

        public string ShortName { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string DeliveryTime { get; set; }
    }
}
