using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asqa_Web.Models
{
    public class SelectTechnologieViewModel
    {
        public List<SelectListItem>? TechnologieList { get; set; }
        public int SelectedTechnologieId { get; set; }
        public string? Tech_name { get; set; }

        public List<SelectMitarbeiterViewModel>? MitarbeiterList { get; set; }

    }
}
