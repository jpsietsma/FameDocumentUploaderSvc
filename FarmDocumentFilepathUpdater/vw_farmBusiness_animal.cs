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
    
    public partial class vw_farmBusiness_animal
    {
        public int pk_farmBusiness { get; set; }
        public int pk_farmBusinessAnimal { get; set; }
        public int pk_farmBusinessAnimalAge { get; set; }
        public int fk_list_animal { get; set; }
        public int fk_list_animalAge { get; set; }
        public Nullable<short> ASR_yr { get; set; }
        public string animal { get; set; }
        public Nullable<decimal> AU_ro_total { get; set; }
        public string ageBracket { get; set; }
        public int cnt { get; set; }
        public decimal weight { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<decimal> AU { get; set; }
    }
}
