using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Asqa_Web.Data;
using Asqa_Web.Models;
using Asqa_Web.Models.Entities;

namespace Asqa_Web.Controllers
{
    public class ProjektTechnologieController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProjektTechnologieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjektTechnologie
        public async Task<IActionResult> Index()
        {
            var projektTechnologien = await _context.Projekt_Technologie
                .Include(pt => pt.Projekten)
                .Include(pt => pt.Technologie)
                .ToListAsync();
            return View(projektTechnologien);
        }






        // GET: ProjektTechnologie/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var projekten = await _context.Projekten.ToListAsync();
            var technologien = await _context.Technologie.ToListAsync();

            var model = new AddProjektTechnologieViewModel
            {
                ProjektList = projekten.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Proj_Name
                }).ToList(),
                TechnologieList = technologien.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Tech_name
                }).ToList()
            };

            return View(model);
        }

        // POST: ProjektTechnologie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddProjektTechnologieViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var projekten = await _context.Projekten.ToListAsync();
                var technologien = await _context.Technologie.ToListAsync();
                viewModel.ProjektList = projekten.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Proj_Name
                }).ToList();
                viewModel.TechnologieList = technologien.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Tech_name
                }).ToList();

                return View(viewModel);
            }

            var projektTechnologien = viewModel.SelectedTechnologien
                .Select(tid => new Projekt_Technologie { ProjektId = viewModel.ProjektId, TechnologieId = tid }).ToList();

            _context.Projekt_Technologie.AddRange(projektTechnologien);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Projekt-Technologien successfully added!";
            return RedirectToAction(nameof(Create));
        }
    }
}