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
    
    public partial class participantWAC_activityCost
    {
        public int pk_participantWAC_activityCost { get; set; }
        public int fk_participantWAC_activity { get; set; }
        public string fk_trainingCost_code { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<decimal> cost { get; set; }
        public string note { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
    
        public virtual list_trainingCost list_trainingCost { get; set; }
        public virtual participantWAC_activity participantWAC_activity { get; set; }
    }
}
