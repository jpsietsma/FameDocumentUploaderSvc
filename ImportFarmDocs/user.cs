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
    
    public partial class user
    {
        public user()
        {
            this.photo = new HashSet<photo>();
            this.userObjectCustom = new HashSet<userObjectCustom>();
            this.userReportGroup = new HashSet<userReportGroup>();
            this.userRole = new HashSet<userRole>();
        }
    
        public int pk_user { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string active { get; set; }
        public string sector { get; set; }
        public string windowsUserName { get; set; }
        public string encumbrance { get; set; }
    
        public virtual ICollection<photo> photo { get; set; }
        public virtual ICollection<userObjectCustom> userObjectCustom { get; set; }
        public virtual ICollection<userReportGroup> userReportGroup { get; set; }
        public virtual ICollection<userRole> userRole { get; set; }
    }
}
