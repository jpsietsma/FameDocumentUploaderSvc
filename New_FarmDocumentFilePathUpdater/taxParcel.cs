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
    
    public partial class taxParcel
    {
        public taxParcel()
        {
            this.bmp_ag_leasedLand = new HashSet<bmp_ag_leasedLand>();
            this.farmBusinessTaxParcel = new HashSet<farmBusinessTaxParcel>();
            this.supplementalAgreementTaxParcel = new HashSet<supplementalAgreementTaxParcel>();
            this.taxParcelOwner = new HashSet<taxParcelOwner>();
        }
    
        public int pk_taxParcel { get; set; }
        public string fk_list_swis { get; set; }
        public string taxParcelID { get; set; }
        public string note { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string SBL { get; set; }
        public string ownerStr_dnd { get; set; }
        public Nullable<decimal> acreage { get; set; }
        public string retired { get; set; }
        public Nullable<short> taxRollYear { get; set; }
    
        public virtual ICollection<bmp_ag_leasedLand> bmp_ag_leasedLand { get; set; }
        public virtual ICollection<farmBusinessTaxParcel> farmBusinessTaxParcel { get; set; }
        public virtual list_swis list_swis { get; set; }
        public virtual ICollection<supplementalAgreementTaxParcel> supplementalAgreementTaxParcel { get; set; }
        public virtual ICollection<taxParcelOwner> taxParcelOwner { get; set; }
    }
}
