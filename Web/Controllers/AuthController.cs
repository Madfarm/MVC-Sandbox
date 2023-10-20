using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Utility;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
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

        public IActionResult Login()
        {
            return View();
        }

    }
}
