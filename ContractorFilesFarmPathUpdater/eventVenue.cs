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
    
    public partial class eventVenue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eventVenue()
        {
            this.eventDate = new HashSet<eventDate>();
            this.eventVenueType = new HashSet<eventVenueType>();
        }
    
        public int pk_eventVenue { get; set; }
        public string location { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public string note { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public Nullable<int> fk_property { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public Nullable<int> fk_communication_phone { get; set; }
        public Nullable<int> fk_communication_fax { get; set; }
    
        public virtual communication communication { get; set; }
        public virtual communication communication1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eventDate> eventDate { get; set; }
        public virtual property property { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eventVenueType> eventVenueType { get; set; }
    }
}
