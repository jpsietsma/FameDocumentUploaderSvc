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
    
    public partial class list_sectorWAC
    {
        public list_sectorWAC()
        {
            this.list_dataSector = new HashSet<list_dataSector>();
        }
    
        public string pk_sectorWAC_code { get; set; }
        public string sector { get; set; }
        public string encumbrance { get; set; }
        public string fk_sectorHR_code { get; set; }
    
        public virtual ICollection<list_dataSector> list_dataSector { get; set; }
        public virtual list_sectorHR list_sectorHR { get; set; }
    }
}
