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
    
    public partial class form_wfp3_modification
    {
        public int pk_form_wfp3_modification { get; set; }
        public int fk_form_wfp3 { get; set; }
        public Nullable<int> fk_form_wfp3_bmp { get; set; }
        public decimal amount { get; set; }
        public string note { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
    
        public virtual form_wfp3 form_wfp3 { get; set; }
        public virtual form_wfp3_bmp form_wfp3_bmp { get; set; }
    }
}
