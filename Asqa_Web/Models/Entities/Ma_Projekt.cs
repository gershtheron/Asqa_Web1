using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asqa_Web.Models.Entities
{
    public class Ma_Projekt
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid MitarbeiterId { get; set; }

        [Required]
        public int ProjektId { get; set; }

        [Required]
        public string? MaNachname { get; set; }

        [Required]
        public string? Proj_Name { get; set; }

        public string? Rolle { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Taetigkeiten { get; set; }

        [ForeignKey("MitarbeiterId")]
        public virtual Mitarbeiter? Mitarbeiter { get; set; }

        [ForeignKey("ProjektId")]
        public virtual Projekten? Projekten { get; set; }


 


    }
}
