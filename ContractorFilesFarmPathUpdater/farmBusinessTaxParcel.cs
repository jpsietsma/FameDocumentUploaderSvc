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
    
    public partial class farmBusinessTaxParcel
    {
        public int pk_farmBusinessTaxParcel { get; set; }
        public int fk_farmBusiness { get; set; }
        public int fk_taxParcel { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
    
        public virtual farmBusiness farmBusiness { get; set; }
        public virtual taxParcel taxParcel { get; set; }
    }
}
