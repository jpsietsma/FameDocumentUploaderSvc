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
    
    public partial class supplementalAgreement
    {
        public supplementalAgreement()
        {
            this.farmBusinessCREP = new HashSet<farmBusinessCREP>();
            this.form_wfp2 = new HashSet<form_wfp2>();
            this.supplementalAgreementNote = new HashSet<supplementalAgreementNote>();
            this.supplementalAgreementTaxParcel = new HashSet<supplementalAgreementTaxParcel>();
        }
    
        public int pk_supplementalAgreement { get; set; }
        public System.DateTime agreement_date { get; set; }
        public string agreement_nbr_ro { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public Nullable<System.DateTime> inactive_date { get; set; }
        public string ownerStr_dnd { get; set; }
        public string taxParcelStr_dnd { get; set; }
        public string ownerStrFL_dnd { get; set; }
    
        public virtual ICollection<farmBusinessCREP> farmBusinessCREP { get; set; }
        public virtual ICollection<form_wfp2> form_wfp2 { get; set; }
        public virtual ICollection<supplementalAgreementNote> supplementalAgreementNote { get; set; }
        public virtual ICollection<supplementalAgreementTaxParcel> supplementalAgreementTaxParcel { get; set; }
    }
}
