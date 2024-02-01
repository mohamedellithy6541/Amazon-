using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amozon.Core.Entites.Order_Aggregate
{
    public class Order:BaseEntity
    {
        public Order()
        {

        }

        public Order(string buyerEmail, OrderStatus status, Address shappingAddress, DeliveryMethod deliveryMethod, ICollection<OrderItems> items, decimal subTotal)
        {
            BuyerEmail = buyerEmail;
            this.status = status;
            ShappingAddress = shappingAddress;
            this.deliveryMethod = deliveryMethod;
            Items = items;
            SubTotal = subTotal;
        }

        public Order(string buyeeEmail, Address shippingAddress, DeliveryMethod deliverymethod, List<OrderItems> orderitem, decimal subtotal)
        {
            BuyeeEmail = buyeeEmail;
            ShippingAddress = shippingAddress;
            deliveryMethod = deliverymethod;
            Orderitem = orderitem;
            SubTotal = subtotal;
        }

        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public OrderStatus status { get; set; } = OrderStatus.Pending;
        public Address ShappingAddress { get; set; }
        public DeliveryMethod deliveryMethod { get; set; }
        public ICollection<OrderItems> Items { get; set; } = new HashSet<OrderItems>();
        public decimal SubTotal { get; set; }
        //public decimal Total => SubTotal+deliveryMethod.Cost //Drived attribute

        public decimal GetOrder()
       => SubTotal + deliveryMethod.Cost;

        public string PaymentIntentId { get; set; }
        public string BuyeeEmail { get; }
        public Address ShippingAddress { get; }
        public List<OrderItems> Orderitem { get; }
    }
}
