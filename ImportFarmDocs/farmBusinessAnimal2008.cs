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
    
    public partial class farmBusinessAnimal2008
    {
        public int pk_farmBusinessAnimal { get; set; }
        public int fk_farmBusiness { get; set; }
        public Nullable<System.DateTime> updated { get; set; }
        public Nullable<decimal> AU_total { get; set; }
        public Nullable<int> dairy_mature { get; set; }
        public Nullable<int> dairy_heifer { get; set; }
        public Nullable<int> veal { get; set; }
        public Nullable<int> beef { get; set; }
        public Nullable<int> calf { get; set; }
        public Nullable<int> bull { get; set; }
        public Nullable<int> sheep { get; set; }
        public Nullable<int> lamb { get; set; }
        public Nullable<int> goat { get; set; }
        public Nullable<int> kid { get; set; }
        public Nullable<int> pig { get; set; }
        public Nullable<int> piglet { get; set; }
        public Nullable<int> boar { get; set; }
        public Nullable<int> horse { get; set; }
        public Nullable<int> foal { get; set; }
        public Nullable<int> donkey { get; set; }
        public Nullable<int> oxen { get; set; }
        public Nullable<int> chicken { get; set; }
        public Nullable<int> turkey { get; set; }
        public Nullable<int> ginny_hen { get; set; }
        public Nullable<int> peacock { get; set; }
        public Nullable<int> pheasant { get; set; }
        public Nullable<int> duck { get; set; }
        public Nullable<int> geese { get; set; }
        public Nullable<int> rabbit { get; set; }
        public Nullable<int> emu { get; set; }
        public Nullable<int> ostrich { get; set; }
        public Nullable<int> walaroo { get; set; }
        public Nullable<int> llama { get; set; }
        public Nullable<int> alpaca { get; set; }
        public Nullable<int> deer { get; set; }
        public Nullable<int> elk { get; set; }
        public Nullable<int> buffalo { get; set; }
        public Nullable<int> bear { get; set; }
        public Nullable<int> mountain_lion { get; set; }
        public Nullable<int> guinea_pig { get; set; }
        public Nullable<int> greenhouse { get; set; }
        public Nullable<int> vegetable { get; set; }
        public Nullable<int> kangaroo { get; set; }
        public Nullable<int> zebra { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string created_by { get; set; }
    
        public virtual farmBusiness farmBusiness { get; set; }
    }
}
