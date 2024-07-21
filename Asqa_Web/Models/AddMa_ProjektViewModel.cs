using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asqa_Web.Models
{
    public class AddMa_ProjektViewModel
    {
        public Guid Ma_id { get; set; }
        public int Proj_id { get; set; }
        public int RolleId { get; set; }  // Added RolleId 1

        public string? MaNachname { get; set; }

        public string? Ma_rolle { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime? End_date { get; set; }
        public int? Taetigkeit1 { get; set; }
        public int? Taetigkeit2 { get; set; }
        public int? Taetigkeit3 { get; set; }
        public int? Taetigkeit4 { get; set; }
        public int? Taetigkeit5 { get; set; }
        public int? Taetigkeit6 { get; set; }

        public List<SelectListItem>? MitarbeiterList { get; set; }
        public List<SelectListItem>? ProjektList { get; set; }

        public List<SelectListItem>? RolleList { get; set; }  // Added RolleList 2


        public List<SelectListItem>? TaetigkeitenList { get; set; }

    }
}
