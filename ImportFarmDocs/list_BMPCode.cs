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
    
    public partial class list_BMPCode
    {
        public list_BMPCode()
        {
            this.bmp_ag = new HashSet<bmp_ag>();
        }
    
        public string pk_BMPCode_code { get; set; }
        public string code { get; set; }
        public Nullable<int> priority { get; set; }
        public Nullable<bool> IsDisabled { get; set; }
    
        public virtual ICollection<bmp_ag> bmp_ag { get; set; }
    }
}
