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
    
    public partial class list_role
    {
        public list_role()
        {
            this.userRole = new HashSet<userRole>();
        }
    
        public string pk_role_code { get; set; }
        public string role { get; set; }
    
        public virtual ICollection<userRole> userRole { get; set; }
    }
}
