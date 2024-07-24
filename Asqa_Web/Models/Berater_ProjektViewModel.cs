namespace Asqa_Web.Models
{
    public class Berater_ProjektViewModel
    {
        public int Id { get; set; }

        public string? Proj_Name { get; set; }
    public string? Rolle { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public List<string>? TaetigkeitenDescriptions { get; set; }
        public string? Ma_Nachname { get; set; }
        public string? Ma_Vorname { get; set; }
    }
}
