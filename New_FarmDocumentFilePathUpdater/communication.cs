//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace New_FarmDocumentFilePathUpdater
{
    using System;
    using System.Collections.Generic;
    
    public partial class communication
    {
        public communication()
        {
            this.eventVenue = new HashSet<eventVenue>();
            this.eventVenue1 = new HashSet<eventVenue>();
            this.participantCommunication = new HashSet<participantCommunication>();
            this.participantWAC_phone = new HashSet<participantWAC_phone>();
        }
    
        public int pk_communication { get; set; }
        public string number { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string areacode { get; set; }
    
        public virtual ICollection<eventVenue> eventVenue { get; set; }
        public virtual ICollection<eventVenue> eventVenue1 { get; set; }
        public virtual ICollection<participantCommunication> participantCommunication { get; set; }
        public virtual ICollection<participantWAC_phone> participantWAC_phone { get; set; }
    }
}
