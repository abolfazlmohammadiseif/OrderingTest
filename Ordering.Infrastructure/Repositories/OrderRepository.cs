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


        public async Task<List<Order>> GetAllOrdersAsync(int Page, int PageSize)
        {
            var result = _context.Orders.Include(o => o.OrderItems)
                .AsNoTracking()
                .Skip((Page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            return result;
        }

        public async Task<Order> GetByIdAsync(int OrderId)
        {
            return await _context.Orders.FindAsync(OrderId);
        }

        public async Task<int> InsertOrderAsync(Order order)
        {
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }
        public async Task<bool> DeleteAsync(Order Order)
        {
            var result = _context.Orders.Remove(Order);
            await _context.SaveChangesAsync();
            return true; ;
        }

        public async Task<bool> UpdateStatusAsync(Order Order)
        {
            try
            {
                var result = _context.Orders.Update(Order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
