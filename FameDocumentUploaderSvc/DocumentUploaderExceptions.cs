using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc
{

    /// <summary>
    /// Class that represents an invalid document type exception
    /// </summary>
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

    /// <summary>
    /// Class that handles an invalid document source path, i.e. file was removed before uploader could handle
    /// </summary>
    public class InvalidDocumentSourcePathException : Exception
    {
        static string message = null;
        public InvalidDocumentSourcePathException(FileSystemEventArgs e) : base(message: message)
        {
            message = $@"[{ DateTime.Now.ToShortDateString().ToString() }] Cannot find the file: '{ e.FullPath }'. Document can not be uploaded as the source file is unavailable.";
            FameLibrary.WriteFameLog("error", message);
        }

    }

    /// <summary>
    /// Class that handles an invalid document entity, ie filename has non-existant farm or contractor
    /// </summary>
    public class InvalidDocumentEntityException : Exception
    {
        static string message = null;
        public InvalidDocumentEntityException(FileSystemEventArgs e) : base(message: message)
        {
            message = $@"[{ DateTime.Now.ToShortDateString().ToString() }] Unknown Contractor or Farm ID: '{ e.Name.Split('_')[1] }'. Document can not be uploaded as the entity type can not be determined.";
            FameLibrary.WriteFameLog("error", message);
        }
    }

    /// <summary>
    /// Class that handles an invalid destination for an uploaded document, i.e. path does not exist
    /// </summary>
    public class InvalidDocumentDestinationPathException : Exception
    {
        public InvalidDocumentDestinationPathException(string destinationPath) : base(message: destinationPath)
        {
            destinationPath = $@"[{ DateTime.Now.ToShortDateString().ToString() }] Non-existant destination file path: '{ destinationPath }'. Document can not be uploaded as the destination does not exist.";
            FameLibrary.WriteFameLog("error", destinationPath);
        }
    }


}
