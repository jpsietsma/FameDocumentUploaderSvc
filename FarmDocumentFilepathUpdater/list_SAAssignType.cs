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
    
    public partial class list_SAAssignType
    {
        public list_SAAssignType()
        {
            this.bmp_ag = new HashSet<bmp_ag>();
            this.bmp_ag_SA = new HashSet<bmp_ag_SA>();
        }
    
        public string pk_SAAssignType_code { get; set; }
        public string type { get; set; }
    
        public virtual ICollection<bmp_ag> bmp_ag { get; set; }
        public virtual ICollection<bmp_ag_SA> bmp_ag_SA { get; set; }
    }
}
