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
    
    public partial class list_subbasin
    {
        public list_subbasin()
        {
            this.property = new HashSet<property>();
        }
    
        public string pk_subbasin_code { get; set; }
        public string subbasin { get; set; }
        public string basin { get; set; }
    
        public virtual ICollection<property> property { get; set; }
    }
}
