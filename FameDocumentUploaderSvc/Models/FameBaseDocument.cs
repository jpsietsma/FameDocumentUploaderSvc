using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc.Models
{
    public class FameBaseDocument
    {
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public int PK1 { get; set; }
        public int? PK2 { get; set; }
        public int? PK3 { get; set; }
        public string TypeSectorCode { get; set; }
        public string TypeFolderSectorCode { get; set; }


    }
}
