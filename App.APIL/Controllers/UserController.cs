using Microsoft.AspNetCore.Mvc;
using PetApp.Models;
using PetApp.Services;
using Microsoft.AspNetCore.Authorization;

namespace PetApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly UserValidator _userValidator;

        public UserController(UserService userService, UserValidator userValidator)
        {
            _userService = userService;
            _userValidator = userValidator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRequest request)
        {
            var error = _userValidator.ValidateNew(request);
            if (error != null)
            {
                return BadRequest(new { message = error });
            }

            await _userService.CreateUser(request);
            return Ok(new { message = "User registered successfully." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserRequest request)
        {
            var user = await _userService.LoginUser(request.Username, request.Password);
            var error = _userValidator.ValidateExistingUser(user);
            if (error != null)
            {
                return BadRequest(new { message = error });
            }

            var token = _userService.GenerateJwtToken(user!);
            return Ok(new { token });
        }

        //[Authorize]
        //[HttpGet("profile")]
        //public IActionResult Profile()
        //{
        //    var username = User.Identity?.Name;
        //    return Ok(new { message = $"Hello, {username}" });
        //}
    }
}
