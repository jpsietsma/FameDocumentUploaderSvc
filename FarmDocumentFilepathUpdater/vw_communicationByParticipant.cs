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
    
    public partial class vw_communicationByParticipant
    {
        public int pk_communication { get; set; }
        public int pk_participantCommunication { get; set; }
        public int pk_participant { get; set; }
        public string pk_communicationType_code { get; set; }
        public string pk_communicationUsage_code { get; set; }
        public string areacode { get; set; }
        public string number { get; set; }
        public string fullname_FL_dnd { get; set; }
        public string fullname_LF_dnd { get; set; }
        public string type { get; set; }
        public string usage { get; set; }
        public string Phone_Formatted { get; set; }
    }
}
