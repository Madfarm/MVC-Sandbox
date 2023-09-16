using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

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

        public IActionResult CreateForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateForm(Cat model)
        {
            if (ModelState.IsValid)
            {
                await _db.Cats.AddAsync(model);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> CatDetails(int id)
        {

        }
    }
}
