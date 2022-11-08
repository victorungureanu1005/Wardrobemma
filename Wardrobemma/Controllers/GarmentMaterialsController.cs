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
    public class GarmentMaterialsController : Controller
    {
        private readonly WardrobeContext _context;

        public GarmentMaterialsController(WardrobeContext context)
        {
            _context = context;
        }

        // GET: GarmentMaterials
        public async Task<IActionResult> Index()
        {
              return View(await _context.GarmentMaterials.ToListAsync());
        }

        // GET: GarmentMaterials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GarmentMaterials == null)
            {
                return NotFound();
            }

            var garmentMaterial = await _context.GarmentMaterials
                .FirstOrDefaultAsync(m => m.GarmentMaterialID == id);
            if (garmentMaterial == null)
            {
                return NotFound();
            }

            return View(garmentMaterial);
        }

        // GET: GarmentMaterials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GarmentMaterials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GarmentMaterialID,Name,Natural")] GarmentMaterial garmentMaterial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garmentMaterial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(garmentMaterial);
        }

        // GET: GarmentMaterials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GarmentMaterials == null)
            {
                return NotFound();
            }

            var garmentMaterial = await _context.GarmentMaterials.FindAsync(id);
            if (garmentMaterial == null)
            {
                return NotFound();
            }
            return View(garmentMaterial);
        }

        // POST: GarmentMaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GarmentMaterialID,Name,Natural")] GarmentMaterial garmentMaterial)
        {
            if (id != garmentMaterial.GarmentMaterialID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garmentMaterial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarmentMaterialExists(garmentMaterial.GarmentMaterialID))
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
            return View(garmentMaterial);
        }

        // GET: GarmentMaterials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GarmentMaterials == null)
            {
                return NotFound();
            }

            var garmentMaterial = await _context.GarmentMaterials
                .FirstOrDefaultAsync(m => m.GarmentMaterialID == id);
            if (garmentMaterial == null)
            {
                return NotFound();
            }

            return View(garmentMaterial);
        }

        // POST: GarmentMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GarmentMaterials == null)
            {
                return Problem("Entity set 'WardrobeContext.GarmentMaterials'  is null.");
            }
            var garmentMaterial = await _context.GarmentMaterials.FindAsync(id);
            if (garmentMaterial != null)
            {
                _context.GarmentMaterials.Remove(garmentMaterial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarmentMaterialExists(int id)
        {
          return _context.GarmentMaterials.Any(e => e.GarmentMaterialID == id);
        }
    }
}
