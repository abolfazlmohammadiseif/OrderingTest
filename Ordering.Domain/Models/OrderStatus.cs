using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Models
{
    public enum OrderStatus
    {
        Submitted = 1,
        Paid = 2,
        Shipped = 3,
        Cancelled = 4,
    }
}
