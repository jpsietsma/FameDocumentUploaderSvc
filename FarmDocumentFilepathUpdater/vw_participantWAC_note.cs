//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FarmDocumentFilepathUpdater
{
    using System;
    using System.Collections.Generic;
    
    public partial class vw_participantWAC_note
    {
        public int pk_participantWAC { get; set; }
        public int pk_participant { get; set; }
        public string Employee { get; set; }
        public int pk_participantWAC_note { get; set; }
        public string Participant_WAC_Note { get; set; }
        public string fk_positionWAC_code { get; set; }
        public string position { get; set; }
        public string exempt { get; set; }
        public string fk_classificationHR_code { get; set; }
        public string HR_Classification { get; set; }
        public string fk_EEO_code { get; set; }
        public string EEO_Classification { get; set; }
        public string fk_sectorHR_code { get; set; }
        public string HR_Sector { get; set; }
    }
}
