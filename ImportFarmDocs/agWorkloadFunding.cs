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
    
    public partial class agWorkloadFunding
    {
        public int pk_agWorkloadFunding { get; set; }
        public short year { get; set; }
        public string fk_agWorkloadFunding_code { get; set; }
        public decimal amt { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
    
        public virtual list_agWorkloadFunding list_agWorkloadFunding { get; set; }
    }
}
