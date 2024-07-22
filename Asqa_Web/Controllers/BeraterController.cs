using Asqa_Web.Data;
using Asqa_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Asqa_Web.Controllers
{
    public class BeraterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeraterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Select()
        {
            var beraterList = await _context.Mitarbeiter
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = $"{m.Ma_Nachname} {m.Ma_Vorname}"
                })
                .ToListAsync();

            var model = new SelectBeraterViewModel
            {
                BeraterList = beraterList
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Select(SelectBeraterViewModel model)
        {
            if (ModelState.IsValid && model.SelectedBeraterId != Guid.Empty)
            {
                var selectedBerater = await _context.Mitarbeiter
                    .Include(m => m.Berater_Projekten)
                        .ThenInclude(bp => bp.Projekten)
                    .Include(m => m.Berater_Projekten)
                        .ThenInclude(bp => bp.Rolle)
                    .Include(m => m.Berater_Projekten)
                        .ThenInclude(bp => bp.Berater_Projekt_Taetigkeiten)
                        .ThenInclude(bpt => bpt.Taetigkeit)
                    .Include(m => m.Ma_Technologien)
                        .ThenInclude(mt => mt.Technologie)
                    .Include(m => m.Ma_Technologien)
                        .ThenInclude(mt => mt.Kompetenz)
                    .FirstOrDefaultAsync(m => m.Id == model.SelectedBeraterId);

                if (selectedBerater != null)
                {
                    model.Ma_Nachname = selectedBerater.Ma_Nachname;
                    model.Ma_Vorname = selectedBerater.Ma_Vorname;
                    model.Ma_Gebjahr = selectedBerater.Ma_Gebjahr;
                    model.Ma_FirmaRolle = selectedBerater.Ma_FirmaRolle;
                    model.Ma_ImagePath = selectedBerater.Ma_ImagePath;

                    model.Projekte = selectedBerater.Berater_Projekten.Select(bp => new Berater_ProjektViewModel
                    {
                        Proj_Name = bp.Projekten?.Proj_Name,
                        Rolle = bp.Rolle?.Rolle_name,
                        StartDate = bp.StartDate,
                        EndDate = bp.EndDate,
                        TaetigkeitenDescriptions = bp.Berater_Projekt_Taetigkeiten.Select(bpt => bpt.Taetigkeit.Description).ToList()
                    }).ToList();

                      model.Ma_Technologien = selectedBerater.Ma_Technologien.Select(mt => new AddMa_TechnologieViewModel
            {
                Technologie = mt.Technologie?.Tech_name,
                Kompetenz = mt.Kompetenz?.Komp_name,
                SeitJahr = mt.SeitJahr
            }).ToList();

                }
            }

            model.BeraterList = await _context.Mitarbeiter
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = $"{m.Ma_Nachname} {m.Ma_Vorname}"
                })
                .ToListAsync();

            return View(model);
        }
    }
}
