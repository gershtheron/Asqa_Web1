using Asqa_Web.Data;
using Asqa_Web.Models.Entities;
using Asqa_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asqa_Web.Controllers
{
    public class AusbildungenController : Controller
    {

        private readonly ApplicationDbContext dbContext;

        public AusbildungenController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddAusbildungenViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // Check for duplicate entry
            var existingAusbildung = await dbContext.Ausbildungen
                .FirstOrDefaultAsync(a => a.Ausb_name == viewModel.Ausb_name &&
                                          a.Ausb_jahr == viewModel.Ausb_jahr &&
                                          a.Ausb_institut == viewModel.Ausb_institut 
                                          
                                          );

            if (existingAusbildung != null)
            {

                TempData["DuplicateEntry"] = true;
                return View(viewModel); // Return to the form to show the error

            }

            var ausbildung = new Ausbildungen
            {
                Ausb_name = viewModel.Ausb_name,
                Ausb_jahr = viewModel.Ausb_jahr,
                Ausb_institut = viewModel.Ausb_institut
            };

            await dbContext.Ausbildungen.AddAsync(ausbildung);

            await dbContext.SaveChangesAsync();

            // Clear the form
            ModelState.Clear();

            TempData["SuccessMessage"] = "Ausbildung added successfully!";

            return RedirectToAction("Add");


        }


    }
}
