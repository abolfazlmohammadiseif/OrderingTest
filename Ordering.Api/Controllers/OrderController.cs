using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Services.Orders;

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
        [HttpGet]
        public IActionResult Get(int Page, int PageSize)
        {
            return Ok( _orderService.GetAllAsync(Page, PageSize));
        }
    }
}
