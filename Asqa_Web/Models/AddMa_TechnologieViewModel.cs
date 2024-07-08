using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asqa_Web.Models
{
    public class AddMa_TechnologieViewModel
    {
        public Guid MitarbeiterId { get; set; }
        public int TechnologieId { get; set; }

        public int KompetenzId { get; set; }
        public DateTime SeitJahr {  get; set; } 

        public List<SelectListItem>? MitarbeiterList { get; set; }
        public List<SelectListItem>? TechnologieList { get; set; }
        public List<SelectListItem>? KompetenzList { get; set; }

    }
}
