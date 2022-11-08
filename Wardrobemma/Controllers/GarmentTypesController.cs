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
    public class GarmentTypesController : Controller
    {
        private readonly WardrobeContext _context;

        public GarmentTypesController(WardrobeContext context)
        {
            _context = context;
        }

        // GET: GarmentTypes
        public async Task<IActionResult> Index()
        {
            var wardrobeContext = _context.GarmentTypes.Include(g => g.GarmentGenericType);
            return View(await wardrobeContext.ToListAsync());
        }

        // GET: GarmentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GarmentTypes == null)
            {
                return NotFound();
            }

            var garmentType = await _context.GarmentTypes
                .Include(g => g.GarmentGenericType)
                .FirstOrDefaultAsync(m => m.GarmentTypeID == id);
            if (garmentType == null)
            {
                return NotFound();
            }

            return View(garmentType);
        }

        // GET: GarmentTypes/Create
        public IActionResult Create()
        {
            ViewData["GarmentGenericTypeID"] = new SelectList(_context.GarmentGenericTypes, "GarmentGenericTypeID", "Name");
            return View();
        }

        // POST: GarmentTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GarmentTypeID,Name,GarmentGenericTypeID")] GarmentType garmentType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garmentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GarmentGenericTypeID"] = new SelectList(_context.GarmentGenericTypes, "GarmentGenericTypeID", "Name", garmentType.GarmentGenericTypeID);
            return View(garmentType);
        }

        // GET: GarmentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GarmentTypes == null)
            {
                return NotFound();
            }

            var garmentType = await _context.GarmentTypes.FindAsync(id);
            if (garmentType == null)
            {
                return NotFound();
            }
            ViewData["GarmentGenericTypeID"] = new SelectList(_context.GarmentGenericTypes, "GarmentGenericTypeID", "Name", garmentType.GarmentGenericTypeID);
            return View(garmentType);
        }

        // POST: GarmentTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GarmentTypeID,Name,GarmentGenericTypeID")] GarmentType garmentType)
        {
            if (id != garmentType.GarmentTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garmentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarmentTypeExists(garmentType.GarmentTypeID))
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
            ViewData["GarmentGenericTypeID"] = new SelectList(_context.GarmentGenericTypes, "GarmentGenericTypeID", "Name", garmentType.GarmentGenericTypeID);
            return View(garmentType);
        }

        // GET: GarmentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GarmentTypes == null)
            {
                return NotFound();
            }

            var garmentType = await _context.GarmentTypes
                .Include(g => g.GarmentGenericType)
                .FirstOrDefaultAsync(m => m.GarmentTypeID == id);
            if (garmentType == null)
            {
                return NotFound();
            }

            return View(garmentType);
        }

        // POST: GarmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GarmentTypes == null)
            {
                return Problem("Entity set 'WardrobeContext.GarmentTypes'  is null.");
            }
            var garmentType = await _context.GarmentTypes.FindAsync(id);
            if (garmentType != null)
            {
                _context.GarmentTypes.Remove(garmentType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarmentTypeExists(int id)
        {
          return _context.GarmentTypes.Any(e => e.GarmentTypeID == id);
        }
    }
}
