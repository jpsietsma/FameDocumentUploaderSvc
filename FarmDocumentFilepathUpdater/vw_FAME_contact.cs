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
    
    public partial class vw_FAME_contact
    {
        public string Sector { get; set; }
        public string Position { get; set; }
        public string Employee { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int pk_participant { get; set; }
        public int pk_participantWAC { get; set; }
        public string fk_sectorHR_code { get; set; }
        public string fk_regionWAC_code { get; set; }
        public string fk_positionWAC_code { get; set; }
        public string fk_classificationHR_code { get; set; }
        public string fk_EEO_code { get; set; }
        public Nullable<int> contactFAME { get; set; }
    }
}
