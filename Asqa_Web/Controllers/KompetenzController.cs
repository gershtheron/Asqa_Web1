using Asqa_Web.Data;
using Asqa_Web.Models.Entities;
using Asqa_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asqa_Web.Controllers
{
    public class KompetenzController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KompetenzController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var kompetenzen = await _context.Kompetenzen.ToListAsync();
            var viewModel = kompetenzen.Select(k => new KompetenzViewModel
            {
                Id = k.Id,
                Komp_name = k.Komp_name,
                
            }).ToList();
            return View(viewModel);
        }




        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KompetenzViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var kompetenz = new Kompetenz { Komp_name = viewModel.Komp_name };
                _context.Add(kompetenz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kompetenz = await _context.Kompetenzen.FindAsync(id);
            if (kompetenz == null)
            {
                return NotFound();
            }

            var viewModel = new KompetenzViewModel { Id = kompetenz.Id, Komp_name = kompetenz.Komp_name };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KompetenzViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var kompetenz = await _context.Kompetenzen.FindAsync(id);
                if (kompetenz == null)
                {
                    return NotFound();
                }

                kompetenz.Komp_name = viewModel.Komp_name;
                _context.Update(kompetenz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kompetenz = await _context.Kompetenzen.FindAsync(id);
            if (kompetenz == null)
            {
                return NotFound();
            }

            return View(kompetenz);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kompetenz = await _context.Kompetenzen.FindAsync(id);
            _context.Kompetenzen.Remove(kompetenz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}