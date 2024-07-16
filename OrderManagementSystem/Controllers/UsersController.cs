using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OrderManagementSystem.Models;
using OrderManagementSystem.Services.Interfaces;
using OrderManagementSystem.Helpers;
using Microsoft.Extensions.Configuration;

namespace OrderManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UsersController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var createdUser = await _userService.RegisterUserAsync(user);
            return CreatedAtAction(nameof(Login), new { username = createdUser.Username }, createdUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginUser)
        {
            var user = await _userService.AuthenticateUserAsync(loginUser.Username, loginUser.PasswordHash);
            if (user == null)
            {
                return Unauthorized();
            }

            var token = new JwtHelper(_configuration).GenerateJwtToken(user.Username, user.Role);
            return Ok(new { token });
        }
    }
}
