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
    
    public partial class vw_wfp3_landOwnerSA
    {
        public int pk_bmp_ag { get; set; }
        public int fk_farmBusiness { get; set; }
        public int pk_form_wfp3 { get; set; }
        public int fk_participant { get; set; }
        public string active { get; set; }
        public string farmID { get; set; }
        public string bmp_nbr { get; set; }
        public string fullname_FL_dnd { get; set; }
        public string fullname_LF_dnd { get; set; }
        public string packageName { get; set; }
        public string agreement_nbr_ro { get; set; }
        public Nullable<System.DateTime> inactive_date { get; set; }
        public Nullable<int> cntSAOwner { get; set; }
        public int pk_supplementalAgreement { get; set; }
        public int pk_supplementalAgreementTaxParcel { get; set; }
    }
}
