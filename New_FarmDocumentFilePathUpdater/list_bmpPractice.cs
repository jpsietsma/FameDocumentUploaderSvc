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
    
    public partial class list_bmpPractice
    {
        public list_bmpPractice()
        {
            this.bmp_ag = new HashSet<bmp_ag>();
            this.form_wfp3_paymentBMP = new HashSet<form_wfp3_paymentBMP>();
            this.form_wfp3_specification = new HashSet<form_wfp3_specification>();
        }
    
        public decimal pk_bmpPractice_code { get; set; }
        public string fk_agency_code { get; set; }
        public string practice { get; set; }
        public Nullable<byte> life_reqd_yr { get; set; }
        public string agronomic { get; set; }
        public string fk_unit_code { get; set; }
        public Nullable<int> fk_list_wacPracticeCategory { get; set; }
        public string active { get; set; }
        public string fk_unit_code_NRCS_official { get; set; }
        public Nullable<decimal> ABC { get; set; }
        public string ABC_note { get; set; }
        public string noCost { get; set; }
        public string nonStructural { get; set; }
        public string NMCP { get; set; }
        public string NMP { get; set; }
        public string photograph { get; set; }
        public string CREPH20System { get; set; }
    
        public virtual ICollection<bmp_ag> bmp_ag { get; set; }
        public virtual ICollection<form_wfp3_paymentBMP> form_wfp3_paymentBMP { get; set; }
        public virtual ICollection<form_wfp3_specification> form_wfp3_specification { get; set; }
        public virtual list_agency list_agency { get; set; }
        public virtual list_unit list_unit { get; set; }
        public virtual list_wacPracticeCategory list_wacPracticeCategory { get; set; }
    }
}
