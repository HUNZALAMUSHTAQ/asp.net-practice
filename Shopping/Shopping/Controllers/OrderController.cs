using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Dtos;
using Shopping.Interfaces;
using Shopping.Models;

namespace Shopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public ActionResult<List<Order>> GetOrders()
        {
            var orders = _orderService.GetOrders();
            return Ok(orders);
        }
        [HttpGet]
        [Route("GetById")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = _orderService.GetOrder(id);
            if(order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpPost]
        public async Task<ActionResult> CreateOrder(CreateOrderDto order)
        {
            var createdOrder = await _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrderById), new {Id = createdOrder.Id}, createdOrder);
        }
    }
}
