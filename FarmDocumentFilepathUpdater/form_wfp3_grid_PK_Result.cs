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
    
    public partial class form_wfp3_grid_PK_Result
    {
        public string packageName { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> designed { get; set; }
        public Nullable<System.DateTime> procurementPlan { get; set; }
        public Nullable<System.DateTime> outForBid { get; set; }
        public Nullable<System.DateTime> awarded { get; set; }
        public Nullable<System.DateTime> certified { get; set; }
        public string contractor { get; set; }
        public Nullable<decimal> contract_amt { get; set; }
        public Nullable<decimal> funding { get; set; }
        public Nullable<decimal> fundingOther { get; set; }
        public Nullable<decimal> cost_est { get; set; }
        public Nullable<decimal> modification { get; set; }
        public Nullable<decimal> cost_total { get; set; }
        public Nullable<decimal> payment { get; set; }
        public Nullable<decimal> balance { get; set; }
        public Nullable<decimal> encumbered { get; set; }
        public Nullable<decimal> encumberedPending { get; set; }
        public string awarded_tooltip { get; set; }
        public Nullable<int> pk_form_wfp3 { get; set; }
        public Nullable<int> fk_participant_contractor { get; set; }
        public Nullable<int> fk_farmBusiness { get; set; }
        public string packageNameBMPs { get; set; }
    }
}
