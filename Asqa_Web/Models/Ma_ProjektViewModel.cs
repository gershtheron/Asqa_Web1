using System.ComponentModel.DataAnnotations.Schema;

namespace Asqa_Web.Models
{
    public class Ma_ProjektViewModel
    {
        public int Id { get; set; }
        public string? Proj_Name { get; set; }
        public string? Rolle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<string>? Taetigkeiten { get; set; }
        public string? MaNachname { get; internal set; }
        [NotMapped]
        public List<string>? TaetigkeitenDescriptions { get; set; } = new List<string>();

    }
}
