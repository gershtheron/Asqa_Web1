using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

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


    }


}

