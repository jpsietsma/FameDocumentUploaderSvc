using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc.UploaderExceptionClasses
{
    /// <summary>
    /// Handles when an ASR is dropped with a filename that includes a year for which there was no ASR done.
    /// </summary>
    public class InvalidASRYearException : WacUploaderBaseException
    {
        static string message = null;
        public InvalidASRYearException(Exception e, int asrYear) : base(message: message)
        {
            message = $@"[{ DateTime.Now.ToShortDateString().ToString() }] Invalid ASR year, ASR does not exist for the provided year: '{ asrYear }'. Document will not be uploaded.";
        }
    }
}
