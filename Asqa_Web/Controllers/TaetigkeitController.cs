using Asqa_Web.Data;
using Asqa_Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asqa_Web.Controllers
{
    public class TaetigkeitController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        private readonly ApplicationDbContext _context;

        public TaetigkeitController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Taetigkeiten.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Taetigkeit taetigkeit)
        {
            if (ModelState.IsValid)
            {
                _context.Taetigkeiten.Add(taetigkeit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taetigkeit);
        }



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taetigkeit = await _context.Taetigkeiten.FindAsync(id);
            if (taetigkeit == null)
            {
                return NotFound();
            }
            return View(taetigkeit);
        }





        [HttpPost]
        public async Task<IActionResult> Edit(int id, Taetigkeit taetigkeit)
        {
            if (id != taetigkeit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taetigkeit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaetigkeitExists(taetigkeit.Id))
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
            return View(taetigkeit);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taetigkeit = await _context.Taetigkeiten
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taetigkeit == null)
            {
                return NotFound();
            }

            return View(taetigkeit);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taetigkeit = await _context.Taetigkeiten.FindAsync(id);
            _context.Taetigkeiten.Remove(taetigkeit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaetigkeitExists(int id)
        {
            return _context.Taetigkeiten.Any(e => e.Id == id);
        }
    }
}
