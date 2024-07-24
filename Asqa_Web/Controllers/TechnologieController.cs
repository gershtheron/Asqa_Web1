using Asqa_Web.Data;
using Asqa_Web.Models.Entities;
using Asqa_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Asqa_Web.Controllers
{
    public class TechnologieController : Controller
    {

        private readonly ApplicationDbContext dbContext;

        public TechnologieController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }






        [HttpPost]
        public async Task<IActionResult> Add(AddTechnologieViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // Check for duplicate entry ------------------------------------------------
            var existingTechnologie = await dbContext.Technologie
                .FirstOrDefaultAsync(t => t.Tech_name == viewModel.Tech_name);
            if (existingTechnologie != null)
            {
                TempData["DuplicateEntry"] = true;
                return View(viewModel);
            }
            //---------------------------------------------------------------------------


            var technologie = new Technologie
            {
                Tech_name = viewModel.Tech_name

            };





            await dbContext.Technologie.AddAsync(technologie);

            await dbContext.SaveChangesAsync();

            //Confirmation message ------------------------------------------------------------
            TempData["SuccessMessage"] = "Technologie added successfully!";
            ModelState.Clear();

            return RedirectToAction("Add");

        }

















        [HttpGet]
        public async Task<IActionResult> Select()
        {
            var technologieList = await dbContext.Technologie
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Tech_name
                })
                .ToListAsync();

            var model = new SelectTechnologieViewModel
            {
                TechnologieList = technologieList
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Select(SelectTechnologieViewModel model)
        {
            if (ModelState.IsValid && model.SelectedTechnologieId != 0)
            {
                var selectedTechnologie = await dbContext.Technologie
                    .Include(t => t.Projekt_Technologien)
                        .ThenInclude(pt => pt.Projekten)
                    .Include(t => t.Ma_Technologie)
                        .ThenInclude(mt => mt.Mitarbeiter)
                    .FirstOrDefaultAsync(t => t.Id == model.SelectedTechnologieId);

                if (selectedTechnologie != null)
                {
                    model.Tech_name = selectedTechnologie.Tech_name;
                    model.MitarbeiterList = selectedTechnologie.Ma_Technologie
                     .Select(mt => new SelectMitarbeiterViewModel
                     {
                         Ma_Nachname = mt.Mitarbeiter.Ma_Nachname,
                         Ma_Vorname = mt.Mitarbeiter.Ma_Vorname,
                         Ma_FirmaRolle = mt.Mitarbeiter.Ma_FirmaRolle
                     })
                     .ToList();



                }
            }

            model.TechnologieList = await dbContext.Technologie
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Tech_name
                })
                .ToListAsync();

            return View(model);
        }

    }
}
