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
    
    public partial class list_interestBase
    {
        public list_interestBase()
        {
            this.list_interest = new HashSet<list_interest>();
        }
    
        public string pk_interestBase_code { get; set; }
        public string @base { get; set; }
    
        public virtual ICollection<list_interest> list_interest { get; set; }
    }
}
