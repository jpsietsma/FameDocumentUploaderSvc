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
    
    public partial class list_photoType
    {
        public list_photoType()
        {
            this.photo = new HashSet<photo>();
        }
    
        public string pk_photoType_code { get; set; }
        public string type { get; set; }
    
        public virtual list_photoType list_photoType1 { get; set; }
        public virtual list_photoType list_photoType2 { get; set; }
        public virtual list_photoType list_photoType11 { get; set; }
        public virtual list_photoType list_photoType3 { get; set; }
        public virtual ICollection<photo> photo { get; set; }
    }
}
