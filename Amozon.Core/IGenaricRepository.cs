using Amozon.Core.Entites;
using Amozon.Core.Interfaces.Specifaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amozon.Core
{
    public interface IGenaricRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllwithspecAcync(ISpecification<T> spec);
        Task<T> GetByIdWithspecAsync(ISpecification<T> spec);
        Task Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);

    }
}
