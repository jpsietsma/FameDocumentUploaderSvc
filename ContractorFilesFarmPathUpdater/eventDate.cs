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
    
    public partial class eventDate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eventDate()
        {
            this.eventDateAttendance = new HashSet<eventDateAttendance>();
        }
    
        public int pk_eventDate { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<int> fk_event { get; set; }
        public string note { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public Nullable<decimal> fee { get; set; }
        public Nullable<int> fk_eventVenue { get; set; }
    
        public virtual @event @event { get; set; }
        public virtual eventVenue eventVenue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eventDateAttendance> eventDateAttendance { get; set; }
    }
}