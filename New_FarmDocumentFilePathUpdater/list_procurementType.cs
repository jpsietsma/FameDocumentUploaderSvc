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
    
    public partial class list_procurementType
    {
        public list_procurementType()
        {
            this.bmp_ag = new HashSet<bmp_ag>();
            this.form_wfp3 = new HashSet<form_wfp3>();
        }
    
        public string pk_procurementType_code { get; set; }
        public string type { get; set; }
    
        public virtual ICollection<bmp_ag> bmp_ag { get; set; }
        public virtual ICollection<form_wfp3> form_wfp3 { get; set; }
    }
}
