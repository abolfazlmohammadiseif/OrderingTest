using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Services.Orders.Dto
{
    public class UpdateStatusDto
    {
        public int OrderId  { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
