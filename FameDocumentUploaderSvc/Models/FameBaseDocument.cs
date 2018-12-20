using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc.Models
{
    /// <summary>
    /// Class to handle base information about a document
    /// </summary>
    public class FameBaseDocument : IFameDocument
    {
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentType { get; set; }
        public string DocumentEntity { get; set; }
        public int PK1 { get; set; }
        public int? PK2 { get; set; }
        public int? PK3 { get; set; }
        public string DocumentTypeSectorCode { get; set; }
        public string DocumentTypeFolderSectorCode { get; set; }
        public int ParticipantID { get; set; }
        public string FinalFilePath { get; set; }
        public string FinalSubPath { get; set; }
        public string WacUploadUser { get; set; }

        public FameBaseDocument(FileSystemEventArgs e)
        {
            string[] nameParts = e.Name.Split('_');

            DocumentName = e.Name;
            DocumentPath = e.FullPath;
            DocumentType = nameParts[0];
            DocumentEntity = nameParts[1];

        }
        
        public virtual bool AssignPK(int pkNum, int? pkValue)
        {
            return false;
        }

        public virtual void BuildUploadFilePath()
        {

        }
        
        public FameParticipantDocument ConvertToParticipantDocument(FileSystemEventArgs e, string fileSubPath, string folderSector, string docSector)
        {
            FameParticipantDocument NewParticipantDocument = new FameParticipantDocument(e, fileSubPath, folderSector, docSector);

            NewParticipantDocument.AssignPK(1, FameLibrary.GetFarmBusinessByFarmId(NewParticipantDocument.FarmID));
            NewParticipantDocument.AssignPK(2, null);
            NewParticipantDocument.AssignPK(3, null);

            return NewParticipantDocument;
        }

        public FameContractorDocument ConvertToContractorDocument(FileSystemEventArgs e, string fileSubPath, string folderSector, string docSector)
        {
            FameContractorDocument NewContractorDocument = new FameContractorDocument(e, fileSubPath, folderSector, docSector);

            NewContractorDocument.AssignPK(1, FameLibrary.GetParticipantIDFromContractor(NewContractorDocument.ContractorName));
            NewContractorDocument.AssignPK(2, null);
            NewContractorDocument.AssignPK(3, null);

            return NewContractorDocument;
        }

    }
}
