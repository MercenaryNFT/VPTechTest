using Microsoft.AspNetCore.Mvc;
using TechTestVPEF.Engine.Interfaces;
using TechTestVPEF.Lib.DTO;

namespace TechTestVPEF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public IActionResult Create(OrderDTO order)
        {
            ReponseDTO response = _orderService.InsertOrder(order);
            if (response.IsSuccess)
            {
                Ok(response);
            }

            return BadRequest(response);
        }
    }
}
