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

        public async Task<IActionResult> Details(int id)
        {
            Cat cat = await _db.Cats.SingleOrDefaultAsync(c => c.Id == id);

            if (cat != null)
            {
                return View(cat);
            }

            return NotFound();
        }

        public async Task<IActionResult> DeleteForm(int id)
        {
            Cat cat = await _db.Cats.SingleOrDefaultAsync(c => c.Id == id);

            if (cat != null)
            {
                return View(cat);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteForm(Cat CatToBeDeleted)
        {
            try
            {
                _db.Cats.Remove(CatToBeDeleted);
                await _db.SaveChangesAsync();

                TempData["success"] = "You disgust me";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
                return NoContent();
            }

        }
    }
}
