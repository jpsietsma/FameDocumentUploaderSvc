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
    
    public partial class userReportGroup
    {
        public int pk_userReportGroup { get; set; }
        public int fk_user { get; set; }
        public string fk_reportGroup_code { get; set; }
    
        public virtual list_reportGroup list_reportGroup { get; set; }
        public virtual user user { get; set; }
    }
}
