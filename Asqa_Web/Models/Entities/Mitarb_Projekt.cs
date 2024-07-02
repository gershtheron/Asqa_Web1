using System.ComponentModel.DataAnnotations.Schema;

namespace Asqa_Web.Models.Entities
{
    public class Mitarb_Projekt
    {
        public int Id { get; set; }
        public Guid Ma_id { get; set; }
        public int Proj_id { get; set; }
        public string? Ma_rolle { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime? End_date { get; set; }
        public string? Proj_name { get; set; }
        public string? Taetigkeiten { get; set; }


        [ForeignKey("Ma_id")]
        public virtual Mitarbeiter? Mitarbeiter { get; set; }

        [ForeignKey("Proj_id")]
        public virtual Projekten? Projekten { get; set; }
    }
}
