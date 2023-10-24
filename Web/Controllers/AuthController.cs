using AuthAPI.Models.Dto;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json.Serialization;
using Web.Models;
using Web.Services.IServices;
using Web.Utility;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthController(IAuthService authService, IHttpContextAccessor contextAccessor)
        {
            _authService = authService;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Register()
        {
            List<SelectListItem> roleList = new()
            {
                new SelectListItem{Value=SD.CustomerRole, Text=SD.CustomerRole},
                new SelectListItem{Value=SD.AdminRole, Text=SD.AdminRole}
            };

            ViewBag.RoleList = roleList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDto request)
        {
            var result = await _authService.Register(request);

            if (result != null && result.IsSuccssful)
            {
                if (string.IsNullOrEmpty(request.Role))
                {
                    request.Role = SD.CustomerRole;
                }

                var roleResult = await _authService.AssignRole(request);

                if (roleResult != null && roleResult.IsSuccssful)
                {
                    TempData["success"] = "Registered successfully. Login to continue";
                    return RedirectToAction(nameof(Login));

                }
            }

            List<SelectListItem> roleList = new()
            {
                new SelectListItem{Value=SD.CustomerRole, Text=SD.CustomerRole},
                new SelectListItem{Value=SD.AdminRole, Text=SD.AdminRole}
            };
            ViewBag.RoleList = roleList;

            TempData["error"] = "Something went wrong";
            return View(request);


        }

        public IActionResult Login()
        {
            LoginRequestDto loginRequest = new();
            return View(loginRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var result = await _authService.Login(request);

            if (result != null && result.IsSuccssful)
            {
                LoginResponse responseDto = JsonConvert.DeserializeObject<LoginResponse>(Convert.ToString(result.Result));


                _contextAccessor.HttpContext.Response.Cookies.Append("JwtToken", responseDto.Token);

                var handler = new JwtSecurityTokenHandler();

                var jwt = handler.ReadJwtToken(responseDto.Token);

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
                    jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
                identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                   jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
                identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                   jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));

                identity.AddClaim(new Claim(ClaimTypes.Name,
                   jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));




                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                TempData["success"] = "Signed in successfully";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomerError", result.Message);
                TempData["error"] = "Something went wrong";
                return View(request);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _contextAccessor.HttpContext.Response.Cookies.Delete("JwtToken");
            return RedirectToAction("Index", "Home");
        }
    }

}
