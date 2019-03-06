using System;
using System.IO;

namespace FameDocumentUploaderSvc.UploaderExceptionClasses
{
    /// <summary>
    /// Handles a file with an unrecognized Farm ID or Contractor in the filename.  This prevents linking file to FAME database.
    /// </summary>
    public class InvalidDocumentEntityException : WacUploaderBaseException
    {
        static string message = null;
        public InvalidDocumentEntityException(Exception e, string entity) : base(message: message)
        {
            message = $@"[{ DateTime.Now.ToShortDateString().ToString() }] Unknown Contractor or Farm ID: '{ entity }'. Document can not be uploaded as the entity can not be determined.";

        }

        /// <summary>
        /// Handles a file with an unrecognized Farm ID or Contractor in the filename.  This prevents linking file to FAME database.
        /// </summary>
        /// <param name="e"></param>
        public InvalidDocumentEntityException(FileSystemEventArgs e) : base(message: message)
        {
            message = $@"[{ DateTime.Now.ToShortDateString().ToString() }] Unknown Contractor or Farm ID: '{ e.Name.Split('_')[1] }'. Document can not be uploaded as the entity type can not be determined.";
        }
    }
}
