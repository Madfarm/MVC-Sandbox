using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Models;
using Web.Services.IServices;
using Web.Utility;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
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
        public IActionResult Register(RegistrationRequestDto request)
        {
            return NoContent();
        }

        public IActionResult Login()
        {
            return View();
        }

    }
}
