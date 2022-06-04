using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int? CustomerId { get; set; }
        public int? PaymentMethodId { get; set; }
        public OrderStatus OrderStatusId { get; set; }
        public string? Description { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public Order(DateTime orderDate, int? customerId, int? paymentMethodId, OrderStatus orderStatusId, string? description, ICollection<OrderItem> orderItems)
        {
            OrderDate = orderDate;
            CustomerId = customerId;
            PaymentMethodId = paymentMethodId;
            OrderStatusId = orderStatusId;
            Description = description;
            OrderItems = orderItems;
        }
    }
}
