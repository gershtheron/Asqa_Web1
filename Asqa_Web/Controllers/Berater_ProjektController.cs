using Asqa_Web.Data;
using Asqa_Web.Models;
using Asqa_Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Asqa_Web.Controllers
{
    public class Berater_ProjektController : Controller
    {



        private readonly ApplicationDbContext _context;

        public Berater_ProjektController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: Berater_Projekt
        public async Task<IActionResult> Index()
        {
            var beraterProjekte = await _context.Berater_Projekten
                .Include(bp => bp.Mitarbeiter)
                .Include(bp => bp.Projekten)
                .Include(bp => bp.Rolle) // Ensure role is included

                .Include(bp => bp.Berater_Projekt_Taetigkeiten)
                    .ThenInclude(bpt => bpt.Taetigkeit)
                .ToListAsync();

            return View(beraterProjekte);
        }

        // GET: Berater_Projekt/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await PopulateViewBagsAsync();
            return View();
        }

        // POST: Berater_Projekt/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddBerater_ProjektViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                await PopulateViewBagsAsync();
                return View(viewModel);
            }

            var beraterProjekt = new Berater_Projekten
            {
                MitarbeiterId = viewModel.MitarbeiterId,
                ProjektId = viewModel.ProjektId,
                RolleId = viewModel.RolleId, // Ensure RolleId is set
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate
            };

            _context.Berater_Projekten.Add(beraterProjekt);
            await _context.SaveChangesAsync();

            var taetigkeiten = viewModel.SelectedTaetigkeiten
                .Select(tid => new Berater_Projekt_Taetigkeit { BeraterProjektId = beraterProjekt.Id, TaetigkeitId = tid }).ToList();

            _context.Berater_Projekt_Taetigkeiten.AddRange(taetigkeiten);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        private async Task PopulateViewBagsAsync()
            {
                var mitarbeiter = await _context.Mitarbeiter.ToListAsync();
                var projekten = await _context.Projekten.ToListAsync();
                var rollen = await _context.Rollen.ToListAsync();
                var taetigkeiten = await _context.Taetigkeiten.ToListAsync();

                ViewBag.MitarbeiterList = new SelectList(mitarbeiter, "Id", "Ma_Nachname");
                ViewBag.ProjektList = new SelectList(projekten, "Id", "Proj_Name");
                ViewBag.RolleList = new SelectList(rollen, "Id", "Rolle_name"); // Add roles to ViewBag
                ViewBag.TaetigkeitenList = new SelectList(taetigkeiten, "Id", "Description");
            }


        }
}
