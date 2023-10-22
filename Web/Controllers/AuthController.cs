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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var result = await _authService.Login(request);

            if (result != null && result.IsSuccssful)
            {
                TempData["success"] = "Signed in successfully";
                return RedirectToAction("Home", "Index");
            }

            TempData["error"] = "Something went wrong";
            return View(request);
        }
    }
}
