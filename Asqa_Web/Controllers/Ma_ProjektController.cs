using Asqa_Web.Data;
using Asqa_Web.Migrations;
using Asqa_Web.Models;
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
        public async Task<IActionResult> Create(Guid? Ma_id)
        {
            ViewData["MitarbeiterList"] = new SelectList(_context.Mitarbeiter, "Id", "Ma_Nachname");
            ViewData["ProjektList"] = new SelectList(_context.Projekten, "Id", "Proj_Name");
            ViewData["RolleList"] = new SelectList(_context.Rollen, "Id", "Rolle_name");
            ViewData["TaetigkeitenList"] = new SelectList(_context.Taetigkeiten, "Id", "Description");

            var viewModel = new AddMa_ProjektViewModel
            {
                Ma_id = Ma_id.GetValueOrDefault()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddMa_ProjektViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["MitarbeiterList"] = new SelectList(_context.Mitarbeiter, "Id", "Ma_Nachname", viewModel.Ma_id);
                ViewData["ProjektList"] = new SelectList(_context.Projekten, "Id", "Proj_Name", viewModel.Proj_id);
                ViewData["RolleList"] = new SelectList(_context.Rollen, "Id", "Rolle_name", viewModel.Ma_rolle);
                ViewData["TaetigkeitenList"] = new SelectList(_context.Taetigkeiten, "Id", "Description", viewModel.Taetigkeiten);

                return View(viewModel);
            }

            try
            {
                var mitarbeiter = await _context.Mitarbeiter.FindAsync(viewModel.Ma_id);
                var projekt = await _context.Projekten.FindAsync(viewModel.Proj_id);


                if (mitarbeiter == null || projekt == null)
                {
                    ModelState.AddModelError("", "Mitarbeiter not found.");
                    return View(viewModel);
                }

                var ma_Projekt = new Ma_Projekt
                {
                    MitarbeiterId = viewModel.Ma_id,
                    ProjektId = viewModel.Proj_id,
                    Rolle = viewModel.Ma_rolle,
                    StartDate = viewModel.Start_date,
                    EndDate = viewModel.End_date,
                    Taetigkeiten = viewModel.Taetigkeiten,
                    Proj_Name = projekt.Proj_Name,
                    MaNachname = mitarbeiter.Ma_Nachname  // Set the MaNachname
                    
                };

                _context.Ma_Projekte.Add(ma_Projekt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Unable to save changes: {ex.Message}");
                ViewData["MitarbeiterList"] = new SelectList(_context.Mitarbeiter, "Id", "Ma_Nachname", viewModel.Ma_id);
                ViewData["ProjektList"] = new SelectList(_context.Projekten, "Id", "Proj_Name", viewModel.Proj_id);
                ViewData["RolleList"] = new SelectList(_context.Rollen, "Id", "Rolle_name", viewModel.Ma_rolle);
                ViewData["TaetigkeitenList"] = new SelectList(_context.Taetigkeiten, "Id", "Description", viewModel.Taetigkeiten);
                return View(viewModel);
            }
        }
}}
