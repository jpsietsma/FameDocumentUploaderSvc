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
    
    public partial class list_gender
    {
        public list_gender()
        {
            this.participant = new HashSet<participant>();
        }
    
        public string pk_gender_code { get; set; }
        public string gender { get; set; }
    
        public virtual ICollection<participant> participant { get; set; }
    }
}
