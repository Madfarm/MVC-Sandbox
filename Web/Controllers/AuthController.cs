using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Register()
        {
            List<SelectListItem> roleList = new()
            {
                
            };

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

    }
}
