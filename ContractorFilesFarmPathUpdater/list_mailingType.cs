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
    
    public partial class list_mailingType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public list_mailingType()
        {
            this.mailingDate = new HashSet<mailingDate>();
        }
    
        public string pk_mailingType_code { get; set; }
        public string type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mailingDate> mailingDate { get; set; }
    }
}