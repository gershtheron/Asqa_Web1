using Asqa_Web.Data;
using Asqa_Web.Models.Entities;
using Asqa_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Asqa_Web.Controllers
{
    public class Ma_TechnologieController : Controller
    {


        //---1
        private readonly ApplicationDbContext _context;

        public Ma_TechnologieController(ApplicationDbContext context)
        {
            _context = context;
        }


        //---2
        public async Task<IActionResult> Index()
        {
            var ma_Technologien = await _context.Ma_Technologien
                .Include(m => m.Mitarbeiter)
                .Include(t => t.Technologie)
                .Include(k => k.Kompetenz)
                .ToListAsync();
            return View(ma_Technologien);
        }



        //---3
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new AddMa_TechnologieViewModel
            {
                MitarbeiterList = _context.Mitarbeiter
                    .Select(m => new SelectListItem
                    {
                        Value = m.Id.ToString(),
                        Text = m.Ma_Nachname
                    }).ToList(),


                TechnologieList = _context.Technologie
                    .Select(t => new SelectListItem
                    {
                        Value = t.Id.ToString(),
                        Text = t.Tech_name
                    }).ToList(),


                KompetenzList = _context.Kompetenzen
                    .Select(k => new SelectListItem
                    {
                        Value = k.Id.ToString(),
                        Text = k.Komp_name
                    }).ToList()
            };
            return View(viewModel);
        }
        //-------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddMa_TechnologieViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var ma_Technologie = new Ma_Technologie
                {
                    MitarbeiterId = viewModel.MitarbeiterId,
                    TechnologieId = viewModel.TechnologieId,
                    KompetenzId = viewModel.KompetenzId,
                    SeitJahr = viewModel.SeitJahr
                };
                _context.Add(ma_Technologie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            viewModel.MitarbeiterList = _context.Mitarbeiter
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Ma_Nachname
                }).ToList();

            viewModel.TechnologieList = _context.Technologie
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Tech_name
                }).ToList();

            viewModel.KompetenzList = _context.Kompetenzen
                .Select(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Komp_name
                }).ToList();
            return View(viewModel);
        }



























    }
}
