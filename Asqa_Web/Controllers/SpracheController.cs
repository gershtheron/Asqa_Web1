using Asqa_Web.Data;
using Asqa_Web.Models;
using Asqa_Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asqa_Web.Controllers
{
    public class SpracheController : Controller
    {

        private readonly ApplicationDbContext dbContext;

        public SpracheController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddSpracheViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // Check for duplicate entry
            var existingSprache = await dbContext.Sprache
                .FirstOrDefaultAsync(s => s.Sprache_name == viewModel.Sprache_name);

            if (existingSprache != null)
            {
                TempData["DuplicateEntry"] = true;
                return View(viewModel);
            }

            var sprache = new Sprache
            {
                Sprache_name = viewModel.Sprache_name
            };

            await dbContext.Sprache.AddAsync(sprache);
            await dbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Sprache added successfully!";
            ModelState.Clear();

            return RedirectToAction("Add");
        }
    }
}
