using Amozon.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amozon.Core.Interfaces.Specifaction
{
    public class ProductwithBrandandTypeSpecifications : BaseSpecification<Products>
    {
        public ProductwithBrandandTypeSpecifications(ProductSpecificationPram specPram) :base
            (p=> (!specPram.BranId.HasValue|| p.ProductBrandId== specPram.BranId.Value) &&
            (!specPram.TypeId.HasValue|| p.ProductTypeId == specPram.TypeId.Value))
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductTypes);
           
            if (!string.IsNullOrEmpty(specPram.sort))
            {
                switch (specPram.sort) 
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                        case "priceDesc":
                        AddOrderByDesending(p => p.Price);
                        break;
                        default :
                        AddOrderBy(p=> p.Name);
                        break;

                }
            }
            ApplyPagenation(specPram.PageSize * (specPram.PageIndex - 1) ,specPram.PageSize);
        }



        public ProductwithBrandandTypeSpecifications(int id):base(p=>p.Id==id) 
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductTypes);
        }
    }
}

