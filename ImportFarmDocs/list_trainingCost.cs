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
    
    public partial class list_trainingCost
    {
        public list_trainingCost()
        {
            this.participantWAC_activityCost = new HashSet<participantWAC_activityCost>();
            this.participantWAC_trainingCost = new HashSet<participantWAC_trainingCost>();
        }
    
        public string pk_trainingCost_code { get; set; }
        public string item { get; set; }
    
        public virtual ICollection<participantWAC_activityCost> participantWAC_activityCost { get; set; }
        public virtual ICollection<participantWAC_trainingCost> participantWAC_trainingCost { get; set; }
    }
}
