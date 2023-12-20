using Amozon.Api.Dto;
using Amozon.Core.Entites;
using AutoMapper;
using AutoMapper.Execution;

namespace Amazone.Api.Helper
{
    public class ProductPictureUrlResolver : IValueResolver<Products, ProtuctToReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Products source, ProtuctToReturnDto destination, string destMember, ResolutionContext context)
        {
           
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{_configuration["apiBaseUrl"]}{source.PictureUrl}";
            return string.Empty ;
           
        }
    }
}
