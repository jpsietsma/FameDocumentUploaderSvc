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
    
    public partial class mailingDateRSVP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mailingDateRSVP()
        {
            this.mailingDateRSVPAttendee = new HashSet<mailingDateRSVPAttendee>();
        }
    
        public int pk_mailingDateRSVP { get; set; }
        public int fk_mailingDate { get; set; }
        public Nullable<int> fk_mailingParticipant { get; set; }
        public Nullable<int> cnt { get; set; }
        public Nullable<decimal> donation { get; set; }
        public string groupSponsor { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public Nullable<int> fk_mailingSentTo { get; set; }
    
        public virtual mailingDate mailingDate { get; set; }
        public virtual mailingSentTo mailingSentTo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mailingDateRSVPAttendee> mailingDateRSVPAttendee { get; set; }
        public virtual mailingParticipant mailingParticipant { get; set; }
    }
}