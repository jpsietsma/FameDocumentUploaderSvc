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
    
    public partial class form_wfp2
    {
        public form_wfp2()
        {
            this.form_wfp2_version = new HashSet<form_wfp2_version>();
        }
    
        public int pk_form_wfp2 { get; set; }
        public int fk_farmBusiness { get; set; }
        public string pollutant_i_descrip { get; set; }
        public string pollutant_ii_descrip { get; set; }
        public string pollutant_iii_descrip { get; set; }
        public string pollutant_iv_descrip { get; set; }
        public string pollutant_v_descrip { get; set; }
        public string pollutant_vi_descrip { get; set; }
        public string pollutant_vii_descrip { get; set; }
        public string pollutant_viii_descrip { get; set; }
        public string pollutant_ix_descrip { get; set; }
        public string pollutant_x_descrip { get; set; }
        public string pollutant_xi_descrip { get; set; }
        public Nullable<int> fk_list_designerEngineer { get; set; }
        public string fk_agency_code { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<int> fk_list_designerEngineer_planner2 { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public Nullable<int> fk_list_designerEngineer_planner3 { get; set; }
        public Nullable<int> fk_supplementalAgreement { get; set; }
        public string pollutant_v2_descrip_CREP { get; set; }
    
        public virtual farmBusiness farmBusiness { get; set; }
        public virtual list_agency list_agency { get; set; }
        public virtual list_designerEngineer list_designerEngineer { get; set; }
        public virtual list_designerEngineer list_designerEngineer1 { get; set; }
        public virtual list_designerEngineer list_designerEngineer2 { get; set; }
        public virtual supplementalAgreement supplementalAgreement { get; set; }
        public virtual ICollection<form_wfp2_version> form_wfp2_version { get; set; }
    }
}
