using System;

namespace FameDocumentUploaderSvc.UploaderExceptionClasses
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
}
