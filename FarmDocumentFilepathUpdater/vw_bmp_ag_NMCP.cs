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
    
    public partial class vw_bmp_ag_NMCP
    {
        public int pk_bmp_ag { get; set; }
        public int pk_farmBusiness { get; set; }
        public string fk_status_code_curr { get; set; }
        public string fk_regionWAC_code { get; set; }
        public string fk_statusBMP_code { get; set; }
        public string fk_pollutant_category_code { get; set; }
        public string bmp_nbr { get; set; }
        public string description { get; set; }
        public Nullable<short> NMCP_yr { get; set; }
        public string packageName { get; set; }
        public Nullable<System.DateTime> certification_date { get; set; }
        public System.DateTime payment_date { get; set; }
        public Nullable<decimal> amt { get; set; }
        public string purchaseNMCP { get; set; }
    }
}
