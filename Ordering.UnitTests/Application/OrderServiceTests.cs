using AutoMapper;
using Moq;
using Ordering.Application.Services.Orders;
using Ordering.Application.Services.Orders.Dto;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ordering.UnitTests.Application
{
    public class OrderServiceTests
    {
        private readonly IOrderService _orderService;
        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly Mock<IMapper> _mapper;
        public OrderServiceTests()
        {
            _orderRepository = new Mock<IOrderRepository>();
            _mapper = new Mock<IMapper>();
            _orderService = new OrderService(_orderRepository.Object, _mapper.Object);
        }
        [Fact]
        public async Task InsertOrder_GivenModel_ReturnId()
        {
            //Arrange
            OrderDto orderDto = new OrderDto()
            {
                CustomerId = 1,
                Description =" Desc of the Order!",
                OrderItems = new List<OrderItemDto>(),
                OrderStatusId = OrderStatus.Submitted,
                PaymentMethodId = 1
            };

            //Act
            var result = await _orderService.InsertOrderAsync(orderDto);

            //Assert
            Assert.True(result >= 1);
        }
    }
}
