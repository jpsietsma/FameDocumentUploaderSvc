using System;
using System.IO;

namespace FameDocumentUploaderSvc.UploaderExceptionClasses
{
    /// <summary>
    /// File upload was attempted but file was removed by the time uploader got to the file to process it.  Can happen when large amounts of files are dropped at once and some become removed or deleted by users.
    /// </summary>
    public class InvalidDocumentSourcePathException : WacUploaderBaseException
    {
        static string message = null;
        public InvalidDocumentSourcePathException(FileSystemEventArgs e) : base(message: message)
        {
            message = $@"[{ DateTime.Now.ToShortDateString().ToString() }] Cannot find the file: '{ e.FullPath }'. Document can not be uploaded as the source file is unavailable.";
        }

    }
}
