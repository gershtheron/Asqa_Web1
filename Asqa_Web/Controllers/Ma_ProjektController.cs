using Asqa_Web.Data;
using Asqa_Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Asqa_Web.Controllers
{
    public class Ma_ProjektController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Ma_ProjektController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ma_Projekte = await _context.Ma_Projekte
                .Include(m => m.Mitarbeiter)
                .Include(p => p.Projekten)
                .ToListAsync();
            return View(ma_Projekte);
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

            var viewModel = new Ma_Projekt
            {
                //MitarbeiterId = Ma_id ?? Guid.Empty // Initialize Ma_id if provided

                MitarbeiterId = Ma_id.GetValueOrDefault()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ma_Projekt viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["MitarbeiterList"] = new SelectList(_context.Mitarbeiter, "Id", "Ma_Nachname", viewModel.MaNachname);
                ViewData["ProjektenList"] = new SelectList(_context.Projekten, "Id", "Proj_Name", viewModel.Proj_Name);
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
                ViewData["Ma_id"] = new SelectList(_context.Mitarbeiter, "Id", "Ma_Nachname", viewModel.MaNachname);
                ViewData["Proj_id"] = new SelectList(_context.Projekten, "Id", "Proj_Name", viewModel.Proj_Name);
                ViewData["RolleList"] = new SelectList(_context.Rollen, "Id", "Rolle_name", viewModel.Rolle);
                ViewData["TaetigkeitenList"] = new SelectList(_context.Taetigkeiten, "Id", "Description", viewModel.Taetigkeiten);
                return View(viewModel);
            }
        }
    }
}
