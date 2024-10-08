﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Asqa_Web.Models.Entities
{
    public class Berater_Projekten
    {
        [Key]
        public int Id { get; set; }

        public Guid? MitarbeiterId { get; set; }
        public int ProjektId { get; set; }
        public int RolleId { get; set; }  // Added RoleId 5

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [ForeignKey("MitarbeiterId")]
        public virtual Mitarbeiter? Mitarbeiter { get; set; }

        [ForeignKey("ProjektId")]
        public virtual Projekten? Projekten { get; set; }

        [ForeignKey("RolleId")]
        public virtual Rolle? Rolle { get; set; }  // Added navigation property for Rolle


        public virtual ICollection<Berater_Projekt_Taetigkeit> Berater_Projekt_Taetigkeiten { get; set; } = new List<Berater_Projekt_Taetigkeit>();


    }
}
