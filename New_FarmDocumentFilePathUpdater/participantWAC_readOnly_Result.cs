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
    
    public partial class participantWAC_readOnly_Result
    {
        public Nullable<int> pk_participant { get; set; }
        public Nullable<int> pk_participantWAC { get; set; }
        public string employee { get; set; }
        public Nullable<int> pk_participantWAC_position { get; set; }
        public string fk_positionWAC_code_current { get; set; }
        public string position_current { get; set; }
        public Nullable<System.DateTime> position_current_begin { get; set; }
        public Nullable<System.DateTime> date_begin_wac { get; set; }
        public Nullable<int> positions_held { get; set; }
        public Nullable<decimal> years_at_WAC { get; set; }
        public string exempt { get; set; }
    }
}