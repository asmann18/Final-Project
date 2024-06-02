using Atlet.Business.DTOs.E_Commerce.OrderDtos;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserOrders()
        {
            return Ok(await _orderService.GetUserOrders());
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute]int id)
        {
            return Ok(await _orderService.GetOrderByIdAsync(id));
        }

        [HttpPut("[action]/{id}")]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> ChangeOrderStatus([FromRoute]int id)
        {
            return Ok(await _orderService.ChangeOrderStatus(id));
        }
        [HttpPut("[action]/{id}")]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> ChangeOrderStatusReverse([FromRoute] int id)
        {
            return Ok(await _orderService.ChangeOrderStatusReverse(id));
        }
        [HttpDelete("[action]/{id}")]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            return Ok(await _orderService.DeleteOrderAsync(id));
        }


    }
}
