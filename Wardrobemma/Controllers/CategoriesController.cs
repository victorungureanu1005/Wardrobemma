using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wardrobemma.Data;
using Wardrobemma.Models.ViewModels;

namespace Wardrobemma.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly WardrobeContext _context;
        public CategoriesController(WardrobeContext context)
        {
            _context = context;
        }


        // GET: CategoriesController
        public async Task<IActionResult> Index(string id)
        {
            ViewData["CurrentId"] = id;

            var viewModel = new CategoryViewModel();

            switch (id) { 
            case "Types": 
                viewModel.Types = await _context.GarmentTypes.ToListAsync();
                    return View(viewModel);
            case "Colours":
                    viewModel.Colours = await _context.GarmentColours.ToListAsync();
                    return View(viewModel);
                case "Materials":
                    viewModel.Materials = await _context.GarmentMaterials.ToListAsync();
                    return View(viewModel);
                case "Styles":
                    viewModel.Styles = await _context.GarmentStyles.ToListAsync();
                    return View(viewModel);
            }
               
            return View(viewModel);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
