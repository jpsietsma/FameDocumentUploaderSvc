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
    
    public partial class CurrentBmpStatusVw
    {
        public int pk_bmp_ag_status { get; set; }
        public int fk_bmp_ag { get; set; }
        public string StatusCode { get; set; }
        public string Status { get; set; }
        public System.DateTime StatusDate { get; set; }
    }
}
