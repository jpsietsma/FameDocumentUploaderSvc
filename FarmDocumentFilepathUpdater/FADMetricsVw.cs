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
    
    public partial class FADMetricsVw
    {
        public string FarmId { get; set; }
        public string CompositBmpNumber { get; set; }
        public string OriginalListBMPNumber { get; set; }
        public string OriginalFameBMPNumber { get; set; }
        public int IsBacklog { get; set; }
        public int IsRepair { get; set; }
        public int IsIRC { get; set; }
        public bool PIRCtoIRC { get; set; }
        public bool IRCtoBMP { get; set; }
        public int IsDeleted { get; set; }
        public int IsCompleted { get; set; }
        public Nullable<int> YearCreated { get; set; }
        public Nullable<int> YearCompleted { get; set; }
        public Nullable<int> YearDeleted { get; set; }
        public int IsPreCutoffNonBacklog { get; set; }
        public int IsPostCutoff { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Practice { get; set; }
        public string PollutantCategory { get; set; }
        public string AgBmpDescriptorCode { get; set; }
        public string AgBmpDescriptor { get; set; }
        public string AgBmpQualifierCode { get; set; }
        public string Qualifier { get; set; }
        public Nullable<byte> QualifierVersion { get; set; }
        public string AgBmpValidationCode { get; set; }
        public string AgBmpStatusCode { get; set; }
        public string Status { get; set; }
        public string Planner { get; set; }
        public string FarmName { get; set; }
        public string FarmStatus { get; set; }
        public string RegionCode { get; set; }
        public string Owner { get; set; }
        public string Operator { get; set; }
        public decimal PlanningEstimate { get; set; }
        public decimal DesignEstimate { get; set; }
        public decimal FinalCost { get; set; }
        public decimal TotalFunding { get; set; }
        public decimal WacFunding { get; set; }
        public decimal OtherFunding { get; set; }
        public Nullable<int> YearFundingApproved { get; set; }
        public decimal WacPayments { get; set; }
        public decimal OtherPayments { get; set; }
        public decimal TotalPayments { get; set; }
        public Nullable<int> PaymentYear { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> CompletedDate { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<System.DateTime> FinalPaymentDate { get; set; }
        public int fk_farmBusiness { get; set; }
        public int fk_bmp_ag { get; set; }
    }
}
