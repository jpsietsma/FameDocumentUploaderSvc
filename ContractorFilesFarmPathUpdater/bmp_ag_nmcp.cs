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
    
    public partial class bmp_ag_nmcp
    {
        public int pk_bmp_ag_nmcp { get; set; }
        public int fk_bmp_ag { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public decimal amt { get; set; }
        public string note { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public Nullable<int> fk_form_wfp2_version { get; set; }
    
        public virtual bmp_ag bmp_ag { get; set; }
        public virtual form_wfp2_version form_wfp2_version { get; set; }
    }
}
