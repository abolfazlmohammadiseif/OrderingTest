using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Models
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders(int Page, int PageSize);
        Task<Order> GetById(int OrderId);
        Task<bool> Delete(Order Order);
        Task<bool> UpdateStatus(Order Order);
        Task<int> InsertOrder(Order Order);
    }
}
