//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImportFarmDocs
{
    using System;
    using System.Collections.Generic;
    
    public partial class CumulativeBmpsVw
    {
        public string CompositBmpNumber { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> CompletedDate { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public int IsRepair { get; set; }
        public int IsIRC { get; set; }
        public string AgBmpDescriptorCode { get; set; }
        public string AgBmpQualifierCode { get; set; }
        public Nullable<byte> QualifierVersion { get; set; }
        public string AgBmpValidationCode { get; set; }
        public string AgBmpStatusCode { get; set; }
        public string description { get; set; }
        public decimal Cost_Estimate { get; set; }
        public Nullable<decimal> design_cost { get; set; }
        public Nullable<decimal> final_cost { get; set; }
        public Nullable<decimal> fk_bmpPractice_code { get; set; }
        public string fk_pollutant_category_code { get; set; }
        public string fk_procurementType_code { get; set; }
        public string fk_statusBMP_code { get; set; }
        public Nullable<int> fk_programmaticRecord_code { get; set; }
        public Nullable<byte> WFP_Revision { get; set; }
        public Nullable<System.DateTime> approved_date { get; set; }
        public string Planner { get; set; }
        public string FarmId { get; set; }
        public string FarmName { get; set; }
        public string FarmStatus { get; set; }
        public string Owner { get; set; }
        public string Operator { get; set; }
        public int fk_farmBusiness { get; set; }
        public int fk_bmp_ag { get; set; }
    }
}
