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
    
    public partial class vw_wfp3_bmp
    {
        public string Farm_No_ { get; set; }
        public string Farm_Listing { get; set; }
        public string BMP_No_ { get; set; }
        public string BMP_Name { get; set; }
        public Nullable<decimal> Units_Planned_WFP2 { get; set; }
        public decimal Approved_Funding { get; set; }
        public decimal Units_Designed { get; set; }
        public decimal Total_Design_Cost { get; set; }
        public Nullable<decimal> Estimated_Cost_Unit { get; set; }
        public string Life_Span { get; set; }
        public int pk_form_wfp3 { get; set; }
        public int pk_bmp_ag { get; set; }
    }
}
