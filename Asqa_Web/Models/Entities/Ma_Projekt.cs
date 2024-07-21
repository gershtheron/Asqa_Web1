using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asqa_Web.Models.Entities
{
    public class Ma_Projekt
    {
        [Key]
        public int Id { get; set; }

      
        public Guid MitarbeiterId { get; set; }

       
        public int ProjektId { get; set; }

        public int RolleId { get; set; }  // Added RoleId 5


        public string? MaNachname { get; set; }

        public string? Proj_Name { get; set; }

       // public string? Rolle { get; set; }


       
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? Taetigkeit1 { get; set; }
        public int? Taetigkeit2 { get; set; }
        public int? Taetigkeit3 { get; set; }
        public int? Taetigkeit4 { get; set; }
        public int? Taetigkeit5 { get; set; }
        public int? Taetigkeit6 { get; set; }
        [ForeignKey("MitarbeiterId")]
        public virtual Mitarbeiter? Mitarbeiter { get; set; }

        [ForeignKey("ProjektId")]
        public virtual Projekten? Projekten { get; set; }

        [ForeignKey("RolleId")]
        public virtual Rolle? Rolle { get; set; }  // Added navigation property for Rolle


        [ForeignKey("Taetigkeit1")]
        public virtual Taetigkeit Taetigkeit1Navigation { get; set; }
        [ForeignKey("Taetigkeit2")]
        public virtual Taetigkeit Taetigkeit2Navigation { get; set; }
        [ForeignKey("Taetigkeit3")]
        public virtual Taetigkeit Taetigkeit3Navigation { get; set; }
        [ForeignKey("Taetigkeit4")]
        public virtual Taetigkeit Taetigkeit4Navigation { get; set; }
        [ForeignKey("Taetigkeit5")]
        public virtual Taetigkeit Taetigkeit5Navigation { get; set; }
        [ForeignKey("Taetigkeit6")]
        public virtual Taetigkeit Taetigkeit6Navigation { get; set; }

        [NotMapped]
        public List<string>? TaetigkeitenDescriptions { get; set; } = new List<string>();


    }
}
