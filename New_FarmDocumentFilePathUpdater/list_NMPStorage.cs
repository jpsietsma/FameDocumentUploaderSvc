//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace New_FarmDocumentFilePathUpdater
{
    using System;
    using System.Collections.Generic;
    
    public partial class list_NMPStorage
    {
        public list_NMPStorage()
        {
            this.farmBusinessNMP = new HashSet<farmBusinessNMP>();
        }
    
        public string pk_NMPStorage_code { get; set; }
        public string storage { get; set; }
    
        public virtual ICollection<farmBusinessNMP> farmBusinessNMP { get; set; }
    }
}
