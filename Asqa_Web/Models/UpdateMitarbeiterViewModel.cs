using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asqa_Web.Models
{
    public class UpdateMitarbeiterViewModel
    {
        public Guid Id { get; set; }
        public string? Ma_Nachname { get; set; }
        public string? Ma_Vorname { get; set; }
        public required string Ma_Gebjahr { get; set; }
        public string? Ma_FirmaRolle { get; set; }
        public string? Ma_ImagePath { get; set; }
        public IFormFile? Ma_Image { get; set; }

   
    }
}
