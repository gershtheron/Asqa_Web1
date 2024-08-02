namespace Asqa_Web.Models.Entities
{
    public class Projekt_Technologie
    {
        public int? ProjektId { get; set; }
        public int? TechnologieId { get; set; }

        public Projekten? Projekten { get; set; }
        public Technologie? Technologie { get; set; }
    }
}
