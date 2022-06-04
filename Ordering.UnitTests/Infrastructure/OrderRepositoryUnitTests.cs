using Microsoft.EntityFrameworkCore;
using Moq;
using Ordering.Domain.Models;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ordering.UnitTests.Infrastructure
{
    public class OrderRepositoryUnitTests
    {
        private DbContextOptions<OrderingContext> dbContextOptions;
        public OrderRepositoryUnitTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<OrderingContext>().UseInMemoryDatabase("OrderingDB").Options;

        }

        [Fact]
        public async void GetByIdAsync_GivenId_ReturnsOrder()
        {
            //Arrange
            var productRepository = await CreateRepositoryAsync();

            //Act
            var order = productRepository.GetByIdAsync(1).Result;

            //Assert  
            Assert.NotNull(order);
        }

        [Fact]
        public async void GetAllOrders_GivenNothing_ReturnsOrders()
        {
            //Arrange
            var productRepository = await CreateRepositoryAsync();

            //Act
            var orders = productRepository.GetAllOrdersAsync(1,10).Result;

            //Assert  
            Assert.True(orders.Count > 1);
        }

        private async Task<OrderRepository> CreateRepositoryAsync()
        {
            var context = new OrderingContext(dbContextOptions);
            await PopulateDataAsync(context);
            return new OrderRepository(context);
        }
        private async Task PopulateDataAsync(OrderingContext context)
        {
            int index = 1;

            while (index <= 3)
            {
                var author = new Order()
                {
                    Description = $"Author_{index}",
                    OrderItems = new List<OrderItem>()
                {
                    new OrderItem
                    {
                        ProductName = "First", 
                        ProductId = index,
                        UnitPrice = index,
                        Units = index,
                    },
                    new OrderItem
                    {
                        ProductName = "Second",
                        ProductId = index,
                        UnitPrice = index,
                        Units = index,
                    },
                }
                };

                index++;
                await context.Orders.AddAsync(author);
            }

            await context.SaveChangesAsync();
        }

    }
}
