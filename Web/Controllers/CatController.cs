﻿using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult InfiniteCat()
        {
            return View();
        }
    }
}
