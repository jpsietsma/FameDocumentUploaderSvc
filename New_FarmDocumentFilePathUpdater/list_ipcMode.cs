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
    using System.Collections.Generic;
    
    public partial class list_ipcMode
    {
        public list_ipcMode()
        {
            this.list_ipcPlant = new HashSet<list_ipcPlant>();
        }
    
        public string pk_ipcMode_code { get; set; }
        public string mode { get; set; }
    
        public virtual ICollection<list_ipcPlant> list_ipcPlant { get; set; }
    }
}
