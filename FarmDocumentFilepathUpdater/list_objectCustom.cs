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
    
    public partial class list_objectCustom
    {
        public list_objectCustom()
        {
            this.userObjectCustom = new HashSet<userObjectCustom>();
        }
    
        public string pk_objectCustom_code { get; set; }
        public string objectName { get; set; }
    
        public virtual ICollection<userObjectCustom> userObjectCustom { get; set; }
    }
}
