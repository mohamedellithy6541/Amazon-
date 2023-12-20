using Amozon.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amozon.Core.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetBasketAsync(string BasketId);
        Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket customerBasket);
        Task<bool>DeletBasketAsync(string BasketId);

      
    }
}
