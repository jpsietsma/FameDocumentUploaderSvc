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
    
    public partial class vw_participant_org_master
    {
        public string fullname_FL_dnd { get; set; }
        public string fullname_LF_dnd { get; set; }
        public string isOrg { get; set; }
        public string fk_regionWAC_code { get; set; }
        public string org { get; set; }
        public int pk_participant { get; set; }
        public Nullable<int> fk_organization_participant { get; set; }
        public int pk_organization { get; set; }
        public Nullable<int> pk_participantOrganization { get; set; }
    }
}
