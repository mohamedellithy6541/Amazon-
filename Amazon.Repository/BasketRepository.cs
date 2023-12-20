using Amozon.Core.Entites;
using Amozon.Core.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Amazon.Repository
{
    public class BasketRepository : IBasketRepository
    {
        public readonly IDatabase _database;

        public BasketRepository(IConnectionMultiplexer redis )
        {
          _database= redis.GetDatabase();
        }

        public async Task<bool> DeletBasketAsync(string BasketId)
        {
            return await  _database.KeyDeleteAsync(BasketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string BasketId)
        {
           var basket= await _database.StringGetAsync(BasketId);
            return basket.IsNull ? null :JsonSerializer.Deserialize<CustomerBasket>(basket);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerBasket)
        {
            var updateorcreatbasket = await _database.StringSetAsync(customerBasket.Id,JsonSerializer.Serialize(customerBasket),TimeSpan.FromDays(1));
            if (updateorcreatbasket is false) return null;
            return await GetBasketAsync(customerBasket.Id);

        }
    }
}
