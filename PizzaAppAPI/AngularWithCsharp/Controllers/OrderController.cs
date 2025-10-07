using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Dtos.OrderDtos;
using PizzaApp.Services.Abstractions;
using PizzaApp.Shared.CustomExceptions.OrderExceptions;
using System.Security.Claims;

namespace PizzaApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders(bool isOrderForUser = false) 
        {
            try
            {
                var response = await _orderService.GetAllOrders(isOrderForUser);
                return Response(response);
            }
            catch (OrderNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OrderDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var response = await _orderService.GetOrderById(id);
                return Response(response);
            }
            catch (OrderNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OrderDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] AddOrderDto addOrderDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return BadRequest("No user identifier");
                var response = await _orderService.CreateOrder(userId, addOrderDto);
                return Response(response);
            }
            catch (OrderNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OrderDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return BadRequest("No user identifier");
                var response = await _orderService.DeleteOrder(userId, id);
                return  Response(response);

            }
            catch (OrderNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OrderDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderDto updateOrderDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return BadRequest("No user identifier");
                var response = await _orderService.UpdateOrder(userId, id, updateOrderDto);
                return Response(response);
            }
            catch (OrderNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OrderDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
