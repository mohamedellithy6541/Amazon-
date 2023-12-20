using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Amozon.Core.Entites.Order_Aggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value = "pending")]
        Pending,
        [EnumMember(Value = "PaymentRecived")]
        PaymentRecived,
        [EnumMember(Value = "PaymentFailed")]
        PaymentFailed
    }
}
