using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FameDocumentUploaderSvc.FameLibrary;

namespace FameDocumentUploaderSvc.Models
{

    namespace ExceptionClasses
    {
        /// <summary>
        /// Base class for an error encountered during a Document Uploader action.
        /// </summary>
        public class WacUploaderBaseException : Exception
        {
            public string ErrorMessage { get; set; }
            public int? ErrorSeverity { get; set; }
            public string UploaderLogMessage { get; private set; }

            public WacUploaderBaseException(string message, int? errorLevel = 0) : base(message)
            {
                UploaderLogMessage = message;
                ErrorSeverity = errorLevel;
            }

            //
            public void LogUploaderException()
            {
                WriteFameLog("error", message);
                LogWindowsEvent(message, EventLogEntryType.Error);
            }
        }

        /// <summary>
        /// Define the level of severity of document uploader exceptions that may be encountered.  These play a part in the logging process.
        /// </summary>
        public class ExceptionSeverity
        {

        }

    }
    
}
