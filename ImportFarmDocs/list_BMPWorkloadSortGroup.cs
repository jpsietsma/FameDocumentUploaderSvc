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
    
    public partial class list_BMPWorkloadSortGroup
    {
        public list_BMPWorkloadSortGroup()
        {
            this.bmp_ag_workload = new HashSet<bmp_ag_workload>();
        }
    
        public string pk_BMPWorkloadSortGroup_code { get; set; }
        public string sortGroup { get; set; }
    
        public virtual ICollection<bmp_ag_workload> bmp_ag_workload { get; set; }
    }
}