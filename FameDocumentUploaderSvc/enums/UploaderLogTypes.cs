using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc
{
    public enum UploaderLogTypes
    {

        /// <summary>
        /// Logs to keep track of errors
        /// </summary>
        ERROR = 0,

        /// <summary>
        /// Logs to keep track of upload system notifications
        /// </summary>
        SYSTEM = 1,

        /// <summary>
        /// Logs to keep track of file transfers and source/destinations
        /// </summary>
        TRANSFER = 2
    }
}
