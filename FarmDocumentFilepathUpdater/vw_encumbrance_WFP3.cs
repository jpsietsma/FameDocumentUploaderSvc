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
    
    public partial class vw_encumbrance_WFP3
    {
        public string packageName { get; set; }
        public string fk_encumbrance_code { get; set; }
        public string encumbrance { get; set; }
        public System.DateTime date { get; set; }
        public decimal amt { get; set; }
        public string encumbrance_id { get; set; }
        public Nullable<System.DateTime> approved { get; set; }
        public string fk_encumbranceType_code { get; set; }
        public string note { get; set; }
        public string farmID { get; set; }
        public string ownerStr_dnd { get; set; }
        public int pk_form_wfp3_encumbrance { get; set; }
        public int pk_farmBusiness { get; set; }
        public int pk_form_wfp3 { get; set; }
        public string contractorStr_dnd { get; set; }
    }
}
