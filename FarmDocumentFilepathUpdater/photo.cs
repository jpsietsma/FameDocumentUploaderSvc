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
    
    public partial class photo
    {
        public int pk_photo { get; set; }
        public string fk_photoType_code { get; set; }
        public int pk_item { get; set; }
        public string item { get; set; }
        public string item2 { get; set; }
        public string photo1 { get; set; }
        public string caption { get; set; }
        public string descrip { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public Nullable<int> fk_user { get; set; }
    
        public virtual list_photoType list_photoType { get; set; }
        public virtual user user { get; set; }
    }
}
