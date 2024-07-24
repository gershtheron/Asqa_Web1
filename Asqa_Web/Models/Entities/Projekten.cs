namespace Asqa_Web.Models.Entities
{
    public class Projekten
    {
        public int Id { get; set; }
        public string? Proj_Name { get; set; }

        public virtual ICollection<Ma_Projekt> Ma_Projekte { get; set; }
        public virtual ICollection<Projekt_Technologie> Projekt_Technologien { get; set; } = new List<Projekt_Technologie>();

        public virtual ICollection<Berater_Projekten> Berater_Projekten { get; set; } = new List<Berater_Projekten>();


    }
}
