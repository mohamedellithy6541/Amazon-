using Amazone.Api.Errors;
using Amazone.Api.Helper;
using Amozon.Api.Dto;
using Amozon.Core;
using Amozon.Core.Entites;
using Amozon.Core.Interfaces;
using Amozon.Core.Interfaces.Specifaction;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amazone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]// Just For Documentation
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]// Just For Documentation
    public class ProductController : BaseSApiController
    {
        //private readonly IGenaricRepository<Products> _productRepo;
        //private readonly IGenaricRepository<ProductType> _productType;
        //private readonly IGenaricRepository<ProductBrand> _productBrand;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;   //    _productRepo = ProductRepo;
                                        //    _productType = productType;
                                        //    _productBrand = ProductBrand;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProtuctToReturnDto>>>GetAllProducts( [FromQuery]ProductSpecificationPram specPram)
        {
            var spec = new ProductwithBrandandTypeSpecifications(specPram);
            var products = await _unitOfWork.repository<Products>().GetAllwithspecAcync(spec);
            var productmap = _mapper.Map<IReadOnlyList<Products>, IReadOnlyList<ProtuctToReturnDto>>(products);
            return Ok(productmap);
        }

        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult> Getbyid(int id)
        {
            var spec = new ProductwithBrandandTypeSpecifications(id);
            var product = await _unitOfWork.repository<Products>().GetByIdWithspecAsync(spec);
            if (product is null) return NotFound(new ApiResponse(404));
            var productmap = _mapper.Map<Products, ProtuctToReturnDto>(product);
            return Ok(productmap);
        }
        [HttpGet("Brand")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetallBrands()
        {
            var brands = await _unitOfWork.repository<ProductBrand>().GetAllAsync();
            return Ok(brands);
        }
        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetallTypes()
        {
            var Types = await _unitOfWork.repository<ProductType>().GetAllAsync();
            return Ok(Types);
        }
       
    }
}

