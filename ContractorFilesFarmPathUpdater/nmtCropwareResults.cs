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
    
    public partial class nmtCropwareResults
    {
        public string farmID { get; set; }
        public string tractField { get; set; }
        public Nullable<short> plan_year { get; set; }
        public string fieldname { get; set; }
        public Nullable<decimal> acres { get; set; }
        public string soil { get; set; }
        public string current_crop { get; set; }
        public string manure1_app_method { get; set; }
        public string manure1_timing { get; set; }
        public string manure2_app_method { get; set; }
        public string manure2_timing { get; set; }
        public string fert1_name { get; set; }
        public string fert1_units { get; set; }
        public Nullable<decimal> fert1_ratePerAcre { get; set; }
        public string fert2_name { get; set; }
        public string fert2_units { get; set; }
        public Nullable<decimal> fert2_ratePerAcre { get; set; }
        public Nullable<int> PI_DP { get; set; }
        public Nullable<int> PI_PP { get; set; }
        public Nullable<byte> leaching_index { get; set; }
        public string sample_date { get; set; }
        public string manure1_source { get; set; }
        public string manure1_analysis { get; set; }
        public string manure1_units { get; set; }
        public string manure1_appliedPerAcre { get; set; }
        public string manure2_source { get; set; }
        public string manure2_analysis { get; set; }
        public string manure2_units { get; set; }
        public string manure2_appliedPerAcre { get; set; }
        public Nullable<decimal> RUSLE { get; set; }
        public string flooding_frequency { get; set; }
        public string waterbody_type { get; set; }
        public Nullable<decimal> flow_distance { get; set; }
        public string drainage_class { get; set; }
        public string conc_flows { get; set; }
        public string extraction_method { get; set; }
        public string lab_id { get; set; }
        public string soil_test_units { get; set; }
        public Nullable<decimal> soil_ph { get; set; }
        public Nullable<decimal> soil_p { get; set; }
        public Nullable<decimal> soil_k { get; set; }
        public Nullable<decimal> soil_mg { get; set; }
        public Nullable<decimal> soil_ca { get; set; }
        public Nullable<decimal> soil_mn { get; set; }
        public Nullable<decimal> soil_zn { get; set; }
        public Nullable<decimal> soil_fe { get; set; }
        public Nullable<decimal> soil_al { get; set; }
        public Nullable<decimal> soil_om { get; set; }
        public Nullable<int> morgan_eq_p_lbsPerAcre { get; set; }
        public Nullable<int> morgan_eq_k_lbsPerAcre { get; set; }
        public Nullable<decimal> ex_acidity { get; set; }
        public string rotation { get; set; }
        public Nullable<int> fk_farmBusiness { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public int pk_cropware { get; set; }
    }
}
