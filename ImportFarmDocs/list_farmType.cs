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
    
    public partial class list_farmType
    {
        public list_farmType()
        {
            this.farmBusinessType = new HashSet<farmBusinessType>();
        }
    
        public string pk_farmType_code { get; set; }
        public string farmType { get; set; }
        public string SF { get; set; }
        public string LF { get; set; }
        public string EOH { get; set; }
        public string AU { get; set; }
    
        public virtual ICollection<farmBusinessType> farmBusinessType { get; set; }
    }
}
