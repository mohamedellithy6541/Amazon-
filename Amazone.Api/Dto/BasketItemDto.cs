using System.ComponentModel.DataAnnotations;

namespace Amazone.Api.Dto
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        public List<CustomerBasketDto>itemes { get; set; }
        public string PaymenetEntentId { get; set; }
        public string ClintSeceret { get; set; }
        public int? DeliveyMethodId { get; set; }
        public decimal ShippingCost { get; set; }
    }
}
