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
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto request)
        {
            var errorMessage = await _authService.Register(request);
            if(!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccssful = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }

            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var loginResponse = await _authService.Login(request);

            if (loginResponse.User == null) 
            {
                _response.IsSuccssful = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }

            _response.Result = loginResponse;

            return Ok(_response);
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto request)
        {
            var assignRoleSuccessful = await _authService.AssignRole(request.Email, request.Role.ToUpper());

            if (!assignRoleSuccessful)
            {
                _response.IsSuccssful = false;
                _response.Message = "An error has occurred";
                return BadRequest(_response);
            }

            return Ok(_response);
        }
    }
}
