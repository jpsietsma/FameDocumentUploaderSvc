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
    
    public partial class farmBusinessAnimalAge
    {
        public int pk_farmBusinessAnimalAge { get; set; }
        public int fk_farmBusinessAnimal { get; set; }
        public int fk_list_animalAge { get; set; }
        public int cnt { get; set; }
        public decimal weight { get; set; }
        public Nullable<decimal> total { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string note { get; set; }
        public Nullable<decimal> AU { get; set; }
    
        public virtual farmBusinessAnimal farmBusinessAnimal { get; set; }
        public virtual list_animalAge list_animalAge { get; set; }
    }
}
