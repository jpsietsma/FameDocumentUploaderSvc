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
    
    public partial class participant
    {
        public participant()
        {
            this.eventRegistrant = new HashSet<eventRegistrant>();
            this.farmBusinessContact = new HashSet<farmBusinessContact>();
            this.farmBusinessMail = new HashSet<farmBusinessMail>();
            this.farmBusinessOperator = new HashSet<farmBusinessOperator>();
            this.farmBusinessOwner = new HashSet<farmBusinessOwner>();
            this.form_wfp3_bid = new HashSet<form_wfp3_bid>();
            this.form_wfp3_payment = new HashSet<form_wfp3_payment>();
            this.mailingParticipant = new HashSet<mailingParticipant>();
            this.mailingSentTo = new HashSet<mailingSentTo>();
            this.organization = new HashSet<organization>();
            this.participantCommunication = new HashSet<participantCommunication>();
            this.participantContractor = new HashSet<participantContractor>();
            this.participantForestryType = new HashSet<participantForestryType>();
            this.participantInterest = new HashSet<participantInterest>();
            this.participantLegacyID = new HashSet<participantLegacyID>();
            this.participantNote = new HashSet<participantNote>();
            this.participantOrganization = new HashSet<participantOrganization>();
            this.participantProperty = new HashSet<participantProperty>();
            this.participantProperty1 = new HashSet<participantProperty>();
            this.participant1 = new HashSet<participant>();
            this.participantType = new HashSet<participantType>();
            this.participantWAC = new HashSet<participantWAC>();
            this.participantWAC1 = new HashSet<participantWAC>();
            this.taxParcelOwner = new HashSet<taxParcelOwner>();
        }
    
        public int pk_participant { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
        public string fk_gender_code { get; set; }
        public string fk_ethnicity_code { get; set; }
        public string fk_race_code { get; set; }
        public string fk_diversityData_code { get; set; }
        public string fk_mailingStatus_code { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public Nullable<int> fk_property { get; set; }
        public Nullable<int> fk_organization { get; set; }
        public string active { get; set; }
        public Nullable<System.DateTime> form_W9_signed_date { get; set; }
        public string fk_regionWAC_code { get; set; }
        public string fk_prefix_code { get; set; }
        public string mname { get; set; }
        public string nickname { get; set; }
        public string fk_suffix_code { get; set; }
        public string fullname_FL_dnd { get; set; }
        public string fullname_LF_dnd { get; set; }
        public string web { get; set; }
        public string fk_dataReview_code { get; set; }
        public string dataReview_note { get; set; }
        public Nullable<int> fk_participant_split { get; set; }
        public string DBA { get; set; }
    
        public virtual ICollection<eventRegistrant> eventRegistrant { get; set; }
        public virtual ICollection<farmBusinessContact> farmBusinessContact { get; set; }
        public virtual ICollection<farmBusinessMail> farmBusinessMail { get; set; }
        public virtual ICollection<farmBusinessOperator> farmBusinessOperator { get; set; }
        public virtual ICollection<farmBusinessOwner> farmBusinessOwner { get; set; }
        public virtual ICollection<form_wfp3_bid> form_wfp3_bid { get; set; }
        public virtual ICollection<form_wfp3_payment> form_wfp3_payment { get; set; }
        public virtual list_dataReview list_dataReview { get; set; }
        public virtual list_diversityData list_diversityData { get; set; }
        public virtual list_ethnicity list_ethnicity { get; set; }
        public virtual list_gender list_gender { get; set; }
        public virtual list_mailingStatus list_mailingStatus { get; set; }
        public virtual list_prefix list_prefix { get; set; }
        public virtual list_race list_race { get; set; }
        public virtual list_regionWAC list_regionWAC { get; set; }
        public virtual list_suffix list_suffix { get; set; }
        public virtual ICollection<mailingParticipant> mailingParticipant { get; set; }
        public virtual ICollection<mailingSentTo> mailingSentTo { get; set; }
        public virtual ICollection<organization> organization { get; set; }
        public virtual organization organization1 { get; set; }
        public virtual property property { get; set; }
        public virtual ICollection<participantCommunication> participantCommunication { get; set; }
        public virtual ICollection<participantContractor> participantContractor { get; set; }
        public virtual ICollection<participantForestryType> participantForestryType { get; set; }
        public virtual ICollection<participantInterest> participantInterest { get; set; }
        public virtual ICollection<participantLegacyID> participantLegacyID { get; set; }
        public virtual ICollection<participantNote> participantNote { get; set; }
        public virtual ICollection<participantOrganization> participantOrganization { get; set; }
        public virtual ICollection<participantProperty> participantProperty { get; set; }
        public virtual ICollection<participantProperty> participantProperty1 { get; set; }
        public virtual ICollection<participant> participant1 { get; set; }
        public virtual participant participant2 { get; set; }
        public virtual ICollection<participantType> participantType { get; set; }
        public virtual ICollection<participantWAC> participantWAC { get; set; }
        public virtual ICollection<participantWAC> participantWAC1 { get; set; }
        public virtual ICollection<taxParcelOwner> taxParcelOwner { get; set; }
    }
}
