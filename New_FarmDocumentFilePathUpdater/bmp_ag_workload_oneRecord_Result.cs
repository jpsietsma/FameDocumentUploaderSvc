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
    
    public partial class bmp_ag_workload_oneRecord_Result
    {
        public Nullable<int> pk_bmp_ag_workload { get; set; }
        public Nullable<short> year { get; set; }
        public string fk_agWorkloadFunding_code { get; set; }
        public string agWorkloadFunding { get; set; }
        public string fk_statusBMPWorkload_code { get; set; }
        public string statusBMPWorkload { get; set; }
        public string fk_statusBMPWorkloadProcurement_code { get; set; }
        public string statusBMPWorkloadProcurement { get; set; }
        public string fk_agency_code { get; set; }
        public string agency { get; set; }
        public Nullable<decimal> priority { get; set; }
        public Nullable<int> priorityTech { get; set; }
        public string fk_BMPWorkloadSortGroup_code { get; set; }
        public Nullable<System.DateTime> prog_engconsult { get; set; }
        public Nullable<System.DateTime> prog_survey { get; set; }
        public Nullable<System.DateTime> prog_inProg30 { get; set; }
        public Nullable<System.DateTime> prog_inProg60 { get; set; }
        public Nullable<System.DateTime> prog_inProg90 { get; set; }
        public Nullable<System.DateTime> prog_design95 { get; set; }
        public Nullable<System.DateTime> prog_readyForBid100 { get; set; }
        public string isValidBMP { get; set; }
        public string design_est_note { get; set; }
        public string workload_project { get; set; }
        public string workload_projectCode { get; set; }
        public string FarmID { get; set; }
        public Nullable<decimal> farmRank { get; set; }
        public string fk_regionWAC_code { get; set; }
        public string ownerStr_dnd { get; set; }
        public string fk_groupPI_code { get; set; }
        public Nullable<int> fk_designerEngineer_master { get; set; }
        public string plannerMaster { get; set; }
        public Nullable<int> fk_bmp_ag { get; set; }
        public string bmp_nbr { get; set; }
        public string bmp_descrip { get; set; }
        public string fk_pollutant_category_code { get; set; }
        public string pollutant_category { get; set; }
        public Nullable<decimal> fk_BMPPractice_code { get; set; }
        public Nullable<decimal> planEstimate { get; set; }
        public Nullable<decimal> design_cost { get; set; }
        public string dimensions { get; set; }
        public string dimensions_designed { get; set; }
        public Nullable<decimal> contract_amt { get; set; }
        public string contract_amt_note { get; set; }
        public Nullable<int> pk_participant_contractor { get; set; }
        public string contractor { get; set; }
        public Nullable<decimal> fundingWAC { get; set; }
        public Nullable<decimal> subsequentFundingWAC { get; set; }
        public Nullable<decimal> paymentWAC { get; set; }
        public Nullable<decimal> paymentAWEP { get; set; }
        public Nullable<decimal> paymentCREP { get; set; }
        public Nullable<int> pk_form_wfp3 { get; set; }
        public string packageName { get; set; }
        public Nullable<System.DateTime> design_date { get; set; }
        public Nullable<System.DateTime> procurementPlan_date { get; set; }
        public Nullable<System.DateTime> outForBid_date { get; set; }
        public Nullable<System.DateTime> contract_date { get; set; }
        public Nullable<System.DateTime> construction_date { get; set; }
        public Nullable<System.DateTime> certification_date { get; set; }
        public Nullable<decimal> units_planned { get; set; }
        public Nullable<decimal> units_designed { get; set; }
        public Nullable<decimal> units_completed { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string fk_statusEasement_code { get; set; }
        public string statusEasement { get; set; }
        public string fk_easementType_code { get; set; }
        public string easementType { get; set; }
        public Nullable<int> pk_farmBusiness { get; set; }
    }
}
