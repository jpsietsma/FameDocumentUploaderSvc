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
    
    public partial class farmBusinessASR
    {
        public int pk_farmBusinessASR { get; set; }
        public int fk_farmBusiness { get; set; }
        public string interviewee { get; set; }
        public Nullable<System.DateTime> asr_date { get; set; }
        public Nullable<System.DateTime> comprehensive_review_date { get; set; }
        public Nullable<int> fk_list_designerEngineer { get; set; }
        public string waterQuality_yn { get; set; }
        public string waterQuality_comment { get; set; }
        public string bmpEffective_yn { get; set; }
        public string bmpEffective_comment { get; set; }
        public string bmpOMA_yn { get; set; }
        public string bmpOMA_comment { get; set; }
        public string revision_reqd_yn { get; set; }
        public string revision_reqd_comment { get; set; }
        public string resourceChange_yn { get; set; }
        public string resourceChange_comment { get; set; }
        public string resourceChange_labor { get; set; }
        public string resourceChange_land { get; set; }
        public string resourceChange_bldg { get; set; }
        public string resourceChange_expansion { get; set; }
        public string resourceChange_liquidation { get; set; }
        public string resourceChange_other { get; set; }
        public Nullable<byte> farmIncome_code { get; set; }
        public string ownershipChange_yn { get; set; }
        public string ownershipChange_comment { get; set; }
        public string goalsChange_yn { get; set; }
        public string goalsChange_comment { get; set; }
        public string discussWFP_yn { get; set; }
        public string discussWFP_comment { get; set; }
        public string crep { get; set; }
        public string agEasement { get; set; }
        public string forestry { get; set; }
        public string farmToMarket { get; set; }
        public string sellDirectNow { get; set; }
        public string sellDirectFuture { get; set; }
        public string NYSCHAP { get; set; }
        public string signWAP { get; set; }
        public string commentToWAC { get; set; }
        public string OMA_BMP_effective { get; set; }
        public string OMA_challenges { get; set; }
        public string followup_reqd_planner { get; set; }
        public string coach_comment { get; set; }
        public string followup_reqd_wac { get; set; }
        public string wac_execcomm_comment { get; set; }
        public string issues_addressed { get; set; }
    
        public virtual farmBusiness farmBusiness { get; set; }
        public virtual list_designerEngineer list_designerEngineer { get; set; }
    }
}