using Amozon.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amozon.Core.Interfaces.Specifaction
{
    public interface ISpecification<T>where T : BaseEntity
    {
        public Expression<Func<T,bool>> Criteria { get; set; } //where(p=>p.id)
        public List<Expression<Func<T, object>>> Includes { get; set; } //include(p=>p.productBrand).include(p=>p.productType)
        public Expression<Func<T, object>> OrderBy { get; set; } 
        public Expression<Func<T, object>> OrderDesending { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginationEnable { get; set; }

    }
}
 