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
    
    public partial class eventDateRegistrant
    {
        public int pk_eventDateRegistrant { get; set; }
        public int fk_eventDate { get; set; }
        public int fk_eventRegistrant { get; set; }
        public string paid { get; set; }
        public Nullable<decimal> payment_amt { get; set; }
        public Nullable<decimal> payment_amt_inkind { get; set; }
        public string fk_paymentVia_code { get; set; }
        public string note { get; set; }
        public string fk_mealType_code { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public Nullable<decimal> fee { get; set; }
    }
}
