using Amazone.Api.Dto;
using Amozon.Api.Dto;
using Amozon.Core.Entites;
using Amozon.Core.Entites.Order_Aggregate;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazone.Api.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Products, ProtuctToReturnDto>()
                .ForMember(d => d.ProductBrand, s => s.MapFrom(o => o.ProductBrand.Name))
                .ForMember(d => d.ProductTypes, s => s.MapFrom(o => o.ProductTypes.Name))
                .ForMember(d=>d.PictureUrl,s=>s.MapFrom<ProductPictureUrlResolver>());
            CreateMap<AddressDto,Address>().ReverseMap();

        }
    }
}
