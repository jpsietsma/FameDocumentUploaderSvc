//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FarmDocumentFilepathUpdater
{
    using System;
    using System.Collections.Generic;
    
    public partial class list_FAD
    {
        public list_FAD()
        {
            this.farmBusinessFAD = new HashSet<farmBusinessFAD>();
        }
    
        public string pk_FAD_code { get; set; }
        public string setting { get; set; }
    
        public virtual ICollection<farmBusinessFAD> farmBusinessFAD { get; set; }
    }
}
