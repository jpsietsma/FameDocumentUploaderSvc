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
    
    public partial class list_interestType
    {
        public list_interestType()
        {
            this.participantInterest = new HashSet<participantInterest>();
        }
    
        public int pk_list_interestType { get; set; }
        public int fk_list_interest { get; set; }
        public string fk_participantType_code { get; set; }
    
        public virtual list_interest list_interest { get; set; }
        public virtual list_participantType list_participantType { get; set; }
        public virtual ICollection<participantInterest> participantInterest { get; set; }
    }
}