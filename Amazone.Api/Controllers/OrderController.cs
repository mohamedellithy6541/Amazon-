using Amazone.Api.Dto;
using Amazone.Api.Errors;
using Amozon.Core.Entites.Order_Aggregate;
using Amozon.Core.Interfaces;
using Amozon.Core.Interfaces.Specifaction;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Amazone.Api.Controllers
{
    [Authorize]
    public class OrderController : BaseSApiController
    {
        private readonly IOrderServices _orderServices;
        private readonly IMapper _mapper;

        public OrderController(IOrderServices orderServices, IMapper mapper)
        {
            _orderServices = orderServices;
            _mapper = mapper;
        }
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<Order>> CreatOrder(OrderDto orderDto)
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var shippingaddress = _mapper.Map<AddressDto, Address>(orderDto.ShippingAddress);
            var order = await _orderServices.CreatOrderAsync(buyerEmail, orderDto.BasketId, orderDto.DeliverMethodId, shippingaddress);
            if (order is null) return BadRequest(new ApiResponse(400));
            return Ok(order);
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Order>>> GetOrderForUserAsync(string buyeremail)
        {
            var buyerEmail=User.FindFirstValue(ClaimTypes.Email);
            var order = await _orderServices.GetOrderAsync(buyeremail);
            return Ok(order);
        }
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]

        [HttpGet("Id")]
        public async Task<ActionResult> GetORderForUser(int id )
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var order = await _orderServices.GetOrderByIdAsync(email, id);
            if (order is null) return BadRequest(new ApiResponse(404));
            return Ok(order);
        }
        [HttpGet("deliverymethod")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethod() 
        {
            var deliverymethod = await _orderServices.GetDeliveryService();
            return Ok(deliverymethod);
        }
    }
}
