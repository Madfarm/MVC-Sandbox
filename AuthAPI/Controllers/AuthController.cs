using AuthAPI.Models.Dto;
using AuthAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected readonly ResponseDto _response;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
            _response = new ResponseDto();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
    }
}
