using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteelHorseTrucks.Data;
using SteelHorseTrucks.Models;

namespace SteelHorseTrucks.Controllers
{
    public class TrucksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrucksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Public: List all trucks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trucks.ToListAsync());
        }

        // Public: Show truck details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trucks == null)
            {
                return NotFound();
            }

            var truck = await _context.Trucks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truck == null)
            {
                return NotFound();
            }

            return View(truck);
        }

        // Admin only: Create GET
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // Admin only: Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Trucks trucks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trucks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trucks);
        }

        // Admin only: Edit GET
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trucks == null)
            {
                return NotFound();
            }

            var trucks = await _context.Trucks.FindAsync(id);
            if (trucks == null)
            {
                return NotFound();
            }
            return View(trucks);
        }

        // Admin only: Edit POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Trucks trucks)
        {
            if (id != trucks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trucks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrucksExists(trucks.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(trucks);
        }

        // Admin only: Delete GET
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trucks == null)
            {
                return NotFound();
            }

            var trucks = await _context.Trucks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trucks == null)
            {
                return NotFound();
            }

            return View(trucks);
        }

        // Admin only: Delete POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trucks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Trucks' is null.");
            }

            var trucks = await _context.Trucks.FindAsync(id);
            if (trucks != null)
            {
                _context.Trucks.Remove(trucks);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrucksExists(int id)
        {
            return (_context.Trucks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
