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
    
    public partial class participantWAC_evaluation
    {
        public int pk_participantWAC_evaluation { get; set; }
        public int fk_participantWAC { get; set; }
        public string fk_positionWAC_code { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> rating { get; set; }
        public string note { get; set; }
        public Nullable<System.DateTime> followup_date { get; set; }
        public string followup_note { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string fk_fiscalYear_code { get; set; }
        public string jobDescription { get; set; }
        public string sixMonthEval { get; set; }
        public string annualEval { get; set; }
    
        public virtual list_fiscalYear list_fiscalYear { get; set; }
        public virtual list_positionWAC list_positionWAC { get; set; }
        public virtual participantWAC participantWAC { get; set; }
    }
}
