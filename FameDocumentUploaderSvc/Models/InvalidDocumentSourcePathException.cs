using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc.Models
{
    public class InvalidDocumentSourcePathException : Exception
    {
        static string message = null;
        public InvalidDocumentSourcePathException(FileSystemEventArgs e) : base(message: message)
        {
            message = $@"[{ DateTime.Now.ToShortDateString().ToString() }] Cannot find the file: '{ e.FullPath }'. Document can not be uploaded as the source file is unavailable.";
            FameLibrary.WriteFameLog("error", message);
        }

    }
}
