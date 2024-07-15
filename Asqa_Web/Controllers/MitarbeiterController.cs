using Asqa_Web.Data;
using Asqa_Web.Models;
using Asqa_Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Asqa_Web.Controllers
{
    public class MitarbeiterController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;



        public MitarbeiterController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this.dbContext = dbContext;
            this.webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public async Task<IActionResult> Select()
        {
            var mitarbeiterList = await dbContext.Mitarbeiter
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = $"{m.Ma_Nachname} {m.Ma_Vorname}"
                })
                .ToListAsync();




            var model = new SelectMitarbeiterViewModel
            {
                MitarbeiterList = mitarbeiterList
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Select(SelectMitarbeiterViewModel model)
        {
            if (ModelState.IsValid && model.SelectedMitarbeiterId != Guid.Empty)
            {
                var selectedMitarbeiter = await dbContext.Mitarbeiter

                      .Include(m => m.Ma_Projekte)
                .ThenInclude(mp => mp.Projekten)
                 .Include(m => m.Ma_Technologien)
                    .ThenInclude(mt => mt.Technologie)
                .Include(m => m.Ma_Technologien)
                    .ThenInclude(mt => mt.Kompetenz)
                    .FirstOrDefaultAsync(m => m.Id == model.SelectedMitarbeiterId);

                if (selectedMitarbeiter != null)
                {
                    model.Ma_Nachname = selectedMitarbeiter.Ma_Nachname;
                    model.Ma_Vorname = selectedMitarbeiter.Ma_Vorname;
                    model.Ma_Gebjahr = selectedMitarbeiter.Ma_Gebjahr;
                    model.Ma_FirmaRolle = selectedMitarbeiter.Ma_FirmaRolle;
                    model.Ma_ImagePath = selectedMitarbeiter.Ma_ImagePath;

                    model.Projekte = selectedMitarbeiter.Ma_Projekte.Select(mp => new Ma_Projekt
                {
                    Proj_Name = mp.Projekten.Proj_Name,
                    Rolle = mp.Rolle,
                    StartDate = mp.StartDate,
                    EndDate = mp.EndDate,
                    Taetigkeiten = mp.Taetigkeiten
                }).ToList();

                    model.Ma_Technologien = selectedMitarbeiter.Ma_Technologien.ToList();

                }
            }

            model.MitarbeiterList = await dbContext.Mitarbeiter
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = $"{m.Ma_Nachname} {m.Ma_Vorname}"
                })
                .ToListAsync();

            return View(model);
        }




        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }







        [HttpPost]
        public async Task<IActionResult> Add(AddMitarbeiterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // Check for duplicate entry
            var existingMitarbeiter = await dbContext.Mitarbeiter
                .FirstOrDefaultAsync(m => m.Ma_Nachname == viewModel.Ma_Nachname &&
                                          m.Ma_Vorname == viewModel.Ma_Vorname &&
                                          m.Ma_Gebjahr == viewModel.Ma_Gebjahr &&
                                          m.Ma_FirmaRolle == viewModel.Ma_FirmaRolle
                                          );

            if (existingMitarbeiter != null)
            {

                TempData["DuplicateEntry"] = true;
                return View(viewModel); // Return to the form to show the error

            }

            // Handle image upload
            string uniqueFileName = null;
            if (viewModel.Ma_Image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");

                // Ensure directory exists
                Directory.CreateDirectory(uploadsFolder);

                uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.Ma_Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await viewModel.Ma_Image.CopyToAsync(fileStream);
                }
            }




            var mitarbeiter = new Mitarbeiter
            {
                Ma_Nachname = viewModel.Ma_Nachname,
                Ma_Vorname = viewModel.Ma_Vorname,
                Ma_Gebjahr = viewModel.Ma_Gebjahr,
                Ma_FirmaRolle = viewModel.Ma_FirmaRolle,
                Ma_ImagePath = uniqueFileName // Save the image path to the database

            };

            await dbContext.Mitarbeiter.AddAsync(mitarbeiter);

            await dbContext.SaveChangesAsync();

            // Clear the form
            ModelState.Clear();

            TempData["SuccessMessage"] = "Mitarbeiter added successfully!";

            return RedirectToAction("Add");


        }




        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var mitarbeiter = await dbContext.Mitarbeiter.FindAsync(id);
            if (mitarbeiter == null)
            {
                return NotFound();
            }

            var model = new UpdateMitarbeiterViewModel
            {
                Id = mitarbeiter.Id,
                Ma_Nachname = mitarbeiter.Ma_Nachname,
                Ma_Vorname = mitarbeiter.Ma_Vorname,
                Ma_Gebjahr = mitarbeiter.Ma_Gebjahr,
                Ma_FirmaRolle = mitarbeiter.Ma_FirmaRolle,
                Ma_ImagePath = mitarbeiter.Ma_ImagePath
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateMitarbeiterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var mitarbeiter = await dbContext.Mitarbeiter.FindAsync(viewModel.Id);
            if (mitarbeiter == null)
            {
                return NotFound();
            }

            // Handle image upload
            string uniqueFileName = mitarbeiter.Ma_ImagePath;
            if (viewModel.Ma_Image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                Directory.CreateDirectory(uploadsFolder);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.Ma_Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await viewModel.Ma_Image.CopyToAsync(fileStream);
                }
            }

            mitarbeiter.Ma_Nachname = viewModel.Ma_Nachname;
            mitarbeiter.Ma_Vorname = viewModel.Ma_Vorname;
            mitarbeiter.Ma_Gebjahr = viewModel.Ma_Gebjahr;
            mitarbeiter.Ma_FirmaRolle = viewModel.Ma_FirmaRolle;
            mitarbeiter.Ma_ImagePath = uniqueFileName;

            dbContext.Mitarbeiter.Update(mitarbeiter);
            await dbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Mitarbeiter updated successfully!";
            return RedirectToAction("Select");
        }














        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var mitarbeiter = await dbContext.Mitarbeiter.FindAsync(id);
            if (mitarbeiter == null)
            {
                return NotFound();
            }

            return View(mitarbeiter);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var mitarbeiter = await dbContext.Mitarbeiter.FindAsync(id);
            if (mitarbeiter == null)
            {
                return NotFound();
            }

            dbContext.Mitarbeiter.Remove(mitarbeiter);
            await dbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Mitarbeiter deleted successfully!";
            return RedirectToAction("Select");
        }

























    }
}
