using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc.Models
{
    public class FameContractorDocument : FameBaseDocument
    {
        public string ContractorName { get; set; }
        public int pk_farmBusiness { get; set; }

        public FameContractorDocument()
        {

        }
    }
}
