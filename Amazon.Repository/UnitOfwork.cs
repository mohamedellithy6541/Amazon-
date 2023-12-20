using Amazon.Repository;
using Amazon.Repository.Context;
using Amozon.Core.Entites;
using Amozon.Core.Entites.Order_Aggregate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Amozon.Core.Interfaces
{
    public class UnitOfwork : IUnitOfWork
    {
        private readonly StoreContext _storeContext;
        private Hashtable  _repositories;
        public UnitOfwork(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<int> Complete()
         => await _storeContext.SaveChangesAsync();
        public ValueTask DisposeAsync()

         => _storeContext.DisposeAsync();

        public IGenaricRepository<T>? repository<T>() where T : BaseEntity
        {
         if(_repositories is null)
                _repositories = new Hashtable();
         var type=typeof(T).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoriery = new GenaricRepository<T>(_storeContext);
                _repositories.Add(type, repositoriery);
            }
            return _repositories[type] as IGenaricRepository<T>;
        }
    }
}
