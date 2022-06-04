using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Models
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrdersAsync(int Page, int PageSize);
        Task<Order> GetByIdAsync(int OrderId);
        Task<bool> DeleteAsync(Order Order);
        Task<bool> UpdateStatusAsync(Order Order);
        Task<int> InsertOrderAsync(Order Order);
    }
}
