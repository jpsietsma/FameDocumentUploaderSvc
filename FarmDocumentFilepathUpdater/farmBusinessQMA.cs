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
    
    public partial class farmBusinessQMA
    {
        public farmBusinessQMA()
        {
            this.farmBusinessQMATech = new HashSet<farmBusinessQMATech>();
            this.farmBusinessQMAVisit = new HashSet<farmBusinessQMAVisit>();
        }
    
        public int pk_farmBusinessQMA { get; set; }
        public int fk_farmBusiness { get; set; }
        public string fk_QMAType_code { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string situation { get; set; }
        public string goals { get; set; }
        public Nullable<int> visits_est { get; set; }
        public Nullable<int> hours_est { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string impactSummary { get; set; }
        public Nullable<int> fk_bmp_ag { get; set; }
    
        public virtual bmp_ag bmp_ag { get; set; }
        public virtual farmBusiness farmBusiness { get; set; }
        public virtual list_QMAType list_QMAType { get; set; }
        public virtual ICollection<farmBusinessQMATech> farmBusinessQMATech { get; set; }
        public virtual ICollection<farmBusinessQMAVisit> farmBusinessQMAVisit { get; set; }
    }
}
