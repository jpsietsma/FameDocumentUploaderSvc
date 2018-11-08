using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc.Models
{
    public class FameDocument
    {

        public string FileDirectoryPath { get; set; }
        public string FileName { get; set; }

        public int fk_FileType { get; set; }
        public string fk_FarmID { get; set; }
        public int fk_fileFarmBusiness { get; set; }
        public int fk_mailQueueID { get; set; }
        public int fk_fileUploader { get; set; }
        public int fk_participantID { get; set; }
        public DateTime fileTimestamp { get; set; }
        public double fileSize { get; set; }
        public string docSubtype { get; set; }


    }
}
