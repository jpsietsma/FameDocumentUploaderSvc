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
    
    public partial class vw_bmp_ag_workload
    {
        public int pk_farmBusiness { get; set; }
        public string FarmID { get; set; }
        public string FarmName { get; set; }
        public string OwnerFL { get; set; }
        public string OwnerLF { get; set; }
        public string FarmStatus { get; set; }
        public int pk_bmp_ag { get; set; }
        public string bmp_nbr { get; set; }
        public string description { get; set; }
        public Nullable<decimal> fk_bmpPractice_code { get; set; }
        public string fk_pollutant_category_code { get; set; }
        public int pk_bmp_ag_workload { get; set; }
        public Nullable<short> yearWorkload { get; set; }
        public Nullable<decimal> priority { get; set; }
        public string fk_agency_code { get; set; }
        public string agency { get; set; }
        public string fk_statusBMPWorkload_code { get; set; }
        public string WorkloadStatus { get; set; }
        public string fk_groupPI_code { get; set; }
        public string Group { get; set; }
        public Nullable<int> fk_list_designerEngineer { get; set; }
        public string Planner { get; set; }
        public string Easement { get; set; }
    }
}