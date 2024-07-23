namespace Asqa_Web.Models.Entities
{
    public class Technologie
    {
        public int Id { get; set; }
        public string? Tech_name { get; set; }
        public virtual ICollection<Projekt_Technologie> Projekt_Technologien { get; set; } = new List<Projekt_Technologie>();

    }
}
