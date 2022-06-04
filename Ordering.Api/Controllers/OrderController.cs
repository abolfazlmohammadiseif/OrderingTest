using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Services.Orders;
using Ordering.Application.Services.Orders.Dto;
using Ordering.Domain.Models;

namespace Ordering.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        public IOrderService _orderService { get; set; }
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(OrderDto input)
        {
            return Ok(await _orderService.InsertOrderAsync(input));
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page, int pageSize)
        {
            return Ok(await _orderService.GetAllAsync(page, pageSize));
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateStatus(int orderId, OrderStatus orderStatus)
        {
            return Ok(await _orderService.UpdateOrderStatusAsync(orderId, orderStatus));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int orderId)
        {
            return Ok(await _orderService.DeleteOrderAsync(orderId));
        }
    }
}
