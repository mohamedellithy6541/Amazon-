using Amozon.Core.Entites;
using Amozon.Core.Interfaces.Specifaction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Repository
{
    public static class SpecicationEvalutor<T> where T : BaseEntity
    {
        public static IQueryable<T> GETQUARY(IQueryable<T> InputQuary, ISpecification<T> spec)
        {
            var quary = InputQuary; //_dbciontext.products
            if (spec.Criteria is not null) //where(p=>p.id==1)
                quary = quary.Where(spec.Criteria); //_dbciontext.products.where(p=>p.id==1)
         
            if (spec.IsPaginationEnable)
            quary=quary.Skip(spec.Skip).Take(spec.Take);

            if (spec.OrderBy is not null)
              quary = quary.OrderBy(spec.OrderBy); 
           
            if (spec.OrderDesending is not null)
             quary = quary.OrderByDescending(spec.OrderDesending);

                quary = spec.Includes.Aggregate(quary, (crrentquary, includes) => crrentquary.Include(includes));

            return quary;

        }



    }





}
