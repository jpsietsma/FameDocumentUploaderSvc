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
    
    public partial class farmBusinessQMATech
    {
        public int pk_farmBusinessQMATech { get; set; }
        public int fk_farmBusinessQMA { get; set; }
        public Nullable<int> fk_list_designerEngineer { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string master { get; set; }
    
        public virtual farmBusinessQMA farmBusinessQMA { get; set; }
        public virtual list_designerEngineer list_designerEngineer { get; set; }
    }
}
