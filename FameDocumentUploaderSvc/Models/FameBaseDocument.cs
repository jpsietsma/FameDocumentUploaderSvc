using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc.Models
{
    public class FameBaseDocument
    {
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentType { get; set; }
        public int PK1 { get; set; }
        public int? PK2 { get; set; }
        public int? PK3 { get; set; }
        public string TypeSectorCode { get; set; }
        public string TypeFolderSectorCode { get; set; }
        public int ParticipantID { get; set; }
        public string FinalFilePath { get; set; }

        public FameBaseDocument(FileSystemEventArgs e)
        {
            string[] nameParts = e.Name.Split('_');

            DocumentName = e.Name;
            DocumentPath = e.FullPath;
            DocumentType = nameParts[0];

        }      
        
    }
}
