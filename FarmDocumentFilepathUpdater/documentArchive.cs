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
    
    public partial class documentArchive
    {
        public int pk_documentArchive { get; set; }
        public int PK_1 { get; set; }
        public Nullable<int> PK_2 { get; set; }
        public Nullable<int> PK_3 { get; set; }
        public string filename_actual { get; set; }
        public string fk_participantTypeSectorFolder_code { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string filename_display { get; set; }
        public string filepath { get; set; }
    
        public virtual list_participantTypeSectorFolder list_participantTypeSectorFolder { get; set; }
    }
}
