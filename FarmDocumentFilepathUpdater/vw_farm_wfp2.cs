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
    
    public partial class vw_farm_wfp2
    {
        public int pk_farmBusiness { get; set; }
        public string farmID { get; set; }
        public string WFP2_Approved { get; set; }
        public string fk_status_code { get; set; }
        public string Farm_Status { get; set; }
        public string fk_groupPI_code { get; set; }
        public string ownerStr_dnd { get; set; }
        public string fk_regionWAC_code { get; set; }
        public string fk_farmSize_code { get; set; }
        public byte version { get; set; }
        public Nullable<System.DateTime> approved_date { get; set; }
        public string Expr1 { get; set; }
        public Nullable<int> fk_supplementalAgreement { get; set; }
        public string farm_name { get; set; }
    }
}
