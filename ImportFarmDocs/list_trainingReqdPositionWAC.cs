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
    
    public partial class list_trainingReqdPositionWAC
    {
        public int pk_list_trainingReqdPositionWAC { get; set; }
        public string fk_trainingReqd_code { get; set; }
        public string fk_positionWAC_code { get; set; }
    
        public virtual list_positionWAC list_positionWAC { get; set; }
        public virtual list_trainingReqd list_trainingReqd { get; set; }
    }
}
