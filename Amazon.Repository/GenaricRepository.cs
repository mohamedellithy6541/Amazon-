using Amazon.Repository.Context;
using Amozon.Core;
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
    public class GenaricRepository<T> : IGenaricRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;


        public GenaricRepository(StoreContext context)
        {
            _context = context;
        }
       
        public async Task Add(T t)
        => await _context.Set<T>().AddAsync(t);

        public void Delete(T Entity)
         => _context.Set<T>().Remove(Entity);

        public async Task<IReadOnlyList<T>> GetAllAsync()

          => await _context.Set<T>().ToListAsync();
        

        public async Task<T> GetByIdAsync(int id)
           => await _context.Set<T>().FindAsync(id);

        public async Task<IReadOnlyList<T>> GetAllwithspecAcync(ISpecification<T> spec)
         =>  await ApplySpecification(spec).ToListAsync();
        
        public async Task<T> GetByIdWithspecAsync(ISpecification<T> spec)
          => await ApplySpecification(spec).FirstOrDefaultAsync();
      
        public void Update(T Entity)
        => _context.Set<T>().Update(Entity);
      
        
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        => SpecicationEvalutor<T>.GETQUARY(_context.Set<T>(), spec);



    }
}
