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
    
    public partial class farmBusinessNMP
    {
        public int pk_nmp { get; set; }
        public int fk_farmBusiness { get; set; }
        public Nullable<System.DateTime> nmp_date { get; set; }
        public string needs_nmp { get; set; }
        public string basic_plan { get; set; }
        public string fk_followupNMP_code { get; set; }
        public string EQIP { get; set; }
        public string nmp_credit { get; set; }
        public string storage { get; set; }
        public string status { get; set; }
        public Nullable<int> fk_list_designerEngineer_nrcs { get; set; }
        public Nullable<int> fk_list_designerEngineer_nmp { get; set; }
        public string CREP { get; set; }
        public string bmp_nbr_nmp { get; set; }
        public string enterprise_primary { get; set; }
        public string enterprise_secondary { get; set; }
        public Nullable<decimal> acres_planned { get; set; }
        public Nullable<int> acres_corn { get; set; }
        public Nullable<short> goal { get; set; }
        public Nullable<short> crop_year { get; set; }
        public Nullable<short> crop_year_expiration { get; set; }
        public Nullable<System.DateTime> operationsMaintenance_signature_date { get; set; }
        public Nullable<System.DateTime> WFP3_signature_date { get; set; }
        public Nullable<short> WFP3_year { get; set; }
        public Nullable<System.DateTime> sample_date_most_recent { get; set; }
        public Nullable<short> sample_cnt { get; set; }
        public Nullable<short> sample_priority { get; set; }
        public string sampler { get; set; }
        public Nullable<System.DateTime> fsa_release_date { get; set; }
        public Nullable<System.DateTime> manure_sample_date { get; set; }
        public Nullable<System.DateTime> nmp_workshop_date { get; set; }
        public string wfp1_signatures { get; set; }
        public Nullable<System.DateTime> spreader_calibration_date { get; set; }
        public string comment { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string fk_NMPStorage_code { get; set; }
        public Nullable<short> AWEP_signup { get; set; }
        public Nullable<int> fk_bmp_ag_nmp { get; set; }
        public string mtc { get; set; }
    
        public virtual bmp_ag bmp_ag { get; set; }
        public virtual farmBusiness farmBusiness { get; set; }
        public virtual list_designerEngineer list_designerEngineer { get; set; }
        public virtual list_designerEngineer list_designerEngineer1 { get; set; }
        public virtual list_followupNMP list_followupNMP { get; set; }
        public virtual list_NMPStorage list_NMPStorage { get; set; }
    }
}