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
    
    public partial class list_designerEngineerUsage
    {
        public int pk_list_designerEngineerUsage { get; set; }
        public int fk_list_designerEngineer { get; set; }
        public string fk_designerEngineerType_code { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
    
        public virtual list_designerEngineer list_designerEngineer { get; set; }
        public virtual list_designerEngineerType list_designerEngineerType { get; set; }
    }
}
