using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Dtos.UserDtos;
using PizzaApp.Services.UserServices.Abstractions;
using PizzaApp.Shared.CustomExceptions.UserExceptions;

namespace PizzaApp.Controllers
{
    [Authorize] //za da koristi authorizacija vo kontrolerot
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]    
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserRequestDto registerUserRequest)
        {
            try
            {
                var response = await _userService.RegisterUserAsync(registerUserRequest);
                return Response(response);
            }
            catch (UserDataException)
            {
                return BadRequest();
            }
            catch (UserNotFoundException )
            {
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LogInUserAsync([FromBody] LoginUserRequestDto loginUserRequest)
        {
            try
            {
                var response = await _userService.LoginUserAsync(loginUserRequest);
                return Response(response);
            }
            catch (UserDataException )
            {
                return BadRequest();
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var response = await _userService.GetAllUsersAsync();
                return Response(response);  
            }
            catch (UserDataException)
            {
                return BadRequest();
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            try
            {
                var response = await _userService.GetUsersByIdAsync(id);
                return Response(response);
            }
            catch (UserDataException)
            {
                return BadRequest();
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
                var response = await _userService.GetUsersByIdAsync(id);
                return Response(response);
            }
            catch (UserDataException)
            {
                return BadRequest();
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var response = await _userService.DeleteUserAsync(id);
                return Response(response);
            }
            catch (UserDataException)
            {
                return BadRequest();
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
