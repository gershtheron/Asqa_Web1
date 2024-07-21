using Asqa_Web.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asqa_Web.Models
{
    public class SelectMitarbeiterViewModel
    {

        public Guid SelectedMitarbeiterId { get; set; }
        public List<SelectListItem>? MitarbeiterList { get; set; }
        public string? Ma_Nachname { get; set; }
        public string? Ma_Vorname { get; set; }
        public string? Ma_Gebjahr { get; set; }
        public string? Ma_FirmaRolle { get; set; }
        public string? Ma_ImagePath { get; set; }

        public List<Ma_Projekt> Projekte { get; set; } = new List<Ma_Projekt>();
        public List<Ma_Technologie>? Ma_Technologien { get; set; } // 
        public List<SelectListItem>? RolleList { get; set; }  // Added RolleList 2

        [NotMapped]
        public List<string>? TaetigkeitenDescriptions { get; set; } = new List<string>();
        public List<Berater_Projekten> Projekten { get; set; } = new List<Berater_Projekten>();

    }


}

