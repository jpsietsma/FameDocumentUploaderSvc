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
    
    public partial class vw_farmBusiness_tractField
    {
        public int pk_farmBusiness { get; set; }
        public string farmID { get; set; }
        public string farm_name { get; set; }
        public string ownerStrFL_dnd { get; set; }
        public string tract { get; set; }
        public string field { get; set; }
        public Nullable<decimal> acres { get; set; }
        public string active { get; set; }
        public int pk_farmLand { get; set; }
        public int pk_farmLandTract { get; set; }
        public int pk_farmLandTractField { get; set; }
    }
}