using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FameDocumentUploaderSvc.Models.ExceptionClasses;
using static FameDocumentUploaderSvc.FameLibrary;

namespace FameDocumentUploaderSvc
{
    namespace UploaderExceptionClasses
    {

        /// <summary>
        /// File upload attempted on filename with unrecognized prefix
        /// </summary>
        public class InvalidDocumentTypeException : WacUploaderBaseException
        {
            static string message = null;

            public InvalidDocumentTypeException(string documentType, int? errorLvl = 1) : base(message: message, errorLevel: errorLvl)
            {
                ErrorMessage = $@"[{ DateTime.Now.ToShortDateString().ToString() }]Invalid document type: { documentType } detected.  Document will not be uploaded";                
            }

        }

        /// <summary>
        /// File upload was attempted but file was removed by the time uploader got to the file to process it.  Can happen when large amounts of files are dropped at once and some become removed or deleted by users.
        /// </summary>
        public class InvalidDocumentSourcePathException : WacUploaderBaseException
        {
            static string message = null;
            public InvalidDocumentSourcePathException(FileSystemEventArgs e) : base(message: message)
            {
                message = $@"[{ DateTime.Now.ToShortDateString().ToString() }] Cannot find the file: '{ e.FullPath }'. Document can not be uploaded as the source file is unavailable.";
                WriteFameLog("error", message);
            }

        }

        /// <summary>
        /// File upload attempted on a file with an unrecognized Farm ID or Contractor name in the filename.  This prevents linking file to FAME database.
        /// </summary>
        public class InvalidDocumentEntityException : WacUploaderBaseException
        {
            static string message = null;
            public InvalidDocumentEntityException(FileSystemEventArgs e) : base(message: message)
            {
                message = $@"[{ DateTime.Now.ToShortDateString().ToString() }] Unknown Contractor or Farm ID: '{ e.Name.Split('_')[1] }'. Document can not be uploaded as the entity type can not be determined.";
                WriteFameLog("error", message);
            }
        }

        /// <summary>
        /// Class that handles an invalid destination for an uploaded document, i.e. path does not exist
        /// </summary>
        public class InvalidDocumentDestinationPathException : WacUploaderBaseException
        {
            public InvalidDocumentDestinationPathException(string destinationPath) : base(message: destinationPath)
            {
                destinationPath = $@"[{ DateTime.Now.ToShortDateString().ToString() }] Non-existant destination file path: '{ destinationPath }'. Document can not be uploaded as the destination does not exist.";
                WriteFameLog("error", destinationPath);
            }
        }
    }
}
