//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContractorFilesFarmPathUpdater
{
    using System;
    using System.Collections.Generic;
    
    public partial class easementStewardship
    {
        public int pk_easementStewardship { get; set; }
        public string easement_id { get; set; }
        public int fk_farmBusiness { get; set; }
        public string fk_easementSteward_code { get; set; }
        public Nullable<decimal> acres { get; set; }
        public string town { get; set; }
        public string easement_landowner_curr { get; set; }
        public string easement_grantor_orig { get; set; }
        public string DEP_id { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string fk_statusEasement_code { get; set; }
        public string taxParcelStr_ro { get; set; }
    }
}
