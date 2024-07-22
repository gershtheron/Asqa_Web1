using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asqa_Web.Models.Entities
{
    public class Mitarbeiter
    {
        public Guid Id { get; set; }
        public string? Ma_Nachname { get; set; }
        public string? Ma_Vorname { get; set; }
        public string? Ma_Gebjahr { get; set; }
        public string? Ma_FirmaRolle { get; set; }
        public string? Ma_ImagePath { get; set; }

        public virtual ICollection<Ma_Projekt> Ma_Projekte { get; set; } = new List<Ma_Projekt>();
        public virtual ICollection<Ma_Technologie> Ma_Technologien { get; set; } = new List<Ma_Technologie>();
        public virtual ICollection<Berater_Projekten> Berater_Projekten { get; set; } = new List<Berater_Projekten>(); // Ensure this line is present
    }
}
