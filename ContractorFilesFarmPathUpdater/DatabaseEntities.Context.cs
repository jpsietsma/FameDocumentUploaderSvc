﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BmpBacklog> BmpBacklog { get; set; }
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<advisoryMsg> advisoryMsg { get; set; }
        public virtual DbSet<agWorkloadFunding> agWorkloadFunding { get; set; }
        public virtual DbSet<asrAg> asrAg { get; set; }
        public virtual DbSet<asrAg_bmp> asrAg_bmp { get; set; }
        public virtual DbSet<asrAg_changes> asrAg_changes { get; set; }
        public virtual DbSet<asrAg_QMA> asrAg_QMA { get; set; }
        public virtual DbSet<bmp_ag> bmp_ag { get; set; }
        public virtual DbSet<bmp_ag_encumbrance> bmp_ag_encumbrance { get; set; }
        public virtual DbSet<bmp_ag_funding> bmp_ag_funding { get; set; }
        public virtual DbSet<bmp_ag_leasedLand> bmp_ag_leasedLand { get; set; }
        public virtual DbSet<bmp_ag_location> bmp_ag_location { get; set; }
        public virtual DbSet<bmp_ag_nmcp> bmp_ag_nmcp { get; set; }
        public virtual DbSet<bmp_ag_note> bmp_ag_note { get; set; }
        public virtual DbSet<bmp_ag_SA> bmp_ag_SA { get; set; }
        public virtual DbSet<bmp_ag_status> bmp_ag_status { get; set; }
        public virtual DbSet<bmp_ag_subIssue> bmp_ag_subIssue { get; set; }
        public virtual DbSet<bmp_ag_workload> bmp_ag_workload { get; set; }
        public virtual DbSet<bmp_ag_workloadSupport> bmp_ag_workloadSupport { get; set; }
        public virtual DbSet<communication> communication { get; set; }
        public virtual DbSet<contactWAC> contactWAC { get; set; }
        public virtual DbSet<cropware> cropware { get; set; }
        public virtual DbSet<cropwareRetain> cropwareRetain { get; set; }
        public virtual DbSet<documentArchive> documentArchive { get; set; }
        public virtual DbSet<errorMsg> errorMsg { get; set; }
        public virtual DbSet<@event> @event { get; set; }
        public virtual DbSet<eventDate> eventDate { get; set; }
        public virtual DbSet<eventDateAttendance> eventDateAttendance { get; set; }
        public virtual DbSet<eventName> eventName { get; set; }
        public virtual DbSet<eventRegistrant> eventRegistrant { get; set; }
        public virtual DbSet<eventVenue> eventVenue { get; set; }
        public virtual DbSet<eventVenueType> eventVenueType { get; set; }
        public virtual DbSet<farmBusiness> farmBusiness { get; set; }
        public virtual DbSet<farmBusinessAnimal> farmBusinessAnimal { get; set; }
        public virtual DbSet<farmBusinessAnimal2008> farmBusinessAnimal2008 { get; set; }
        public virtual DbSet<farmBusinessAnimalAge> farmBusinessAnimalAge { get; set; }
        public virtual DbSet<farmBusinessASR> farmBusinessASR { get; set; }
        public virtual DbSet<farmBusinessContact> farmBusinessContact { get; set; }
        public virtual DbSet<farmBusinessCREP> farmBusinessCREP { get; set; }
        public virtual DbSet<farmBusinessFAD> farmBusinessFAD { get; set; }
        public virtual DbSet<farmBusinessLandBaseInfo> farmBusinessLandBaseInfo { get; set; }
        public virtual DbSet<farmBusinessMail> farmBusinessMail { get; set; }
        public virtual DbSet<farmBusinessNMCP> farmBusinessNMCP { get; set; }
        public virtual DbSet<farmBusinessNMP> farmBusinessNMP { get; set; }
        public virtual DbSet<farmBusinessNote> farmBusinessNote { get; set; }
        public virtual DbSet<farmBusinessOperator> farmBusinessOperator { get; set; }
        public virtual DbSet<farmBusinessOwner> farmBusinessOwner { get; set; }
        public virtual DbSet<farmBusinessPlanner> farmBusinessPlanner { get; set; }
        public virtual DbSet<farmBusinessQMA> farmBusinessQMA { get; set; }
        public virtual DbSet<farmBusinessQMATech> farmBusinessQMATech { get; set; }
        public virtual DbSet<farmBusinessQMAVisit> farmBusinessQMAVisit { get; set; }
        public virtual DbSet<farmBusinessRevisionReqd> farmBusinessRevisionReqd { get; set; }
        public virtual DbSet<farmBusinessRevisionReqdSupport> farmBusinessRevisionReqdSupport { get; set; }
        public virtual DbSet<farmBusinessStatus> farmBusinessStatus { get; set; }
        public virtual DbSet<farmBusinessTaxParcel> farmBusinessTaxParcel { get; set; }
        public virtual DbSet<farmBusinessTier1> farmBusinessTier1 { get; set; }
        public virtual DbSet<farmBusinessTier1Animal> farmBusinessTier1Animal { get; set; }
        public virtual DbSet<farmBusinessType> farmBusinessType { get; set; }
        public virtual DbSet<farmBusinessWLProject> farmBusinessWLProject { get; set; }
        public virtual DbSet<farmBusinessWLProjectBMP> farmBusinessWLProjectBMP { get; set; }
        public virtual DbSet<farmLand> farmLand { get; set; }
        public virtual DbSet<farmLandTract> farmLandTract { get; set; }
        public virtual DbSet<farmLandTractField> farmLandTractField { get; set; }
        public virtual DbSet<form_wfp2> form_wfp2 { get; set; }
        public virtual DbSet<form_wfp2_version> form_wfp2_version { get; set; }
        public virtual DbSet<form_wfp2_version_tech> form_wfp2_version_tech { get; set; }
        public virtual DbSet<form_wfp3> form_wfp3 { get; set; }
        public virtual DbSet<form_wfp3_bid> form_wfp3_bid { get; set; }
        public virtual DbSet<form_wfp3_bmp> form_wfp3_bmp { get; set; }
        public virtual DbSet<form_wfp3_encumbrance> form_wfp3_encumbrance { get; set; }
        public virtual DbSet<form_wfp3_invoice> form_wfp3_invoice { get; set; }
        public virtual DbSet<form_wfp3_modification> form_wfp3_modification { get; set; }
        public virtual DbSet<form_wfp3_payment> form_wfp3_payment { get; set; }
        public virtual DbSet<form_wfp3_paymentBMP> form_wfp3_paymentBMP { get; set; }
        public virtual DbSet<form_wfp3_specification> form_wfp3_specification { get; set; }
        public virtual DbSet<form_wfp3_tech> form_wfp3_tech { get; set; }
        public virtual DbSet<list_address2Type> list_address2Type { get; set; }
        public virtual DbSet<list_addressType> list_addressType { get; set; }
        public virtual DbSet<list_agency> list_agency { get; set; }
        public virtual DbSet<list_agencyCoop> list_agencyCoop { get; set; }
        public virtual DbSet<list_agencyCoopBMP> list_agencyCoopBMP { get; set; }
        public virtual DbSet<list_agencyFunding> list_agencyFunding { get; set; }
        public virtual DbSet<list_agWorkloadFunding> list_agWorkloadFunding { get; set; }
        public virtual DbSet<list_alphaNumeric> list_alphaNumeric { get; set; }
        public virtual DbSet<list_AMLPriority> list_AMLPriority { get; set; }
        public virtual DbSet<list_animal> list_animal { get; set; }
        public virtual DbSet<list_animalAge> list_animalAge { get; set; }
        public virtual DbSet<list_animalTier1> list_animalTier1 { get; set; }
        public virtual DbSet<list_applicantSource> list_applicantSource { get; set; }
        public virtual DbSet<list_asrAgChanges> list_asrAgChanges { get; set; }
        public virtual DbSet<list_asrType> list_asrType { get; set; }
        public virtual DbSet<list_basin> list_basin { get; set; }
        public virtual DbSet<list_basinCounty> list_basinCounty { get; set; }
        public virtual DbSet<list_BMPCode> list_BMPCode { get; set; }
        public virtual DbSet<list_BMPCREPH20> list_BMPCREPH20 { get; set; }
        public virtual DbSet<list_bmpPractice> list_bmpPractice { get; set; }
        public virtual DbSet<list_bmpPriority> list_bmpPriority { get; set; }
        public virtual DbSet<list_BMPSource> list_BMPSource { get; set; }
        public virtual DbSet<list_bmpStatus2006> list_bmpStatus2006 { get; set; }
        public virtual DbSet<list_BMPTypeCode> list_BMPTypeCode { get; set; }
        public virtual DbSet<list_BMPWorkloadSortGroup> list_BMPWorkloadSortGroup { get; set; }
        public virtual DbSet<list_BMPWorkloadSupport> list_BMPWorkloadSupport { get; set; }
        public virtual DbSet<list_character> list_character { get; set; }
        public virtual DbSet<list_classificationHR> list_classificationHR { get; set; }
        public virtual DbSet<list_cnt> list_cnt { get; set; }
        public virtual DbSet<list_communicationType> list_communicationType { get; set; }
        public virtual DbSet<list_communicationUsage> list_communicationUsage { get; set; }
        public virtual DbSet<list_contractorType> list_contractorType { get; set; }
        public virtual DbSet<list_county> list_county { get; set; }
        public virtual DbSet<list_countyNY> list_countyNY { get; set; }
        public virtual DbSet<list_countyNYBasin> list_countyNYBasin { get; set; }
        public virtual DbSet<list_cryptoShedding> list_cryptoShedding { get; set; }
        public virtual DbSet<list_dataReview> list_dataReview { get; set; }
        public virtual DbSet<list_dataSector> list_dataSector { get; set; }
        public virtual DbSet<list_dateFormat> list_dateFormat { get; set; }
        public virtual DbSet<list_designerEngineer> list_designerEngineer { get; set; }
        public virtual DbSet<list_designerEngineerType> list_designerEngineerType { get; set; }
        public virtual DbSet<list_designerEngineerUsage> list_designerEngineerUsage { get; set; }
        public virtual DbSet<list_diversityData> list_diversityData { get; set; }
        public virtual DbSet<list_easementSteward> list_easementSteward { get; set; }
        public virtual DbSet<list_easementType> list_easementType { get; set; }
        public virtual DbSet<list_EEO> list_EEO { get; set; }
        public virtual DbSet<list_employeeRelationship> list_employeeRelationship { get; set; }
        public virtual DbSet<list_encumbrance> list_encumbrance { get; set; }
        public virtual DbSet<list_encumbranceProgram> list_encumbranceProgram { get; set; }
        public virtual DbSet<list_encumbranceType> list_encumbranceType { get; set; }
        public virtual DbSet<list_environmentalImpact> list_environmentalImpact { get; set; }
        public virtual DbSet<list_ethnicity> list_ethnicity { get; set; }
        public virtual DbSet<list_eventRegistrantType> list_eventRegistrantType { get; set; }
        public virtual DbSet<list_eventSponsor> list_eventSponsor { get; set; }
        public virtual DbSet<list_FAD> list_FAD { get; set; }
        public virtual DbSet<list_farmBusinessNoteType> list_farmBusinessNoteType { get; set; }
        public virtual DbSet<list_farmIncome> list_farmIncome { get; set; }
        public virtual DbSet<list_farmSize> list_farmSize { get; set; }
        public virtual DbSet<list_farmType> list_farmType { get; set; }
        public virtual DbSet<list_fiscalYear> list_fiscalYear { get; set; }
        public virtual DbSet<list_followupNMP> list_followupNMP { get; set; }
        public virtual DbSet<list_forestryCode> list_forestryCode { get; set; }
        public virtual DbSet<list_formsWAC> list_formsWAC { get; set; }
        public virtual DbSet<list_formWFP3_fixedText> list_formWFP3_fixedText { get; set; }
        public virtual DbSet<list_fundingPurpose> list_fundingPurpose { get; set; }
        public virtual DbSet<list_fundingSource> list_fundingSource { get; set; }
        public virtual DbSet<list_fundingSourceForestry> list_fundingSourceForestry { get; set; }
        public virtual DbSet<list_gender> list_gender { get; set; }
        public virtual DbSet<list_groupPI> list_groupPI { get; set; }
        public virtual DbSet<list_groupPIMember> list_groupPIMember { get; set; }
        public virtual DbSet<list_implementationStatusBMP> list_implementationStatusBMP { get; set; }
        public virtual DbSet<list_interest> list_interest { get; set; }
        public virtual DbSet<list_interestBase> list_interestBase { get; set; }
        public virtual DbSet<list_interestType> list_interestType { get; set; }
        public virtual DbSet<list_ipcMode> list_ipcMode { get; set; }
        public virtual DbSet<list_ipcPlant> list_ipcPlant { get; set; }
        public virtual DbSet<list_letter> list_letter { get; set; }
        public virtual DbSet<list_lifespan> list_lifespan { get; set; }
        public virtual DbSet<list_locationOrg> list_locationOrg { get; set; }
        public virtual DbSet<list_mailingPref> list_mailingPref { get; set; }
        public virtual DbSet<list_mailingStatus> list_mailingStatus { get; set; }
        public virtual DbSet<list_mailingType> list_mailingType { get; set; }
        public virtual DbSet<list_maritalStatus> list_maritalStatus { get; set; }
        public virtual DbSet<list_mealType> list_mealType { get; set; }
        public virtual DbSet<list_mentor> list_mentor { get; set; }
        public virtual DbSet<list_month> list_month { get; set; }
        public virtual DbSet<list_NMCPType> list_NMCPType { get; set; }
        public virtual DbSet<list_NMPStorage> list_NMPStorage { get; set; }
        public virtual DbSet<list_nrcs_code> list_nrcs_code { get; set; }
        public virtual DbSet<list_NWD> list_NWD { get; set; }
        public virtual DbSet<list_objectCustom> list_objectCustom { get; set; }
        public virtual DbSet<list_ownership> list_ownership { get; set; }
        public virtual DbSet<list_participantType> list_participantType { get; set; }
        public virtual DbSet<list_participantTypeSector> list_participantTypeSector { get; set; }
        public virtual DbSet<list_participantTypeSectorFolder> list_participantTypeSectorFolder { get; set; }
        public virtual DbSet<list_paymentPhase> list_paymentPhase { get; set; }
        public virtual DbSet<list_paymentStatus> list_paymentStatus { get; set; }
        public virtual DbSet<list_paymentVia> list_paymentVia { get; set; }
        public virtual DbSet<list_phoneWAC> list_phoneWAC { get; set; }
        public virtual DbSet<list_phosphorousLevel> list_phosphorousLevel { get; set; }
        public virtual DbSet<list_photoType> list_photoType { get; set; }
        public virtual DbSet<list_planner> list_planner { get; set; }
        public virtual DbSet<list_pollutant_category> list_pollutant_category { get; set; }
        public virtual DbSet<list_positionWAC> list_positionWAC { get; set; }
        public virtual DbSet<list_prefix> list_prefix { get; set; }
        public virtual DbSet<list_procurementType> list_procurementType { get; set; }
        public virtual DbSet<list_productTier1> list_productTier1 { get; set; }
        public virtual DbSet<list_programmaticRecord> list_programmaticRecord { get; set; }
        public virtual DbSet<list_programWAC> list_programWAC { get; set; }
        public virtual DbSet<list_purposeTier1> list_purposeTier1 { get; set; }
        public virtual DbSet<list_QMAType> list_QMAType { get; set; }
        public virtual DbSet<list_QMAVisitType> list_QMAVisitType { get; set; }
        public virtual DbSet<list_qtr> list_qtr { get; set; }
        public virtual DbSet<list_race> list_race { get; set; }
        public virtual DbSet<list_rangeType> list_rangeType { get; set; }
        public virtual DbSet<list_rangeTypeMinMax> list_rangeTypeMinMax { get; set; }
        public virtual DbSet<list_regionDEC> list_regionDEC { get; set; }
        public virtual DbSet<list_regionWAC> list_regionWAC { get; set; }
        public virtual DbSet<list_reportGroup> list_reportGroup { get; set; }
        public virtual DbSet<list_revisionDescription> list_revisionDescription { get; set; }
        public virtual DbSet<list_role> list_role { get; set; }
        public virtual DbSet<list_SAAssignType> list_SAAssignType { get; set; }
        public virtual DbSet<list_schoolLevel> list_schoolLevel { get; set; }
        public virtual DbSet<list_sectorHR> list_sectorHR { get; set; }
        public virtual DbSet<list_sectorWAC> list_sectorWAC { get; set; }
        public virtual DbSet<list_sisterAgencyTitle> list_sisterAgencyTitle { get; set; }
        public virtual DbSet<list_status> list_status { get; set; }
        public virtual DbSet<list_statusBMP> list_statusBMP { get; set; }
        public virtual DbSet<list_statusBMPWorkload> list_statusBMPWorkload { get; set; }
        public virtual DbSet<list_statusBMPWorkloadProcurement> list_statusBMPWorkloadProcurement { get; set; }
        public virtual DbSet<list_statusChangeTier1> list_statusChangeTier1 { get; set; }
        public virtual DbSet<list_statusEasement> list_statusEasement { get; set; }
        public virtual DbSet<list_subbasin> list_subbasin { get; set; }
        public virtual DbSet<list_suffix> list_suffix { get; set; }
        public virtual DbSet<list_swis> list_swis { get; set; }
        public virtual DbSet<list_taxParcelType> list_taxParcelType { get; set; }
        public virtual DbSet<list_telecommuteSchedule> list_telecommuteSchedule { get; set; }
        public virtual DbSet<list_tourType> list_tourType { get; set; }
        public virtual DbSet<list_township> list_township { get; set; }
        public virtual DbSet<list_townshipNY> list_townshipNY { get; set; }
        public virtual DbSet<list_trainingCost> list_trainingCost { get; set; }
        public virtual DbSet<list_trainingReqd> list_trainingReqd { get; set; }
        public virtual DbSet<list_trainingReqdPositionWAC> list_trainingReqdPositionWAC { get; set; }
        public virtual DbSet<list_unit> list_unit { get; set; }
        public virtual DbSet<list_useArea> list_useArea { get; set; }
        public virtual DbSet<list_usps_abbr> list_usps_abbr { get; set; }
        public virtual DbSet<list_wac_code> list_wac_code { get; set; }
        public virtual DbSet<list_wacLocation> list_wacLocation { get; set; }
        public virtual DbSet<list_wacPracticeCategory> list_wacPracticeCategory { get; set; }
        public virtual DbSet<list_WFP2ApprovedBy> list_WFP2ApprovedBy { get; set; }
        public virtual DbSet<list_workloadNotation> list_workloadNotation { get; set; }
        public virtual DbSet<list_year> list_year { get; set; }
        public virtual DbSet<list_YN> list_YN { get; set; }
        public virtual DbSet<mailing> mailing { get; set; }
        public virtual DbSet<mailingDate> mailingDate { get; set; }
        public virtual DbSet<mailingDateRSVP> mailingDateRSVP { get; set; }
        public virtual DbSet<mailingDateRSVPAttendee> mailingDateRSVPAttendee { get; set; }
        public virtual DbSet<mailingParticipant> mailingParticipant { get; set; }
        public virtual DbSet<mailingSentTo> mailingSentTo { get; set; }
        public virtual DbSet<organization> organization { get; set; }
        public virtual DbSet<organizationNote> organizationNote { get; set; }
        public virtual DbSet<participant> participant { get; set; }
        public virtual DbSet<participant_lnameDuplicates_ignore> participant_lnameDuplicates_ignore { get; set; }
        public virtual DbSet<participantAddressAddl> participantAddressAddl { get; set; }
        public virtual DbSet<participantCommunication> participantCommunication { get; set; }
        public virtual DbSet<participantContractor> participantContractor { get; set; }
        public virtual DbSet<participantContractor_vendex> participantContractor_vendex { get; set; }
        public virtual DbSet<participantContractorType> participantContractorType { get; set; }
        public virtual DbSet<participantForestryType> participantForestryType { get; set; }
        public virtual DbSet<participantInterest> participantInterest { get; set; }
        public virtual DbSet<participantLegacyID> participantLegacyID { get; set; }
        public virtual DbSet<participantNote> participantNote { get; set; }
        public virtual DbSet<participantOrganization> participantOrganization { get; set; }
        public virtual DbSet<participantProperty> participantProperty { get; set; }
        public virtual DbSet<participantType> participantType { get; set; }
        public virtual DbSet<participantWAC> participantWAC { get; set; }
        public virtual DbSet<participantWAC_activity> participantWAC_activity { get; set; }
        public virtual DbSet<participantWAC_activityCost> participantWAC_activityCost { get; set; }
        public virtual DbSet<participantWAC_evaluation> participantWAC_evaluation { get; set; }
        public virtual DbSet<participantWAC_note> participantWAC_note { get; set; }
        public virtual DbSet<participantWAC_phone> participantWAC_phone { get; set; }
        public virtual DbSet<participantWAC_position> participantWAC_position { get; set; }
        public virtual DbSet<participantWAC_training> participantWAC_training { get; set; }
        public virtual DbSet<participantWAC_trainingCost> participantWAC_trainingCost { get; set; }
        public virtual DbSet<photo> photo { get; set; }
        public virtual DbSet<property> property { get; set; }
        public virtual DbSet<propertyNote> propertyNote { get; set; }
        public virtual DbSet<supplementalAgreement> supplementalAgreement { get; set; }
        public virtual DbSet<supplementalAgreementNote> supplementalAgreementNote { get; set; }
        public virtual DbSet<supplementalAgreementTaxParcel> supplementalAgreementTaxParcel { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<taxParcel> taxParcel { get; set; }
        public virtual DbSet<taxParcelOwner> taxParcelOwner { get; set; }
        public virtual DbSet<taxParcelReference> taxParcelReference { get; set; }
        public virtual DbSet<taxParcelReference_farmID> taxParcelReference_farmID { get; set; }
        public virtual DbSet<testFameUploads> testFameUploads { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<userObjectCustom> userObjectCustom { get; set; }
        public virtual DbSet<userReportGroup> userReportGroup { get; set; }
        public virtual DbSet<userRole> userRole { get; set; }
        public virtual DbSet<userRoleObject> userRoleObject { get; set; }
        public virtual DbSet<var> var { get; set; }
        public virtual DbSet<webScreen> webScreen { get; set; }
        public virtual DbSet<zipcode> zipcode { get; set; }
        public virtual DbSet<TaxParcel1> TaxParcel1 { get; set; }
        public virtual DbSet<FarmFarmBusinessLink> FarmFarmBusinessLink { get; set; }
        public virtual DbSet<AgBmpBacklogStatusCode> AgBmpBacklogStatusCode { get; set; }
        public virtual DbSet<AgBmpDescriptorCode> AgBmpDescriptorCode { get; set; }
        public virtual DbSet<AgBmpQualifierCode> AgBmpQualifierCode { get; set; }
        public virtual DbSet<AgBmpTypeCode> AgBmpTypeCode { get; set; }
        public virtual DbSet<AgBmpViabilityCode> AgBmpViabilityCode { get; set; }
        public virtual DbSet<BmpAncestry> BmpAncestry { get; set; }
        public virtual DbSet<bmpbacklogbackup> bmpbacklogbackup { get; set; }
        public virtual DbSet<address> address { get; set; }
        public virtual DbSet<duplicatesignore> duplicatesignore { get; set; }
        public virtual DbSet<easementStewardship> easementStewardship { get; set; }
        public virtual DbSet<eventDateRegistrant> eventDateRegistrant { get; set; }
        public virtual DbSet<farmBusinessPriorOwner> farmBusinessPriorOwner { get; set; }
        public virtual DbSet<list_NMPlanType> list_NMPlanType { get; set; }
        public virtual DbSet<SQLProgramUsage> SQLProgramUsage { get; set; }
        public virtual DbSet<tempDefault> tempDefault { get; set; }
        public virtual DbSet<bmpAgAddExpressIntab> bmpAgAddExpressIntab { get; set; }
        public virtual DbSet<nmtCropwareResults> nmtCropwareResults { get; set; }
        public virtual DbSet<bmp_ag_location1> bmp_ag_location1 { get; set; }
        public virtual DbSet<bmp_ag_nmcp1> bmp_ag_nmcp1 { get; set; }
        public virtual DbSet<property1> property1 { get; set; }
    }
}
