//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace New_FarmDocumentFilePathUpdater
{
    using System;
    using System.Collections.Generic;
    
    public partial class mailingDate
    {
        public mailingDate()
        {
            this.mailingDateRSVP = new HashSet<mailingDateRSVP>();
            this.mailingSentTo = new HashSet<mailingSentTo>();
        }
    
        public int pk_mailingDate { get; set; }
        public int fk_mailing { get; set; }
        public System.DateTime dateSent { get; set; }
        public string fk_mailingType_code { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string note { get; set; }
        public Nullable<int> maxAttend { get; set; }
    
        public virtual list_mailingType list_mailingType { get; set; }
        public virtual mailing mailing { get; set; }
        public virtual ICollection<mailingDateRSVP> mailingDateRSVP { get; set; }
        public virtual ICollection<mailingSentTo> mailingSentTo { get; set; }
    }
}
