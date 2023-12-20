using Amozon.Core.Entites;
using Amozon.Core.Entites.Order_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amozon.Core.Interfaces
{
    public interface IUnitOfWork:IAsyncDisposable 
    {
        IGenaricRepository<T>? repository<T>() where T : BaseEntity;
        Task<int> Complete();
         
    }
}
