using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asqa_Web.Models
{
    public class AddProjektTechnologieViewModel
    {
        public int ProjektId { get; set; }
        public List<int> SelectedTechnologien { get; set; } = new List<int>();

        public List<SelectListItem>? ProjektList { get; set; }
        public List<SelectListItem>? TechnologieList { get; set; }
   
    }
}
