using Amozon.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amozon.Core.Interfaces.Specifaction
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>>OrderDesending { get; set; }
        public int Skip { get; set; }
        public int Take { get ; set; }
        public bool IsPaginationEnable { get; set; }
        public BaseSpecification(int?BrandId,int?Id)
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> Criteraexpression)
        {
            Criteria = Criteraexpression;
        }
        public void AddOrderBy(Expression<Func<T,object>> OrderbyExpression) 
        {
            OrderBy = OrderbyExpression;
        }
        public void AddOrderByDesending(Expression<Func<T,object>> OrderbyDescExpression) 
        {
            OrderDesending = OrderbyDescExpression;
        }
        public void ApplyPagenation(int skip,int take) 
        {
            IsPaginationEnable = true;
            Skip= skip;
            Take= take;
        }
    }
}
