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
    
    public partial class list_address2Type
    {
        public list_address2Type()
        {
            this.property = new HashSet<property>();
        }
    
        public string pk_address2Type_code { get; set; }
        public string longname { get; set; }
    
        public virtual ICollection<property> property { get; set; }
    }
}