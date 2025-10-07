using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PizzaApp.Dtos.PizzaDtos;
using PizzaApp.Services.Abstractions;
using PizzaApp.Shared.CustomExceptions.PizzaExceptions;
using System.Formats.Asn1;
using System.Security.Claims;

namespace PizzaApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : BaseController
    {
        private readonly IPizzaService _pizaService;
        public PizzaController(IPizzaService pizzaService)
        {
            _pizaService = pizzaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _pizaService.GetAllPizzas();
                return Response(response);
            }
            catch (PizzaDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (PizzaNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPizzaById(int id)
        {
            try
            {
                var response = await _pizaService.GetPizzaById(id);
                return Response(response);
            }
            catch (PizzaDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (PizzaNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePizzaAsync([FromBody] AddPizzaDto addPizzaDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return BadRequest("No user identifier!");
                var response = await _pizaService.CreatePizza(userId, addPizzaDto);
                return Response(response);
            }
            catch (PizzaDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (PizzaNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizza(int id)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return BadRequest("No user identifier!");
                var response = await _pizaService.DeletePizza(userId, id);
                return Response(response);
            }
            catch (PizzaDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (PizzaNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePizza(int id, [FromBody] UpdatePizzaDto updatePizzaDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return BadRequest("No user identifier!");
                var response = await _pizaService.UpdatePizza(userId, id, updatePizzaDto);
                return Response(response);
            }
            catch (PizzaDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (PizzaNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
