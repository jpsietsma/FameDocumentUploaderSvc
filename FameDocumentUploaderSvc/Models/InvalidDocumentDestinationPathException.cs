using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc.Models
{
    public class InvalidDocumentDestinationPathException : Exception
    {
        public InvalidDocumentDestinationPathException(string destinationPath) : base(message: destinationPath)
        {
            destinationPath = $@"[{ DateTime.Now.ToShortDateString().ToString() }] Non-existant destination file path: '{ destinationPath }'. Document can not be uploaded as the destination does not exist.";
            FameLibrary.WriteFameLog("error", destinationPath);
        }
    }
}
