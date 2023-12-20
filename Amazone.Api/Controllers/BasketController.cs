using Amazone.Api.Dto;
using Amazone.Api.Errors;
using Amozon.Core.Entites;
using Amozon.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amazone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseSApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<Amozon.Core.Entites.CustomerBasket>> GetBasket(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            return basket ?? new Amozon.Core.Entites.CustomerBasket(id);

        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> updateBasket(CustomerBasketDto basket)
        {
            var basketdto = _mapper.Map<CustomerBasketDto,CustomerBasket>(basket);
            var createorUpdate = await _basketRepository.UpdateBasketAsync(basketdto);
            if (createorUpdate is null) return BadRequest(new ApiResponse(400));
            return createorUpdate;
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> deletbasket(string basketId)
        {
            return await _basketRepository.DeletBasketAsync(basketId);
        }
    }
}
