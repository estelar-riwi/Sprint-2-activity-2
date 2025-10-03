using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sprint2Activity2.Data;
using Sprint2Activity2.Models;

namespace Sprint2Activity2.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var reservations = _context.reservations.Include(r => r.Customer);
            return View(await reservations.ToListAsync());
        }

        // GET: Reservations/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var reservation = await _context.reservations
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null) return NotFound();

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.customers, "Id", "Name");
            return View();
        }

        // POST: Reservations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Hour,Num_People,Notes,CustomerId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservation.Date = DateTime.SpecifyKind(reservation.Date, DateTimeKind.Utc);

                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.customers, "Id", "Name", reservation.CustomerId);
            return View(reservation);
        }

        // GET: Reservations/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var reservation = await _context.reservations.FindAsync(id);
            if (reservation == null) return NotFound();

            ViewData["CustomerId"] = new SelectList(_context.customers, "Id", "Name", reservation.CustomerId);
            return View(reservation);
        }

        // POST: Reservations/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Hour,Num_People,Notes,CustomerId")] Reservation reservation)
        {
            if (id != reservation.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    reservation.Date = DateTime.SpecifyKind(reservation.Date, DateTimeKind.Utc);

                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.customers, "Id", "Name", reservation.CustomerId);
            return View(reservation);
        }

        // GET: Reservations/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var reservation = await _context.reservations
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null) return NotFound();

            return View(reservation);
        }

        // POST: Reservations/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.reservations.Any(e => e.Id == id);
        }
    }
}