using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asqa_Web.Models
{
    public class SelectBeraterViewModel
    {

        public Guid SelectedBeraterId { get; set; }
        public List<SelectListItem> BeraterList { get; set; } = new List<SelectListItem>();

        public string? Ma_Nachname { get; set; }
        public string? Ma_Vorname { get; set; }
        public string? Ma_Gebjahr { get; set; }
        public string? Ma_FirmaRolle { get; set; }
        public string? Ma_ImagePath { get; set; }

        public List<Berater_ProjektViewModel> Projekte { get; set; } = new List<Berater_ProjektViewModel>();
        public List<AddMa_TechnologieViewModel> Ma_Technologien { get; set; } = new List<AddMa_TechnologieViewModel>();
    }


}

