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
    
    public partial class list_paymentStatus
    {
        public list_paymentStatus()
        {
            this.form_wfp3_paymentBMP = new HashSet<form_wfp3_paymentBMP>();
        }
    
        public string pk_paymentStatus_code { get; set; }
        public string status { get; set; }
    
        public virtual ICollection<form_wfp3_paymentBMP> form_wfp3_paymentBMP { get; set; }
    }
}
