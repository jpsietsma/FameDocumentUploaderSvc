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
    
    public partial class supplementalAgreementTaxParcel
    {
        public supplementalAgreementTaxParcel()
        {
            this.bmp_ag = new HashSet<bmp_ag>();
            this.bmp_ag_SA = new HashSet<bmp_ag_SA>();
        }
    
        public int pk_supplementalAgreementTaxParcel { get; set; }
        public int fk_supplementalAgreement { get; set; }
        public int fk_taxParcel { get; set; }
        public Nullable<System.DateTime> cancel_date { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
    
        public virtual ICollection<bmp_ag> bmp_ag { get; set; }
        public virtual ICollection<bmp_ag_SA> bmp_ag_SA { get; set; }
        public virtual supplementalAgreement supplementalAgreement { get; set; }
        public virtual taxParcel taxParcel { get; set; }
    }
}