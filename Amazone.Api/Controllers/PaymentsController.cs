using Amazone.Api.Dto;
using Amazone.Api.Errors;
using Amozon.Core.Entites;
using Amozon.Core.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amazone.Api.Controllers
{

    public class PaymentsController : BaseSApiController
    {
        private readonly IPaymentServices _paymentServices;
        private readonly IMapper _mapper;

        public PaymentsController(IPaymentServices paymentServices)
        {
            _paymentServices = paymentServices;

        }

        [ProducesResponseType(typeof(Dto.CustomerBasketDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<Amozon.Core.Entites.CustomerBasket>> CreatOrUpdatPaymetEntent(string basketId)
        {
            var basket = await _paymentServices.CreatOrUpdatePaymentEntent(basketId);
            if (basket is null) return BadRequest(new ApiResponse(400, "aproplem with the Basket"));
            return Ok(basket);
        }
    }
}
