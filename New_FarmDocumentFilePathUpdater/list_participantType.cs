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
    
    public partial class list_participantType
    {
        public list_participantType()
        {
            this.eventVenueType = new HashSet<eventVenueType>();
            this.list_encumbranceProgram = new HashSet<list_encumbranceProgram>();
            this.list_formsWAC = new HashSet<list_formsWAC>();
            this.list_interestType = new HashSet<list_interestType>();
            this.list_participantTypeSector = new HashSet<list_participantTypeSector>();
            this.participantNote = new HashSet<participantNote>();
            this.participantType1 = new HashSet<participantType>();
            this.propertyNote = new HashSet<propertyNote>();
        }
    
        public string pk_participantType_code { get; set; }
        public string participantType { get; set; }
        public string manageDocuments { get; set; }
    
        public virtual ICollection<eventVenueType> eventVenueType { get; set; }
        public virtual ICollection<list_encumbranceProgram> list_encumbranceProgram { get; set; }
        public virtual ICollection<list_formsWAC> list_formsWAC { get; set; }
        public virtual ICollection<list_interestType> list_interestType { get; set; }
        public virtual ICollection<list_participantTypeSector> list_participantTypeSector { get; set; }
        public virtual ICollection<participantNote> participantNote { get; set; }
        public virtual ICollection<participantType> participantType1 { get; set; }
        public virtual ICollection<propertyNote> propertyNote { get; set; }
    }
}
