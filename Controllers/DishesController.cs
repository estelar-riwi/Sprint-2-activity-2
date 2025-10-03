using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sprint2Activity2.Data;
using Sprint2Activity2.Models;

namespace Sprint2Activity2.Controllers
{
    public class DishesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DishesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dishes
        public async Task<IActionResult> Index()
        {
            return View(await _context.dishes.ToListAsync());
        }

        // GET: Dishes/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var dish = await _context.dishes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dish == null) return NotFound();

            return View(dish);
        }

        // GET: Dishes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dishes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Category")] Dish dish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dish);
        }

        // GET: Dishes/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var dish = await _context.dishes.FindAsync(id);
            if (dish == null) return NotFound();
            return View(dish);
        }

        // POST: Dishes/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Category")] Dish dish)
        {
            if (id != dish.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DishExists(dish.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dish);
        }

        // GET: Dishes/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var dish = await _context.dishes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dish == null) return NotFound();

            return View(dish);
        }

        // POST: Dishes/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var dish = await _context.dishes.FindAsync(id);
            if (dish != null)
            {
                _context.dishes.Remove(dish);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DishExists(int id)
        {
            return _context.dishes.Any(e => e.Id == id);
        }
    }
}