using Amozon.Core.Entites.Order_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amozon.Core.Interfaces
{
    public interface IOrderServices
    {
        Task< Order>CreatOrderAsync(string buyeeEmail, string BasketId, int DeliverMethodId, Address shippingAddress);
        Task<IReadOnlyList<Order>> GetOrderAsync(string BuyerEmail);
        Task<Order?> GetOrderByIdAsync(string buyeremail,int OrderId);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryService();
    }
}
