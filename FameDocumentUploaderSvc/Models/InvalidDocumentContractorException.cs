using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc.Models
{
    public class InvalidDocumentContractorException : Exception
    {
        static string message = null;

        public InvalidDocumentContractorException(string contractorName) : base(message: message)
        {
            message = $@"[{ DateTime.Now.ToShortDateString().ToString() }] Unknown Contractor: '{ contractorName }'. Document can not be uploaded";
            FameLibrary.WriteFameLog("error", message);
            FameLibrary.LogWindowsEvent(message, EventLogEntryType.Error);
        }
    }
}
