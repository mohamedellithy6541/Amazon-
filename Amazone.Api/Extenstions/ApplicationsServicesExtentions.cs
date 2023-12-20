using Amazon.Repository;
using Amazone.Api.Helper;
using Amozon.Core;
using Amozon.Core.Interfaces;
using Amozon.Core.Interfaces.Services;
using Amzone.servecies.services;
using Amzone.servecies.services.payment;
using AutoMapper;

namespace Amazone.Api.Extenstions
{
    public  static class ApplicationsServicesExtentions
    {
        public static IServiceCollection AddApplicationServices( this IServiceCollection services)
        {
            services.AddScoped<IPaymentServices ,PaymentServices>();
            services.AddScoped<IUnitOfWork, UnitOfwork>();
            services.AddScoped<IOrderServices,OrderServices>();
            services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));
            //services.AddScoped(typeof(IGenaricRepository<>), typeof(GenaricRepository<>));
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
