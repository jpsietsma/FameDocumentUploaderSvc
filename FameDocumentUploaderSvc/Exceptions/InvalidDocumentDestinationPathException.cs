using System;

namespace FameDocumentUploaderSvc.UploaderExceptionClasses
{
    /// <summary>
    /// Handles an invalid destination for an uploaded document, i.e. path does not exist
    /// </summary>
    public class InvalidDocumentDestinationPathException : WacUploaderBaseException
    {
        public InvalidDocumentDestinationPathException(string destinationPath) : base(message: destinationPath)
        {
            destinationPath = $@"[{ DateTime.Now.ToShortDateString().ToString() }] Non-existant destination file path: '{ destinationPath }'. Document can not be uploaded as the destination does not exist.";
        }
    }
}
