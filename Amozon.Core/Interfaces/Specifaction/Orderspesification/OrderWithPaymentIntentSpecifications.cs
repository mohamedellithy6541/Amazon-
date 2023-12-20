using Amozon.Core.Entites.Order_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amozon.Core.Interfaces.Specifaction.Orderspesification
{
    public class OrderWithPaymentIntentSpecifications:BaseSpecification<Order>
    {
        public OrderWithPaymentIntentSpecifications(string PaymentIntentId)
            :base(o=>o.PaymentIntentId==PaymentIntentId)
        {
            
        }
    }
}
