using Amozon.Core;
using Amozon.Core.Entites;
using Amozon.Core.Entites.Order_Aggregate;
using Amozon.Core.Interfaces;
using Amozon.Core.Interfaces.Services;
using Amozon.Core.Interfaces.Specifaction;
using Amozon.Core.Interfaces.Specifaction.Orderspesification;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amzone.servecies.services
{
    public class OrderServices : IOrderServices
    {
        private readonly IBasketRepository _basketRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentServices _paymentServices;

        public OrderServices(IBasketRepository basketRepository, IUnitOfWork unitOfWork ,IPaymentServices paymentServices)
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
            _paymentServices = paymentServices;
        }


        public async Task<Order?> CreatOrderAsync(string buyeeEmail, string BasketId, int DeliverMethodId, Address shippingAddress)
        {
            var basket = await _basketRepository.GetBasketAsync(BasketId);
            var orderitem = new List<OrderItems>();
            if (basket?.items.Count > 0)
            {
                foreach (var item in orderitem)
                {
                    var product = await _unitOfWork.repository<Products>()?.GetByIdAsync(item.Id);
                    if (product is not null)
                    {
                        var productitemOrder = new ProductItemOrder(product.Id, product.Name, product.PictureUrl);
                        var orderItems = new OrderItems(productitemOrder, product.Price, item.Quantity);
                        orderitem.Add(orderItems);
                    }
                }
            }
            var subtotal = orderitem.Sum(item => item.Price * item.Quantity);
          
             var deliverymethod = await _unitOfWork.repository<DeliveryMethod>().GetByIdAsync(DeliverMethodId);
            var spec = new OrderWithPaymentIntentSpecifications(basket.PaymenetId );
            var existingOrder = await _unitOfWork.repository<Order>().GetByIdWithspecAsync(spec);
            if (existingOrder is not null)
            {
                _unitOfWork.repository<Order>().Delete(existingOrder);
                await _paymentServices.CreatOrUpdatePaymentEntent(basket.Id); 
            }
            var orders = new Order(buyeeEmail, shippingAddress, deliverymethod, orderitem, subtotal);
            await _unitOfWork.repository<Order>().Add(orders);
            return orders;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryService()
        {
            var Deliverymethod = await _unitOfWork.repository<DeliveryMethod>().GetAllAsync();
            return Deliverymethod;
        }

        public async Task<IReadOnlyList<Order>> GetOrderAsync(string BuyerEmail)
        {
            var spec = new OrderSpecification(BuyerEmail);
            var orders = await _unitOfWork.repository<Order>().GetAllwithspecAcync(spec);
            return orders;
        }

        public async Task<Order> GetOrderByIdAsync(string buyeremail, int OrderId)
        {
            var spec = new OrderSpecification(buyeremail, OrderId);
            var order = await _unitOfWork.repository<Order>().GetByIdWithspecAsync(spec);
            if (order is null) return null;
            return order;
        }
    }
}
