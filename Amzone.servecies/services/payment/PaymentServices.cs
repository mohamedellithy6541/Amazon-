using Amozon.Core.Entites;
using Amozon.Core.Entites.Order_Aggregate;
using Amozon.Core.Interfaces;
using Amozon.Core.Interfaces.Services;
using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amzone.servecies.services.payment
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IConfiguration _configuration;
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentServices(IConfiguration configuration, IBasketRepository basketRepository, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<CustomerBasket> CreatOrUpdatePaymentEntent(string BasktId)
        {
            StripeConfiguration.ApiKey = _configuration["Stripsetting.SecriteKey "];
            var basket = await _basketRepository.GetBasketAsync(BasktId);
            if (basket is null) return null;
            var shippingprice = 0m;
            if (basket.DeliveyMethodId.HasValue)
            {
                var delivryMethod = await _unitOfWork.repository<DeliveryMethod>().GetByIdAsync(basket.DeliveyMethodId.Value);
                basket.ShippingCost = delivryMethod.Cost;
                shippingprice = basket.ShippingCost;
            }
            if (basket.items.Count > 0)
            {
                foreach (var item in basket.items)
                {
                    var product = await _unitOfWork.repository<Products>().GetByIdAsync(item.Id);
                    if (item.Cost != product.Price)
                        item.Cost = product.Price;
                }
            }
            var services = new PaymentIntentService();
            PaymentIntent intent;


            if (string.IsNullOrEmpty(basket.PaymenetId))
            {
                var option = new PaymentIntentCreateOptions()
                {
                    Amount = (long)basket.items.Sum(items => items.Cost * items.Quantity * 100) + (long)shippingprice * 100,
                    Currency = "Usd",
                    PaymentMethodTypes = new List<string>() { "card" }
                };
                intent = await services.CreateAsync(option);
                basket.PaymenetId = intent.Id;
                basket.ClintSecerit = intent.ClientSecret;
            }
            else
            {
                var option = new PaymentIntentUpdateOptions()
                {
                    Amount = (long)basket.items.Sum(items => items.Cost * items.Quantity * 100) + (long)shippingprice * 100,
                };
             
                await services.UpdateAsync(basket.PaymenetId,option);
            }
            return basket;
        }
    }
}
