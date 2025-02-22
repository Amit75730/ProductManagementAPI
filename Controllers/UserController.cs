using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Models;
using ProductManagementAPI.Services.Interfaces;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            try
            {
                var createdUser = await _userService.Register(user);
                return Ok(new { message = "User registered successfully", userId = createdUser.Id });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userDto)
        {
            var token = await _userService.Login(userDto.Email, userDto.Password);
            if (token == null)
                return Unauthorized(new { message = "Invalid credentials" });

            return Ok(new { token });
        }
    }
}
