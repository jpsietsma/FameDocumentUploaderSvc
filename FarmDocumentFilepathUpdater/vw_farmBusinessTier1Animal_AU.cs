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
    
    public partial class vw_farmBusinessTier1Animal_AU
    {
        public int pk_farmBusinessTier1 { get; set; }
        public int fk_farmBusiness { get; set; }
        public int pk_farmBusinessTier1Animal { get; set; }
        public int fk_list_animal { get; set; }
        public string farmID { get; set; }
        public string animal { get; set; }
        public Nullable<short> weight { get; set; }
        public Nullable<int> cnt { get; set; }
        public Nullable<decimal> weightTotal { get; set; }
        public Nullable<decimal> AU { get; set; }
    }
}
