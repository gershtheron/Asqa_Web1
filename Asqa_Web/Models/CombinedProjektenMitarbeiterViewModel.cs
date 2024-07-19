using Asqa_Web.Models.Entities;

namespace Asqa_Web.Models
{
    public class CombinedProjektenMitarbeiterViewModel
    {
        public SelectProjektenViewModel? SelectProjektenViewModel { get; set; }
        public List<Ma_Projekt> Ma_Projekte { get; set; } = new List<Ma_Projekt>();


    }
}
