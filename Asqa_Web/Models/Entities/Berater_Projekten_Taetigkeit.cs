using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Asqa_Web.Models.Entities
{
    public class Berater_Projekt_Taetigkeit
    {
        [Key]
        public int Id { get; set; }

        public int BeraterProjektId { get; set; }
        public int TaetigkeitId { get; set; }

        [ForeignKey("BeraterProjektId")]
        public virtual Berater_Projekten? Berater_Projekt { get; set; }

        [ForeignKey("TaetigkeitId")]
        public virtual Taetigkeit? Taetigkeit { get; set; }
    }
}
