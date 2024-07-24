using Asqa_Web.Models.Entities;

namespace Asqa_Web.Models
{
    public class CombinedProjektenMitarbeiterViewModel
    {
        public SelectProjektenViewModel? SelectProjektenViewModel { get; set; }
       

        public List<Berater_ProjektViewModel>? Berater_Projekte { get; set; } = new List<Berater_ProjektViewModel>();

    }
}
