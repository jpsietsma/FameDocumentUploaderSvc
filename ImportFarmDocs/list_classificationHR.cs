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
    
    public partial class list_classificationHR
    {
        public list_classificationHR()
        {
            this.list_positionWAC = new HashSet<list_positionWAC>();
        }
    
        public string pk_classificationHR_code { get; set; }
        public string classification { get; set; }
    
        public virtual ICollection<list_positionWAC> list_positionWAC { get; set; }
    }
}