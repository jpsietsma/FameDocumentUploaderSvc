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
    
    public partial class vw_bmp_ag_workload_basicPredictor
    {
        public int pk_farmBusiness { get; set; }
        public int pk_bmp_ag { get; set; }
        public Nullable<int> pk_bmp_ag_workload { get; set; }
        public string farmID { get; set; }
        public Nullable<decimal> ranking_ro { get; set; }
        public string fk_regionWAC_code { get; set; }
        public string fk_farmSize_code { get; set; }
        public string fk_status_code { get; set; }
        public Nullable<short> year { get; set; }
        public string fk_BMPWorkloadSortGroup_code { get; set; }
        public string bmp_nbr { get; set; }
        public string fk_statusBMP_code { get; set; }
        public string fk_pollutant_category_code { get; set; }
        public Nullable<decimal> fk_bmpPractice_code { get; set; }
        public string fk_BMPCode_code { get; set; }
        public string projectCode { get; set; }
        public Nullable<decimal> cost { get; set; }
        public Nullable<decimal> paid { get; set; }
        public string CREP { get; set; }
        public string AWEP { get; set; }
        public string EQIP { get; set; }
    }
}
