using Amozon.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amozon.Core.Interfaces.Services
{
    public interface IPaymentServices
    {
        Task<CustomerBasket> CreatOrUpdatePaymentEntent(string BasktId);
    }
}
