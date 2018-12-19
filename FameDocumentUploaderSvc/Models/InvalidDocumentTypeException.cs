using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc.Models
{
    public class InvalidDocumentTypeException : Exception
    {
        static string message = null;
        public InvalidDocumentTypeException(string documentType) : base(message: message)
        {
            message = $@"[{ DateTime.Now.ToShortDateString().ToString() }]Invalid document type: { documentType } detected.  Document will not be uploaded";
            FameLibrary.WriteFameLog("error", message);

            FameLibrary.LogWindowsEvent(message, EventLogEntryType.Error);
        }
    }
}