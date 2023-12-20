using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amozon.Api.Dto
{
    public class ProtuctToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set;}
        public int ProductBrandId { get; set; }
        public string ProductBrand { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductTypes { get; set; }
    }
}
