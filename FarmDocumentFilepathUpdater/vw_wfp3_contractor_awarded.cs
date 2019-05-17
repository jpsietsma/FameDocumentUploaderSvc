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
    
    public partial class vw_wfp3_contractor_awarded
    {
        public int pk_farmBusiness { get; set; }
        public Nullable<int> pk_form_wfp3 { get; set; }
        public Nullable<int> pk_form_wfp3_bid { get; set; }
        public string farmID { get; set; }
        public string Farm_Name { get; set; }
        public string ParticipantName { get; set; }
        public string Participant_Address { get; set; }
        public string Participant_CSZ { get; set; }
        public string Participant_Phone { get; set; }
        public string County { get; set; }
        public string Town { get; set; }
        public string Operator { get; set; }
        public string Designer { get; set; }
        public string Package { get; set; }
        public string Drawing { get; set; }
        public string Project_Description { get; set; }
        public Nullable<System.DateTime> Bid_Deadline_Date { get; set; }
        public Nullable<System.DateTime> Contract_Date { get; set; }
        public string Contract_Date_Str { get; set; }
        public string Print_Date { get; set; }
        public string Procurement_Plan_Date { get; set; }
        public string Page_Cnt { get; set; }
        public string attachedSpecifications { get; set; }
        public Nullable<decimal> Contract_Amt { get; set; }
        public Nullable<System.DateTime> Bid_Awarded { get; set; }
        public string Contract_Amt_Text { get; set; }
        public string Procurement_Type_Code { get; set; }
        public string Special_Provisions { get; set; }
        public string WFP3_Text_FreeForm { get; set; }
        public string Section_3_Signature_Date { get; set; }
        public string Section_4_Signature_Date { get; set; }
        public string Section_5_Signature_Date { get; set; }
        public string Certification_Date { get; set; }
        public Nullable<System.DateTime> Install_From { get; set; }
        public Nullable<System.DateTime> Install_To { get; set; }
        public string Contractor { get; set; }
        public string Contractor_Address { get; set; }
        public string Contractor_CSZ { get; set; }
        public string Contractor_Phone { get; set; }
    }
}