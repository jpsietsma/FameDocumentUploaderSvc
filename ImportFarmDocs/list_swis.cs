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
    
    public partial class list_swis
    {
        public list_swis()
        {
            this.property = new HashSet<property>();
            this.taxParcel = new HashSet<taxParcel>();
        }
    
        public string pk_list_swis { get; set; }
        public string county { get; set; }
        public string muniname { get; set; }
        public string munitype { get; set; }
        public string active { get; set; }
        public string jurisdiction { get; set; }
    
        public virtual ICollection<property> property { get; set; }
        public virtual ICollection<taxParcel> taxParcel { get; set; }
    }
}
