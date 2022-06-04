using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Services.Orders.Dto
{
    public class OrderDto
    {
        public int? CustomerId { get; set; }
        public int? PaymentMethodId { get; set; }
        public OrderStatus OrderStatusId { get; set; }
        public string? Description { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }

    }
}
