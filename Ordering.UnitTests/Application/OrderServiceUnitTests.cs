using AutoMapper;
using Moq;
using Ordering.Application.Profiles;
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
    public class OrderServiceUnitTests
    {
        private IOrderService _orderService;
        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly IMapper _mapper;
        public OrderServiceUnitTests()
        {
            _orderRepository = new Mock<IOrderRepository>();
            //_mapper = new Mock<IMapper>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new OrderProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

        }
        [Fact]
        public async Task InsertOrder_GivenModel_ReturnId()
        {
            //Arrange
            OrderDto orderDto = new OrderDto()
            {
                CustomerId = 1,
                Description ="Desc of the Order!",
                OrderItems = new List<OrderItemDto>(),
                OrderStatusId = OrderStatus.Submitted,
                PaymentMethodId = 1
            };

            _orderRepository.Setup(r => r.InsertOrderAsync(It.IsAny<Order>())).Returns(Task.FromResult(5));
            _orderService = new OrderService(_orderRepository.Object, _mapper);

            //Act
            var result = await _orderService.InsertOrderAsync(orderDto);

            //Assert
            Assert.True(result == 5);
        }
    }
}
