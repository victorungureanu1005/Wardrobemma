using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wardrobemma.Data;
using Wardrobemma.Models;

namespace Wardrobemma.Controllers
{
    public class GarmentColoursController : Controller
    {
        private readonly WardrobeContext _context;

        public GarmentColoursController(WardrobeContext context)
        {
            _context = context;
        }

        // GET: GarmentColours
        public async Task<IActionResult> Index()
        {
              return View(await _context.GarmentColours.ToListAsync());
        }

        // GET: GarmentColours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GarmentColours == null)
            {
                return NotFound();
            }

            var garmentColour = await _context.GarmentColours
                .FirstOrDefaultAsync(m => m.GarmentColourID == id);
            if (garmentColour == null)
            {
                return NotFound();
            }

            return View(garmentColour);
        }

        // GET: GarmentColours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GarmentColours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GarmentColourID,Name")] GarmentColour garmentColour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garmentColour);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Categories");
            }
            return View(garmentColour);
        }

        // GET: GarmentColours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GarmentColours == null)
            {
                return NotFound();
            }

            var garmentColour = await _context.GarmentColours.FindAsync(id);
            if (garmentColour == null)
            {
                return NotFound();
            }
            return View(garmentColour);
        }

        // POST: GarmentColours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GarmentColourID,Name")] GarmentColour garmentColour)
        {
            if (id != garmentColour.GarmentColourID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garmentColour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarmentColourExists(garmentColour.GarmentColourID))
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
            return View(garmentColour);
        }

        // GET: GarmentColours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GarmentColours == null)
            {
                return NotFound();
            }

            var garmentColour = await _context.GarmentColours
                .FirstOrDefaultAsync(m => m.GarmentColourID == id);
            if (garmentColour == null)
            {
                return NotFound();
            }

            return View(garmentColour);
        }

        // POST: GarmentColours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GarmentColours == null)
            {
                return Problem("Entity set 'WardrobeContext.GarmentColours'  is null.");
            }
            var garmentColour = await _context.GarmentColours.FindAsync(id);
            if (garmentColour != null)
            {
                _context.GarmentColours.Remove(garmentColour);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarmentColourExists(int id)
        {
          return _context.GarmentColours.Any(e => e.GarmentColourID == id);
        }
    }
}
