using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asqa_Web.Models
{
    public class AddMa_ProjektViewModel
    {
        public Guid Ma_id { get; set; }
        public int Proj_id { get; set; }

        public string? MaNachname { get; set; }

        public string? Ma_rolle { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime? End_date { get; set; }
        public string? Taetigkeiten { get; set; }

        public List<SelectListItem>? MitarbeiterList { get; set; }
        public List<SelectListItem>? ProjektList { get; set; }

       



    }
}
