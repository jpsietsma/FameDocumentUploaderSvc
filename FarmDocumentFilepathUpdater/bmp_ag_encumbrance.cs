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
    
    public partial class bmp_ag_encumbrance
    {
        public int pk_bmp_ag_encumbrance { get; set; }
        public int fk_bmp_ag { get; set; }
        public string fk_encumbrance_code { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
    
        public virtual bmp_ag bmp_ag { get; set; }
        public virtual list_encumbrance list_encumbrance { get; set; }
    }
}
