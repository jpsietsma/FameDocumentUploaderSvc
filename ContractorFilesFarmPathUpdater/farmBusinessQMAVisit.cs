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
    
    public partial class farmBusinessQMAVisit
    {
        public int pk_farmBusinessQMAVisit { get; set; }
        public int fk_farmBusinessQMA { get; set; }
        public System.DateTime date { get; set; }
        public string objective { get; set; }
        public string notes { get; set; }
        public Nullable<decimal> hours { get; set; }
        public string attendance { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string fk_qmaVisitType_code { get; set; }
        public string impact { get; set; }
    
        public virtual farmBusinessQMA farmBusinessQMA { get; set; }
        public virtual list_QMAVisitType list_QMAVisitType { get; set; }
    }
}