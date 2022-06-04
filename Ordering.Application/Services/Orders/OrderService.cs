using AutoMapper;
using Ordering.Application.Services.Orders.Dto;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Services.Orders
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        public readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public Task<bool> DeleteOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDto>> GetAllAsync(int Page, int PageSize)
        {
            var result = await _orderRepository.GetAllOrders(Page, PageSize);
            return _mapper.Map<List<OrderDto>>(result);
        }

        public async Task<int> InsertOrderAsync(OrderDto orderDto)
        {
            var order = new Order
            {
                OrderDate = DateTime.Now,
                Description = orderDto.Description,
                CustomerId = orderDto.CustomerId,
                OrderStatusId = orderDto.OrderStatusId,
                PaymentMethodId = orderDto.PaymentMethodId,
                //OrderItems = orderDto.OrderItems
            };
            var id = await _orderRepository.InsertOrder(order);
            return id;
        }

        public Task<bool> UpdateOrderStatusAsync(int orderId, OrderStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
