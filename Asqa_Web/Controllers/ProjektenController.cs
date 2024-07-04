using Asqa_Web.Data;
using Asqa_Web.Models;
using Asqa_Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Asqa_Web.Controllers
{
    public class ProjektenController : Controller
    {

        private readonly ApplicationDbContext dbContext;

        public ProjektenController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProjektenView viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // Check for duplicate entry
            var existingProjekt = await dbContext.Projekten
                .FirstOrDefaultAsync(p => p.Proj_Name == viewModel.Proj_Name);

            if (existingProjekt != null)
            {
                TempData["DuplicateEntry"] = true;
                return View(viewModel);
            }

            var projekt = new Projekten
            {
                Proj_Name = viewModel.Proj_Name
            };




            await dbContext.Projekten.AddAsync(projekt);
            await dbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Projekt added successfully!";
            ModelState.Clear();

            return RedirectToAction("Add");
        }








        [HttpGet]
        public async Task<IActionResult> Select()
        {
            var projektenList = await dbContext.Projekten
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Proj_Name
                })
                .ToListAsync();

            var model = new CombinedProjektenMitarbeiterViewModel
            {
                SelectProjektenViewModel = new SelectProjektenViewModel
                {
                    ProjektenList = projektenList
                }
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Select(CombinedProjektenMitarbeiterViewModel model)
        {
            if (ModelState.IsValid && model.SelectProjektenViewModel.SelectedProjektenId != 0)
            {
                var selectedProjekten = await dbContext.Projekten

                     .Include(p => p.Ma_Projekte)
                .ThenInclude(mp => mp.Mitarbeiter)
                    .FirstOrDefaultAsync(p => p.Id == model.SelectProjektenViewModel.SelectedProjektenId);

                if (selectedProjekten != null)
                {
                    model.SelectProjektenViewModel.Proj_Name = selectedProjekten.Proj_Name;

                    // Load the Ma_Projekt details
                    model.Ma_Projekte = selectedProjekten.Ma_Projekte.ToList();
                }
            }

            model.SelectProjektenViewModel.ProjektenList = await dbContext.Projekten
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Proj_Name
                })
                .ToListAsync();

            return View(model);
        }

































    }
}
