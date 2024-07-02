namespace Asqa_Web.Models.Entities
{
    public class Mitarbeiter
    {
        public Guid Id { get; set; }
        public string? Ma_Nachname { get; set; }
        public string? Ma_Vorname { get; set; }
        public string? Ma_Gebjahr { get; set; }
        public string? Ma_FirmaRolle { get; set; }
        public string? Ma_ImagePath { get; set; } // Add this property
        public virtual ICollection<Ma_Projekt> Ma_Projekte { get; set; } = new List<Ma_Projekt>();
    }
}
