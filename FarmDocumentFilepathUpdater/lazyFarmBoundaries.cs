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
    
    public partial class lazyFarmBoundaries
    {
        public int pk_farmBusiness { get; set; }
        public int pk_farmLand { get; set; }
        public int pk_farmLandTract { get; set; }
        public int pk_farmLandTractField { get; set; }
        public int pk_cropware { get; set; }
        public Nullable<short> Year { get; set; }
        public string Tract { get; set; }
        public string Field { get; set; }
        public decimal Acres { get; set; }
        public string CropwareTractField { get; set; }
        public string CropwareFieldName { get; set; }
        public Nullable<decimal> CropwareAcres { get; set; }
    }
}