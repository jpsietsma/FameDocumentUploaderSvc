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
    
    public partial class participantContractor
    {
        public participantContractor()
        {
            this.participantContractorType = new HashSet<participantContractorType>();
            this.participantContractor_vendex = new HashSet<participantContractor_vendex>();
        }
    
        public int pk_participantContractor { get; set; }
        public int fk_participant { get; set; }
        public string active { get; set; }
        public string fk_regionWAC_code { get; set; }
        public string ein { get; set; }
        public Nullable<System.DateTime> vendex_date { get; set; }
        public Nullable<System.DateTime> workmensComp_start { get; set; }
        public Nullable<System.DateTime> workmensComp_end { get; set; }
        public Nullable<System.DateTime> form_W9_date_signed { get; set; }
        public Nullable<System.DateTime> liabilityIns_start { get; set; }
        public Nullable<System.DateTime> liabilityIns_end { get; set; }
        public string landowner { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<int> contractor_id_access { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string isSupplier { get; set; }
    
        public virtual participant participant { get; set; }
        public virtual ICollection<participantContractorType> participantContractorType { get; set; }
        public virtual ICollection<participantContractor_vendex> participantContractor_vendex { get; set; }
    }
}
