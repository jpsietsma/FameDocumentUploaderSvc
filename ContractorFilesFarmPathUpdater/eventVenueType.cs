//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContractorFilesFarmPathUpdater
{
    using System;
    using System.Collections.Generic;
    
    public partial class eventVenueType
    {
        public int pk_eventVenueType { get; set; }
        public int fk_eventVenue { get; set; }
        public string fk_participantType_code { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
    
        public virtual eventVenue eventVenue { get; set; }
        public virtual list_participantType list_participantType { get; set; }
    }
}
