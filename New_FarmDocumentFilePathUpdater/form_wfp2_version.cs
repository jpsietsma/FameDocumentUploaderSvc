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
    
    public partial class form_wfp2_version
    {
        public form_wfp2_version()
        {
            this.bmp_ag_funding = new HashSet<bmp_ag_funding>();
            this.bmp_ag_nmcp = new HashSet<bmp_ag_nmcp>();
            this.bmp_ag_SA = new HashSet<bmp_ag_SA>();
            this.bmp_ag_status = new HashSet<bmp_ag_status>();
            this.form_wfp2_version_tech = new HashSet<form_wfp2_version_tech>();
        }
    
        public int pk_form_wfp2_version { get; set; }
        public int fk_form_wfp2 { get; set; }
        public byte version { get; set; }
        public Nullable<System.DateTime> setup_date { get; set; }
        public Nullable<System.DateTime> approved_date { get; set; }
        public Nullable<decimal> guideline { get; set; }
        public string note { get; set; }
        public short year_start { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public Nullable<System.DateTime> issued_date { get; set; }
        public string inhouse_revision { get; set; }
        public string fk_WFP2ApprovedBy_code { get; set; }
    
        public virtual ICollection<bmp_ag_funding> bmp_ag_funding { get; set; }
        public virtual ICollection<bmp_ag_nmcp> bmp_ag_nmcp { get; set; }
        public virtual ICollection<bmp_ag_SA> bmp_ag_SA { get; set; }
        public virtual ICollection<bmp_ag_status> bmp_ag_status { get; set; }
        public virtual form_wfp2 form_wfp2 { get; set; }
        public virtual ICollection<form_wfp2_version_tech> form_wfp2_version_tech { get; set; }
        public virtual list_WFP2ApprovedBy list_WFP2ApprovedBy { get; set; }
    }
}
