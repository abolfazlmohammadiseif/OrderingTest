using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderingContext _context;
        public OrderRepository(OrderingContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrders(int Page, int PageSize)
        {
            //var result = await _context.Set<Order>()
            var result = _context.Orders
                .AsNoTracking()
                .Skip((Page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            return result;
        }

        public async Task<int> InsertOrder(Order order)
        {
            await _context.AddAsync(order);
            return order.Id;
        }
    }
}
