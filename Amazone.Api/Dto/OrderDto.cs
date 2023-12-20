using Amozon.Core.Entites.Order_Aggregate;

namespace Amazone.Api.Dto
{
    public class OrderDto
    {
        public string BasketId { get; set; }
        public int DeliverMethodId { get; set;}

        public AddressDto  ShippingAddress { get; set;}

    }
}
