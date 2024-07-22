using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asqa_Web.Models
{
    public class AddBerater_ProjektViewModel
    {
        public Guid? MitarbeiterId { get; set; }
        public int ProjektId { get; set; }
        public int RolleId { get; set; } // Added RolleId

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public List<int> SelectedTaetigkeiten { get; set; } = new List<int>();

        public List<SelectListItem>? MitarbeiterList { get; set; }
        public List<SelectListItem>? ProjektList { get; set; }
        public List<SelectListItem>? TaetigkeitenList { get; set; }
        public List<SelectListItem>? RolleList { get; set; } // Added RolleList

    }
}
