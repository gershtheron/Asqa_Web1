namespace Asqa_Web.Models
{
    public class Berater_ProjektViewModel
    {
        public string? Proj_Name { get; set; }
        public string? Rolle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<string>? TaetigkeitenDescriptions { get; set; }
    }
}
