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
    
    public partial class zipcode
    {
        public zipcode()
        {
            this.property = new HashSet<property>();
        }
    
        public string pk_zipcode { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public string stateType { get; set; }
    
        public virtual ICollection<property> property { get; set; }
    }
}
