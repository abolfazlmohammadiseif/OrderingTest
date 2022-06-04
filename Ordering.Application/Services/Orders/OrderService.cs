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

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetById(orderId);
            if (order != null)
            {
                await _orderRepository.Delete(order); 
                return true;
            }
            return false;
        }

        public async Task<List<OrderViewModel>> GetAllAsync(int Page, int PageSize)
        {
            var result = await _orderRepository.GetAllOrders(Page, PageSize);
            return _mapper.Map<List<OrderViewModel>>(result);
        }

        public async Task<int> InsertOrderAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            var id = await _orderRepository.InsertOrder(order);
            return id;
        }

        public async Task<bool> UpdateOrderStatusAsync(int orderId, OrderStatus status)
        {
            var order = await _orderRepository.GetById(orderId);
            if (order != null)
            {
                order.OrderStatusId = status;
                await _orderRepository.UpdateStatus(order);
                return true;
            }
            return false;
        }
    }
}
