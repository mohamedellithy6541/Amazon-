namespace Amazone.Api.Dto
{
    public class CustomerBasketDto
    {
        public string Id { get; set; }
        public int? DelivaryMethod { get; set; }
        public decimal ShippingPrice { get; set; }
        public List<BasketItemDto> basketItems { get; set; }
    }
}
