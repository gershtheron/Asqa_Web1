using Asqa_Web.Data;
using Asqa_Web.Models;
using Asqa_Web.Models.Entities;
using iText.Commons.Actions.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asqa_Web.Controllers
{
    public class SpracheController : Controller
    {

        private readonly ApplicationDbContext _context;

        public SpracheController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sprache = await _context.Sprache.ToListAsync();
            var viewModel = sprache.Select(s => new SpracheViewModel
            {
                Id = s.Id,
               Sprache_name = s.Sprache_name,

            }).ToList();
            return View(viewModel);
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
            var existingSprache = await _context.Sprache
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

            await _context.Sprache.AddAsync(sprache);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Sprache added successfully!";
            ModelState.Clear();

            return RedirectToAction("Add");
        }
    }
}
