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
    
    public partial class vw_participant_joinedLists
    {
        public int pk_participant { get; set; }
        public string regionWAC { get; set; }
        public string active { get; set; }
        public string prefix { get; set; }
        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public string suffix { get; set; }
        public string gender { get; set; }
        public string org { get; set; }
        public string email { get; set; }
        public string web { get; set; }
        public Nullable<System.DateTime> form_W9_signed_date { get; set; }
        public string dataSetVia { get; set; }
        public string dataReview_status { get; set; }
        public string dataReview_note { get; set; }
        public string ethnicity { get; set; }
        public string fullname_FL_dnd { get; set; }
        public string fullname_LF_dnd { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string fk_mailingStatus_code { get; set; }
        public Nullable<int> fk_organization { get; set; }
        public string fk_prefix_code { get; set; }
        public string fk_suffix_code { get; set; }
        public string Mailing_Status { get; set; }
        public string fk_diversityData_code { get; set; }
        public string fk_ethnicity_code { get; set; }
        public string fk_gender_code { get; set; }
        public string fk_dataReview_code { get; set; }
        public string fk_regionWAC_code { get; set; }
    }
}