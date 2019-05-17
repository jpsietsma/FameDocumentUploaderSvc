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
    
    public partial class property
    {
        public property()
        {
            this.Addresses = new HashSet<Addresses>();
            this.eventVenue = new HashSet<eventVenue>();
            this.farmLand = new HashSet<farmLand>();
            this.organization = new HashSet<organization>();
            this.participant = new HashSet<participant>();
            this.participantProperty = new HashSet<participantProperty>();
            this.propertyNote = new HashSet<propertyNote>();
        }
    
        public int pk_property { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string fk_zipcode { get; set; }
        public string zip4 { get; set; }
        public Nullable<int> fk_list_countyNY { get; set; }
        public Nullable<int> fk_list_townshipNY { get; set; }
        public System.DateTime created { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string modified_by { get; set; }
        public string fk_basin_code { get; set; }
        public string fk_subbasin_code { get; set; }
        public string address_base { get; set; }
        public string fk_usps_abbr { get; set; }
        public string nbr { get; set; }
        public string fk_addressType_code { get; set; }
        public string fk_address2Type_code { get; set; }
        public string fk_list_swis { get; set; }
        public string address { get; set; }
        public string addressFull { get; set; }
        public string csz_ro { get; set; }
    
        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<eventVenue> eventVenue { get; set; }
        public virtual ICollection<farmLand> farmLand { get; set; }
        public virtual list_address2Type list_address2Type { get; set; }
        public virtual list_addressType list_addressType { get; set; }
        public virtual list_basin list_basin { get; set; }
        public virtual list_countyNY list_countyNY { get; set; }
        public virtual list_subbasin list_subbasin { get; set; }
        public virtual list_swis list_swis { get; set; }
        public virtual list_townshipNY list_townshipNY { get; set; }
        public virtual list_usps_abbr list_usps_abbr { get; set; }
        public virtual ICollection<organization> organization { get; set; }
        public virtual ICollection<participant> participant { get; set; }
        public virtual ICollection<participantProperty> participantProperty { get; set; }
        public virtual zipcode zipcode { get; set; }
        public virtual ICollection<propertyNote> propertyNote { get; set; }
    }
}
