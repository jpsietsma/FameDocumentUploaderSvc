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
    
    public partial class farmBusinessRevisionReqd
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public farmBusinessRevisionReqd()
        {
            this.farmBusinessRevisionReqdSupport = new HashSet<farmBusinessRevisionReqdSupport>();
        }
    
        public int pk_farmBusinessRevisionReqd { get; set; }
        public int fk_farmBusiness { get; set; }
        public short year { get; set; }
        public string typeRevisionNeeded { get; set; }
        public Nullable<byte> priority { get; set; }
        public string CREP { get; set; }
        public string failedPracticeOrThreat { get; set; }
        public string changeInOperation { get; set; }
        public string repairReplace { get; set; }
        public string suggestedByProgram { get; set; }
        public string agedActiveWFP { get; set; }
        public string requestByProducer { get; set; }
        public string comment { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
    
        public virtual farmBusiness farmBusiness { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<farmBusinessRevisionReqdSupport> farmBusinessRevisionReqdSupport { get; set; }
    }
}