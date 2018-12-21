using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc.Models
{
    public class InvalidDocumentEntityException : Exception
    {
        static string message = null;
        public InvalidDocumentEntityException(FileSystemEventArgs e) : base(message: message)
        {
            message = $@"[{ DateTime.Now.ToShortDateString().ToString() }] Unknown Contractor or Farm ID: '{ e.Name.Split('_')[1] }'. Document can not be uploaded as the entity type can not be determined.";
            FameLibrary.WriteFameLog("error", message);
        }
    }
}
