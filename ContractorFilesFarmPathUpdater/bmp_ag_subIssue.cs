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
    
    public partial class bmp_ag_subIssue
    {
        public int pk_bmp_ag_subIssue { get; set; }
        public Nullable<int> fk_bmp_ag { get; set; }
        public Nullable<int> fk_bmp_ag_subMember { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public System.DateTime modified { get; set; }
        public string modified_by { get; set; }
    
        public virtual bmp_ag bmp_ag { get; set; }
        public virtual bmp_ag bmp_ag1 { get; set; }
    }
}
