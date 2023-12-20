using Amozon.Core.Entites.Order_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amozon.Core.Interfaces.Specifaction.Orderspesification
{
    public class OrderSpecification : BaseSpecification<Order>
    {
        public OrderSpecification(string Email) : base(O => O.BuyeeEmail == Email)
        {
            Includes.Add(o => o.deliveryMethod);
            Includes.Add(o => o.Items);

        }
        public OrderSpecification(string Email, int orderid) : base(O => O.BuyeeEmail == Email && O.Id == orderid)
        {
            Includes.Add(o => o.deliveryMethod);
            Includes.Add(o => o.Items);

        }

    }
}
