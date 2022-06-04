using Moq;
using Ordering.Api.Controllers;
using Ordering.Application.Services.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ordering.UnitTests.Api
{
    public class OrderControllerUnitTests
    {
        private OrderController _orderController;
        private readonly Mock<IOrderService> _orderService;
        public OrderControllerUnitTests()
        {
            _orderService = new Mock<IOrderService>();
        }

        [Fact]
        public async Task Get_GivenNothing_ReturnList()
        {

            //Arrange
            _orderService.Setup(s => s.GetAllAsync(1, 2)).Returns(Task.FromResult(new List<Ordering.Application.Services.Orders.Dto.OrderViewModel>()));
            _orderController = new OrderController(_orderService.Object);

            //Act
            var result = _orderController.Get(1, 2);

            //Assert
            Assert.NotNull(result);
        }
    }
}
