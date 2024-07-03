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

        public string? Taetigkeiten { get; set; }

        [ForeignKey("MitarbeiterId")]
        public virtual Mitarbeiter? Mitarbeiter { get; set; }

        [ForeignKey("ProjektId")]
        public virtual Projekten? Projekten { get; set; }

        [ForeignKey("RolleId")]
        public virtual Rolle? Rolle { get; set; }  // Added navigation property for Rolle



    }
}
