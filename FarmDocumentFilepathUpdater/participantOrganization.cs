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
    
    public partial class participantOrganization
    {
        public int pk_participantOrganization { get; set; }
        public int fk_participant { get; set; }
        public int fk_organization { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string master { get; set; }
        public string title { get; set; }
        public string division { get; set; }
        public string department { get; set; }
    
        public virtual organization organization { get; set; }
        public virtual participant participant { get; set; }
    }
}
