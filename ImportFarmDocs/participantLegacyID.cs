//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImportFarmDocs
{
    using System;
    using System.Collections.Generic;
    
    public partial class participantLegacyID
    {
        public int pk_participantLegacyID { get; set; }
        public int fk_participant { get; set; }
        public string source { get; set; }
        public string id { get; set; }
        public string org_contact { get; set; }
    
        public virtual participant participant { get; set; }
    }
}
