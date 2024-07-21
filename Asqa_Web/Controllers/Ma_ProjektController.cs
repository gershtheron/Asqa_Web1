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
            var projects = await _context.Ma_Projekte
               .Include(m => m.Mitarbeiter)
               .Include(p => p.Projekten)
               .Include(r => r.Rolle)
               .Include(t => t.Taetigkeit1Navigation)
               .Include(t => t.Taetigkeit2Navigation)
               .Include(t => t.Taetigkeit3Navigation)
               .Include(t => t.Taetigkeit4Navigation)
               .Include(t => t.Taetigkeit5Navigation)
               .Include(t => t.Taetigkeit6Navigation)
               .ToListAsync();

            var viewModel = projects.Select(p => new Ma_ProjektViewModel
            {
                Id = p.Id,
                MaNachname = p.Mitarbeiter?.Ma_Nachname,
                Proj_Name = p.Projekten?.Proj_Name,
                Rolle = p.Rolle?.Rolle_name,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                TaetigkeitenDescriptions = GetTaetigkeitenDescriptions(p)
            }).ToList();

            return View(viewModel);
        }

        private List<string> GetTaetigkeitenDescriptions(Ma_Projekt project)
        {
            var descriptions = new List<string>();

            if (project.Taetigkeit1Navigation != null)
            {
                descriptions.Add(project.Taetigkeit1Navigation.Description);
            }

            if (project.Taetigkeit2Navigation != null)
            {
                descriptions.Add(project.Taetigkeit2Navigation.Description);
            }

            if (project.Taetigkeit3Navigation != null)
            {
                descriptions.Add(project.Taetigkeit3Navigation.Description);
            }

            if (project.Taetigkeit4Navigation != null)
            {
                descriptions.Add(project.Taetigkeit4Navigation.Description);
            }

            if (project.Taetigkeit5Navigation != null)
            {
                descriptions.Add(project.Taetigkeit5Navigation.Description);
            }

            if (project.Taetigkeit6Navigation != null)
            {
                descriptions.Add(project.Taetigkeit6Navigation.Description);
            }

            return descriptions;
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
                ViewData["MitarbeiterList"] = new SelectList(_context.Mitarbeiter, "Id", "MaNachname", viewModel.Ma_id);
                ViewData["ProjektList"] = new SelectList(_context.Projekten, "Id", "Proj_Name", viewModel.Proj_id);
                ViewData["RolleList"] = new SelectList(_context.Rollen, "Id", "Rolle_name", viewModel.RolleId);
                ViewData["TaetigkeitenList"] = new SelectList(_context.Taetigkeiten, "Id", "Description", viewModel.Taetigkeit1);

                return View(viewModel);
            }

            var ma_Projekt = new Ma_Projekt
                {
                    MitarbeiterId = viewModel.Ma_id,
                    ProjektId = viewModel.Proj_id,
                    RolleId = viewModel.RolleId,
                    StartDate = viewModel.Start_date,
                    EndDate = viewModel.End_date,
                    Taetigkeit1 = viewModel.Taetigkeit1,
                    Taetigkeit2 = viewModel.Taetigkeit2,
                    Taetigkeit3 = viewModel.Taetigkeit3,
                    Taetigkeit4 = viewModel.Taetigkeit4,
                    Taetigkeit5 = viewModel.Taetigkeit5,
                    Taetigkeit6 = viewModel.Taetigkeit6
                };

                _context.Ma_Projekte.Add(ma_Projekt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
       
        }
}
