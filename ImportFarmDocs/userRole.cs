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
    
    public partial class userRole
    {
        public userRole()
        {
            this.userRoleObject = new HashSet<userRoleObject>();
        }
    
        public int pk_userRole { get; set; }
        public int fk_user { get; set; }
        public string fk_role_code { get; set; }
    
        public virtual list_role list_role { get; set; }
        public virtual user user { get; set; }
        public virtual ICollection<userRoleObject> userRoleObject { get; set; }
    }
}
