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
    public class GarmentStylesController : Controller
    {
        private readonly WardrobeContext _context;

        public GarmentStylesController(WardrobeContext context)
        {
            _context = context;
        }

        // GET: GarmentStyles
        public async Task<IActionResult> Index()
        {
              return View(await _context.GarmentStyles.ToListAsync());
        }

        // GET: GarmentStyles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GarmentStyles == null)
            {
                return NotFound();
            }

            var garmentStyle = await _context.GarmentStyles
                .FirstOrDefaultAsync(m => m.GarmentStyleID == id);
            if (garmentStyle == null)
            {
                return NotFound();
            }

            return View(garmentStyle);
        }

        // GET: GarmentStyles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GarmentStyles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GarmentStyleID,Name")] GarmentStyle garmentStyle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garmentStyle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(garmentStyle);
        }

        // GET: GarmentStyles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GarmentStyles == null)
            {
                return NotFound();
            }

            var garmentStyle = await _context.GarmentStyles.FindAsync(id);
            if (garmentStyle == null)
            {
                return NotFound();
            }
            return View(garmentStyle);
        }

        // POST: GarmentStyles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GarmentStyleID,Name")] GarmentStyle garmentStyle)
        {
            if (id != garmentStyle.GarmentStyleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garmentStyle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarmentStyleExists(garmentStyle.GarmentStyleID))
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
            return View(garmentStyle);
        }

        // GET: GarmentStyles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GarmentStyles == null)
            {
                return NotFound();
            }

            var garmentStyle = await _context.GarmentStyles
                .FirstOrDefaultAsync(m => m.GarmentStyleID == id);
            if (garmentStyle == null)
            {
                return NotFound();
            }

            return View(garmentStyle);
        }

        // POST: GarmentStyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GarmentStyles == null)
            {
                return Problem("Entity set 'WardrobeContext.GarmentStyles'  is null.");
            }
            var garmentStyle = await _context.GarmentStyles.FindAsync(id);
            if (garmentStyle != null)
            {
                _context.GarmentStyles.Remove(garmentStyle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarmentStyleExists(int id)
        {
          return _context.GarmentStyles.Any(e => e.GarmentStyleID == id);
        }
    }
}
