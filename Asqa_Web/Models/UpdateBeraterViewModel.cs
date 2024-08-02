namespace Asqa_Web.Models
{
    public class UpdateBeraterViewModel
    {
        public Guid Id { get; set; }
        public string? Ma_Nachname { get; set; }
        public string? Ma_Vorname { get; set; }
        public required string Ma_Gebjahr { get; set; }
        public string? Ma_FirmaRolle { get; set; }
        public string? Ma_ImagePath { get; set; }
        public IFormFile? Ma_Image { get; set; }

        public List<Berater_ProjektViewModel> Projekte { get; set; } = new List<Berater_ProjektViewModel>();
        public List<AddMa_TechnologieViewModel> Ma_Technologien { get; set; } = new List<AddMa_TechnologieViewModel>();
    }
}
