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
    
    public partial class list_asrType
    {
        public list_asrType()
        {
            this.asrAg = new HashSet<asrAg>();
        }
    
        public string pk_asrType_code { get; set; }
        public string asrType { get; set; }
    
        public virtual ICollection<asrAg> asrAg { get; set; }
    }
}
