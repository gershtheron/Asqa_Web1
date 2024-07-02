using Asqa_Web.Data;
using Asqa_Web.Models.Entities;
using Asqa_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Asqa_Web.Controllers
{
    public class MitarbeiterProjektController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MitarbeiterProjektController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var mitarb_Projekte = await _context.Mitarb_Projekte
            .Include(m => m.Mitarbeiter)
            .Include(p => p.Projekten)
            .ToListAsync();
        return View(mitarb_Projekte);
    }

    [HttpGet]
    public IActionResult Create(Guid? Ma_id)
    {
            ViewData["Ma_id"] = new SelectList(_context.Mitarbeiter, "Id", "Ma_Nachname");
            ViewData["Proj_id"] = new SelectList(_context.Projekten, "Id", "Proj_Name");
            ViewData["MitarbeiterList"] = new SelectList(_context.Mitarbeiter, "Id", "Ma_Nachname");
            ViewData["ProjektenList"] = new SelectList(_context.Projekten, "Id", "Proj_Name");
            ViewData["RolleList"] = new SelectList(_context.Rollen, "Id", "Rolle_name");
            ViewData["TaetigkeitenList"] = new SelectList(_context.Taetigkeiten, "Id", "Description");


            var viewModel = new Mitarb_Projekt
        {
            Ma_id = Ma_id.GetValueOrDefault() // Initialize Ma_id if provided
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Mitarb_Projekt viewModel)
    {
        if (!ModelState.IsValid)
        {
        ViewData["MitarbeiterList"] = new SelectList(_context.Mitarbeiter, "Id", "Ma_Nachname", viewModel.Ma_id);
        ViewData["ProjektenList"] = new SelectList(_context.Projekten, "Id", "Proj_Name", viewModel.Proj_id);
        ViewData["RolleList"] = new SelectList(_context.Rollen, "Id", "Rolle_name");
        ViewData["TaetigkeitenList"] = new SelectList(_context.Taetigkeiten, "Id", "Description", viewModel.Taetigkeiten);

            return View(viewModel);
        }

        try
        {
            _context.Add(viewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Unable to save changes: {ex.Message}");
            ViewData["Ma_id"] = new SelectList(_context.Mitarbeiter, "Id", "Ma_Nachname", viewModel.Ma_id);
            ViewData["Proj_id"] = new SelectList(_context.Projekten, "Id", "Proj_Name", viewModel.Proj_id);
            ViewData["RolleList"] = new SelectList(_context.Rollen, "Id", "Rolle_name", viewModel.Ma_rolle);
            ViewData["TaetigkeitenList"] = new SelectList(_context.Taetigkeiten, "Id", "Description", viewModel.Taetigkeiten);
            return View(viewModel);
        }
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var mitarb_Projekt = await _context.Mitarb_Projekte.FindAsync(id);
        if (mitarb_Projekt == null)
        {
            return NotFound();
        }
        ViewData["Ma_id"] = new SelectList(_context.Mitarbeiter, "Id", "Ma_Nachname", mitarb_Projekt.Ma_id);
        ViewData["Proj_id"] = new SelectList(_context.Projekten, "Id", "Proj_Name", mitarb_Projekt.Proj_id);
        ViewData["RolleList"] = new SelectList(_context.Rollen, "Id", "Rolle_name", mitarb_Projekt.Ma_rolle);
        ViewData["TaetigkeitenList"] = new SelectList(_context.Taetigkeiten, "Id", "Description", mitarb_Projekt.Taetigkeiten);
        return View(mitarb_Projekt);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Mitarb_Projekt mitarb_Projekt)
    {
        if (id != mitarb_Projekt.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(mitarb_Projekt);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Mitarb_ProjektExists(mitarb_Projekt.Id))
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
        ViewData["Ma_id"] = new SelectList(_context.Mitarbeiter, "Id", "Ma_Nachname", mitarb_Projekt.Ma_id);
        ViewData["Proj_id"] = new SelectList(_context.Projekten, "Id", "Proj_Name", mitarb_Projekt.Proj_id);
        ViewData["RolleList"] = new SelectList(_context.Rollen, "Id", "Rolle_name", mitarb_Projekt.Ma_rolle);
        ViewData["TaetigkeitenList"] = new SelectList(_context.Taetigkeiten, "Id", "Description", mitarb_Projekt.Taetigkeiten);
        return View(mitarb_Projekt);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var mitarb_Projekt = await _context.Mitarb_Projekte
            .Include(m => m.Mitarbeiter)
            .Include(p => p.Projekten)
            .FirstOrDefaultAsync(mp => mp.Id == id);
        if (mitarb_Projekt == null)
        {
            return NotFound();
        }

        return View(mitarb_Projekt);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var mitarb_Projekt = await _context.Mitarb_Projekte.FindAsync(id);
        _context.Mitarb_Projekte.Remove(mitarb_Projekt);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool Mitarb_ProjektExists(int id)
    {
        return _context.Mitarb_Projekte.Any(e => e.Id == id);
    }
}
}
