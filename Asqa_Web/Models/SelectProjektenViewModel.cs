using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asqa_Web.Models
{
    public class SelectProjektenViewModel
    {

        public List<SelectListItem>? ProjektenList { get; set; }
        public int SelectedProjektenId { get; set; }
        public string? Proj_Name { get; set; }


    }
}
