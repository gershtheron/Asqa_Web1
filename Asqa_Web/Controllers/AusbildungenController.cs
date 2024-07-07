using Asqa_Web.Data;
using Asqa_Web.Models.Entities;
using Asqa_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iText.Commons.Actions.Contexts;

namespace Asqa_Web.Controllers
{
    public class AusbildungenController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AusbildungenController(ApplicationDbContext _context)
        {
            this._context = _context;
        }


        public async Task<IActionResult> Index()
        {
            var ausbildungenList = await _context.Ausbildungen
                .Select(a => new AusbildungenViewModel
                {
                    Id = a.Id,
                    Ausb_name = a.Ausb_name,
                    Ausb_institut = a.Ausb_institut,
                    Ausb_jahr = a.Ausb_jahr
                }).ToListAsync();
            return View(ausbildungenList);
        }







        public IActionResult Create()
		{
			return View();
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
            var existingAusbildung = await _context.Ausbildungen
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

            await _context.Ausbildungen.AddAsync(ausbildung);

            await _context.SaveChangesAsync();

            // Clear the form
            ModelState.Clear();

            TempData["SuccessMessage"] = "Ausbildung added successfully!";

            return RedirectToAction("Add");


        }






        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ausbildung = await _context.Ausbildungen.FindAsync(id);
            if (ausbildung == null)
            {
                return NotFound();
            }

            var viewModel = new AusbildungenViewModel
            {
                Id = ausbildung.Id,
                Ausb_name = ausbildung.Ausb_name,
                Ausb_institut = ausbildung.Ausb_institut,
                Ausb_jahr = ausbildung.Ausb_jahr
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AusbildungenViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var ausbildung = await _context.Ausbildungen.FindAsync(viewModel.Id);
            if (ausbildung == null)
            {
                return NotFound();
            }

            ausbildung.Ausb_name = viewModel.Ausb_name;
            ausbildung.Ausb_institut = viewModel.Ausb_institut;
            ausbildung.Ausb_jahr = viewModel.Ausb_jahr;

            try
            {
                _context.Update(ausbildung);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Ausbildungen.Any(e => e.Id == viewModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ausbildung = await _context.Ausbildungen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ausbildung == null)
            {
                return NotFound();
            }

            return View(ausbildung);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ausbildung = await _context.Ausbildungen.FindAsync(id);
            _context.Ausbildungen.Remove(ausbildung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }






        private bool AusbildungExists(int id)
        {
            return _context.Ausbildungen.Any(e => e.Id == id);
        }



















    }
}
