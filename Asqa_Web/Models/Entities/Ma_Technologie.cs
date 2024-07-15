using System.ComponentModel.DataAnnotations.Schema;

namespace Asqa_Web.Models.Entities
{
    public class Ma_Technologie
    {
        public int Id { get; set; }
        public Guid MitarbeiterId { get; set; }
        public int TechnologieId { get; set; }
        public int KompetenzId { get; set; }
        public DateTime SeitJahr { get; set; }

        [ForeignKey("MitarbeiterId")]
        public virtual Mitarbeiter Mitarbeiter { get; set; }

        [ForeignKey("TechnologieId")]
        public virtual Technologie Technologie { get; set; }

        [ForeignKey("KompetenzId")]
        public virtual Kompetenz Kompetenz { get; set; }
    }
}
