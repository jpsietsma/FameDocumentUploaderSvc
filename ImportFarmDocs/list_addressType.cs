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
    
    public partial class list_addressType
    {
        public list_addressType()
        {
            this.property = new HashSet<property>();
        }
    
        public string pk_addressType_code { get; set; }
        public string type { get; set; }
    
        public virtual ICollection<property> property { get; set; }
    }
}