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
    
    public partial class vw_FootprintFarms
    {
        public string MasterPlanner { get; set; }
        public string farmID { get; set; }
        public string farm_name { get; set; }
        public string fk_farmSize_code { get; set; }
        public string fk_status_code_curr { get; set; }
        public string ownerStrLF_dnd { get; set; }
        public string fullname_LF_dnd { get; set; }
        public string FarmPhone { get; set; }
        public string Address { get; set; }
        public string CityStateZip { get; set; }
        public string fk_regionWAC_code { get; set; }
        public string County { get; set; }
        public string Basin { get; set; }
        public string SubBasin { get; set; }
        public Nullable<decimal> ranking_ro { get; set; }
        public int pk_farmBusiness { get; set; }
    }
}
