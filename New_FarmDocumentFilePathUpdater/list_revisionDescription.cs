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
    
    public partial class list_revisionDescription
    {
        public list_revisionDescription()
        {
            this.bmp_ag = new HashSet<bmp_ag>();
        }
    
        public string pk_revisionDescription_code { get; set; }
        public string description { get; set; }
        public string active { get; set; }
    
        public virtual ICollection<bmp_ag> bmp_ag { get; set; }
    }
}