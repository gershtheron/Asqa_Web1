using Asqa_Web.Data;
using Asqa_Web.Models;
using Asqa_Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Asqa_Web.Controllers
{
    public class MitarbeiterController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public MitarbeiterController(ApplicationDbContext dbContext )
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMitarbeiterViewModel viewModel) 
        {
            var mitarbeiter = new Mitarbeiter
            {
                Ma_Nachname = viewModel.Ma_Nachname,
                Ma_Vorname = viewModel.Ma_Vorname,
                Ma_Gebjahr = viewModel.Ma_Gebjahr,
                Ma_FirmaRolle = viewModel.Ma_FirmaRolle
            };


            await dbContext.Mitarbeiter.AddAsync(mitarbeiter);

           await dbContext.SaveChangesAsync();

        return View();
        }

            




    }
}
