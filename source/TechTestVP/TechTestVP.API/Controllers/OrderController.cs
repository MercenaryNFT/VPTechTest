using Microsoft.AspNetCore.Mvc;
using TechTestVP.Engine.Services.Interfaces;
using TechTestVP.Lib.DTOs;
using TechTestVP.Lib.Models;
using TechTestVP.Lib.Response;

namespace TechTestVP.API.Controllers
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
        public async Task<IActionResult> Create(OrderDTO order) 
        {
            ReponseDTO response = await _orderService.InsertOrder(order);
            if (response.IsSuccess)
            {
                Ok(response);
            }

            return BadRequest(response);
        }
    }
}
