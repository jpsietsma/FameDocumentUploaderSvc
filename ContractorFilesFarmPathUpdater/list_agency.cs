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
    
    public partial class list_agency
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public list_agency()
        {
            this.bmp_ag_workload = new HashSet<bmp_ag_workload>();
            this.form_wfp2 = new HashSet<form_wfp2>();
            this.list_bmpPractice = new HashSet<list_bmpPractice>();
        }
    
        public string pk_agency_code { get; set; }
        public string agency { get; set; }
        public string sisterAgencyToWAC { get; set; }
        public string EOH { get; set; }
        public string WOH { get; set; }
        public string basic { get; set; }
        public string BMPWorkload { get; set; }
        public string technical { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bmp_ag_workload> bmp_ag_workload { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<form_wfp2> form_wfp2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<list_bmpPractice> list_bmpPractice { get; set; }
    }
}
