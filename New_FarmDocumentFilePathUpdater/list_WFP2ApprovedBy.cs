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
    
    public partial class list_WFP2ApprovedBy
    {
        public list_WFP2ApprovedBy()
        {
            this.form_wfp2_version = new HashSet<form_wfp2_version>();
        }
    
        public string pk_WFP2ApprovedBy_code { get; set; }
        public string approvedBy { get; set; }
    
        public virtual ICollection<form_wfp2_version> form_wfp2_version { get; set; }
    }
}
