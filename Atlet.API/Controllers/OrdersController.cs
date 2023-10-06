using Atlet.Business.DTOs.E_Commerce.OrderDtos;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _orderService.GetAllOrderssAsync());
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ChangeOrderStatus([FromBody]OrderPutDto orderPutDto)
        {
            return Ok(await _orderService.UpdateOrderAsync(orderPutDto));
        }
    }
}
