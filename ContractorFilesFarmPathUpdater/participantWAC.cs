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
    
    public partial class participantWAC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public participantWAC()
        {
            this.contactWAC = new HashSet<contactWAC>();
            this.participantWAC_activity = new HashSet<participantWAC_activity>();
            this.participantWAC_evaluation = new HashSet<participantWAC_evaluation>();
            this.participantWAC_note = new HashSet<participantWAC_note>();
            this.participantWAC_phone = new HashSet<participantWAC_phone>();
            this.participantWAC_position = new HashSet<participantWAC_position>();
            this.participantWAC_training = new HashSet<participantWAC_training>();
        }
    
        public int pk_participantWAC { get; set; }
        public int fk_participant { get; set; }
        public string phone_ext { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string fk_wacLocation_code { get; set; }
        public string fk_maritalStatus_code { get; set; }
        public string allergies { get; set; }
        public Nullable<int> fk_participant_emergency { get; set; }
        public string fk_employeeRelationship_code { get; set; }
        public string hireLetter { get; set; }
        public string resume { get; set; }
        public string conflictOfInterest { get; set; }
        public string recdManual { get; set; }
        public string LENS { get; set; }
        public string personalInfoSheet { get; set; }
        public Nullable<System.DateTime> teleCommute_date { get; set; }
        public string SLT { get; set; }
        public string fieldStaff { get; set; }
        public string workSchedule { get; set; }
        public string confidentialityAgreement { get; set; }
        public string flexSchedule { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> finish_date { get; set; }
        public string fk_telecommuteSchedule_code { get; set; }
        public string fk_NWD_code { get; set; }
        public string PPE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contactWAC> contactWAC { get; set; }
        public virtual list_employeeRelationship list_employeeRelationship { get; set; }
        public virtual list_maritalStatus list_maritalStatus { get; set; }
        public virtual list_NWD list_NWD { get; set; }
        public virtual list_telecommuteSchedule list_telecommuteSchedule { get; set; }
        public virtual list_wacLocation list_wacLocation { get; set; }
        public virtual participant participant { get; set; }
        public virtual participant participant1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<participantWAC_activity> participantWAC_activity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<participantWAC_evaluation> participantWAC_evaluation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<participantWAC_note> participantWAC_note { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<participantWAC_phone> participantWAC_phone { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<participantWAC_position> participantWAC_position { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<participantWAC_training> participantWAC_training { get; set; }
    }
}