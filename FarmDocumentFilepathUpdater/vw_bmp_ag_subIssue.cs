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
    
    public partial class vw_bmp_ag_subIssue
    {
        public int pk_bmp_ag { get; set; }
        public int fk_farmBusiness { get; set; }
        public string bmp_nbr { get; set; }
        public string description { get; set; }
        public string fk_pollutant_category_code { get; set; }
        public string issueStatement_wfp2 { get; set; }
        public Nullable<int> fk_bmp_ag_subIssueHeader { get; set; }
        public string fk_statusBMP_code { get; set; }
    }
}
