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
    
    public partial class list_encumbranceProgram
    {
        public string fk_encumbrance_code { get; set; }
        public string fk_participantType_code { get; set; }
        public string active { get; set; }
        public string note { get; set; }
    
        public virtual list_encumbrance list_encumbrance { get; set; }
        public virtual list_participantType list_participantType { get; set; }
    }
}
