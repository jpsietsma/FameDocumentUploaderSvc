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
    
    public partial class list_rangeTypeMinMax
    {
        public int pk_list_rangeTypeMinMax { get; set; }
        public string fk_rangeType_code { get; set; }
        public string descriptor { get; set; }
        public string min { get; set; }
        public string max { get; set; }
    
        public virtual list_rangeType list_rangeType { get; set; }
    }
}
