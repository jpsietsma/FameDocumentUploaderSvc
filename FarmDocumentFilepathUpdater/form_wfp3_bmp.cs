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
    
    public partial class form_wfp3_bmp
    {
        public form_wfp3_bmp()
        {
            this.form_wfp3_modification = new HashSet<form_wfp3_modification>();
            this.form_wfp3_specification = new HashSet<form_wfp3_specification>();
            this.form_wfp3_paymentBMP = new HashSet<form_wfp3_paymentBMP>();
        }
    
        public int pk_form_wfp3_bmp { get; set; }
        public int fk_form_wfp3 { get; set; }
        public int fk_bmp_ag { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string createdProgrammatically_ro { get; set; }
    
        public virtual bmp_ag bmp_ag { get; set; }
        public virtual form_wfp3 form_wfp3 { get; set; }
        public virtual ICollection<form_wfp3_modification> form_wfp3_modification { get; set; }
        public virtual ICollection<form_wfp3_specification> form_wfp3_specification { get; set; }
        public virtual ICollection<form_wfp3_paymentBMP> form_wfp3_paymentBMP { get; set; }
    }
}
