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
    
    public partial class list_farmSize
    {
        public list_farmSize()
        {
            this.farmBusiness = new HashSet<farmBusiness>();
        }
    
        public string pk_farmSize_code { get; set; }
        public string farmSize { get; set; }
    
        public virtual ICollection<farmBusiness> farmBusiness { get; set; }
    }
}
