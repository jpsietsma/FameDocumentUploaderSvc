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
    
    public partial class testFameUploads
    {
        public int pk_fileID { get; set; }
        public string fileDirectoryPath { get; set; }
        public string fileName { get; set; }
        public string fk_fileType { get; set; }
        public string fk_fileFarmID { get; set; }
        public string fk_fileUploader { get; set; }
        public string fileTimestamp { get; set; }
        public double fileSize { get; set; }
        public Nullable<int> fk_mailQueueID { get; set; }
        public string docSubtype { get; set; }
    }
}
