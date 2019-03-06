using System;
using System.Diagnostics;
using static FameDocumentUploaderSvc.FameLibrary;

namespace FameDocumentUploaderSvc.UploaderExceptionClasses
{
    /// <summary>
    /// Base class for an error encountered during a Document Uploader action.
    /// </summary>
    public class WacUploaderBaseException : Exception
    {
        public string ErrorMessage { get; set; }
        public int? ErrorSeverity { get; set; }
        public string UploaderLogMessage { get; private set; }

        public WacUploaderBaseException(string message, int? errorLevel = 1) : base(message)
        {
            UploaderLogMessage = message;
            ErrorSeverity = errorLevel;

            LogUploaderException(message);
        }

        /// <summary>
        /// Record the exception in the document uploader error log as well as the windows event log.
        /// </summary>
        /// <param name="message">string message to write to the document error log</param>
        public void LogUploaderException(string message)
        {
            WriteFameLog("error", message);
            LogWindowsEvent(message, EventLogEntryType.Error);
        }
    }
    
}
