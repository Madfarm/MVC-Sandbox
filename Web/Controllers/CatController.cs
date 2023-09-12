using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Web.Data;

namespace Web.Controllers
{
    public class CatController : Controller
    {
        private readonly DataContext _db;
        public CatController(DataContext db) 
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var cats = await _db.Cats.ToListAsync();
            return View(cats);
        }
        
        public IActionResult InfiniteCat()
        {
            return View();
        }
    }
}
