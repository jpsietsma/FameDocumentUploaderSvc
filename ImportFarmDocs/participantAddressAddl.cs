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
    
    public partial class participantAddressAddl
    {
        public int pk_participantAddressAddl { get; set; }
        public int fk_participant { get; set; }
        public string address { get; set; }
        public string addr2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string zip4 { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
    }
}
