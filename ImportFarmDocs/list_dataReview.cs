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
    
    public partial class list_dataReview
    {
        public list_dataReview()
        {
            this.participant = new HashSet<participant>();
        }
    
        public string pk_dataReview_code { get; set; }
        public string dataReview_status { get; set; }
    
        public virtual ICollection<participant> participant { get; set; }
    }
}
