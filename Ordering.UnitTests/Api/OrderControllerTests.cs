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
    public class OrderControllerTests
    {
        private readonly OrderController _orderController;
        private readonly Mock<IOrderService> _orderService;
        public OrderControllerTests()
        {
            _orderService = new Mock<IOrderService>();

            _orderController = new OrderController(_orderService.Object);
        }

        [Fact]
        public async Task Get_GivenNothing_ReturnList()
        {
            var result = _orderController.Get();
            Assert.NotNull(result);
        }
    }
}
