using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sprint2Activity2.Data;
using Sprint2Activity2.Models;

namespace Sprint2Activity2.Controllers
{
    public class WaitersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WaitersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Waiters
        public async Task<IActionResult> Index()
        {
            return View(await _context.waiters.ToListAsync());
        }

        // GET: Waiters/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var waiter = await _context.waiters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waiter == null) return NotFound();

            return View(waiter);
        }

        // GET: Waiters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Waiters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Shift,Years_Experience")] Waiter waiter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waiter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(waiter);
        }

        // GET: Waiters/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var waiter = await _context.waiters.FindAsync(id);
            if (waiter == null) return NotFound();
            return View(waiter);
        }

        // POST: Waiters/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,Shift,Years_Experience")] Waiter waiter)
        {
            if (id != waiter.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waiter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaiterExists(waiter.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(waiter);
        }

        // GET: Waiters/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var waiter = await _context.waiters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waiter == null) return NotFound();

            return View(waiter);
        }

        // POST: Waiters/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var waiter = await _context.waiters.FindAsync(id);
            if (waiter != null)
            {
                _context.waiters.Remove(waiter);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool WaiterExists(int id)
        {
            return _context.waiters.Any(e => e.Id == id);
        }
    }
}