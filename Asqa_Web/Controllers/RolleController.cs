using Asqa_Web.Data;
using Asqa_Web.Models;
using Asqa_Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asqa_Web.Controllers
{
    public class RolleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Rollen.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Rolle rolle)
        {
            if (ModelState.IsValid)
            {
                _context.Rollen.Add(rolle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rolle);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolle = await _context.Rollen.FindAsync(id);
            if (rolle == null)
            {
                return NotFound();
            }
            return View(rolle);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Rolle rolle)
        {
            if (id != rolle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolleExists(rolle.Id))
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
            return View(rolle);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolle = await _context.Rollen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rolle == null)
            {
                return NotFound();
            }

            return View(rolle);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rolle = await _context.Rollen.FindAsync(id);
            _context.Rollen.Remove(rolle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolleExists(int id)
        {
            return _context.Rollen.Any(e => e.Id == id);
        }
    }
}
