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
    
    public partial class list_mailingType
    {
        public list_mailingType()
        {
            this.mailingDate = new HashSet<mailingDate>();
        }
    
        public string pk_mailingType_code { get; set; }
        public string type { get; set; }
    
        public virtual ICollection<mailingDate> mailingDate { get; set; }
    }
}