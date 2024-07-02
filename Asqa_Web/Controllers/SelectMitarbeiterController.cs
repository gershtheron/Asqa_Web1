using Asqa_Web.Data;
using Asqa_Web.Models;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Asqa_Web.Controllers
{
    public class SelectMitarbeiterController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

      

        public SelectMitarbeiterController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this.dbContext = dbContext;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment => webHostEnvironment;

        [HttpGet]
        public async Task<IActionResult> Select()
        {
            var mitarbeiterList = await dbContext.Mitarbeiter
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = $"{m.Ma_Vorname} {m.Ma_Nachname}"
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
                    .FirstOrDefaultAsync(m => m.Id == model.SelectedMitarbeiterId);

                if (selectedMitarbeiter != null)
                {
                    model.Ma_Nachname = selectedMitarbeiter.Ma_Nachname;
                    model.Ma_Vorname = selectedMitarbeiter.Ma_Vorname;
                    model.Ma_Gebjahr = selectedMitarbeiter.Ma_Gebjahr;
                    model.Ma_FirmaRolle = selectedMitarbeiter.Ma_FirmaRolle;
                    model.Ma_ImagePath = selectedMitarbeiter.Ma_ImagePath;
                }
            }

            model.MitarbeiterList = await dbContext.Mitarbeiter
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = $"{m.Ma_Vorname} {m.Ma_Nachname}"
                })
                .ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GeneratePdf(Guid selectedMitarbeiterId)
        {
            var mitarbeiter = await dbContext.Mitarbeiter.FirstOrDefaultAsync(m => m.Id == selectedMitarbeiterId);
            if (mitarbeiter == null)
            {
                return NotFound();
            }

            var memoryStream = new MemoryStream();
            using (var writer = new PdfWriter(memoryStream))
            {
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                document.Add(new Paragraph("Mitarbeiter Details"));
                document.Add(new Paragraph($"Nachname: {mitarbeiter.Ma_Nachname}"));
                document.Add(new Paragraph($"Vorname: {mitarbeiter.Ma_Vorname}"));
                document.Add(new Paragraph($"Gebjahr: {mitarbeiter.Ma_Gebjahr}"));
                document.Add(new Paragraph($"Firma Rolle: {mitarbeiter.Ma_FirmaRolle}"));

                if (!string.IsNullOrEmpty(mitarbeiter.Ma_ImagePath))
                {
                    var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "images", mitarbeiter.Ma_ImagePath);
                    if (System.IO.File.Exists(imagePath))
                    {
                        var image = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(imagePath));
                        document.Add(image);
                    }
                }

                document.Close();
            }

            return File(memoryStream.ToArray(), "application/pdf", "MitarbeiterDetails.pdf");
        }
    }
}
