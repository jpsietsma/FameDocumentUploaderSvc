using System.IO;

namespace FameDocumentUploaderSvc.Models
{
    public interface IFameDocument
    {
        string DocumentEntity { get; set; }
        string DocumentName { get; set; }
        string DocumentPath { get; set; }
        string DocumentType { get; set; }
        bool ValidEntity { get; set; }
        string DocumentTypeFolderSectorCode { get; set; }
        string DocumentTypeSectorCode { get; set; }
        string FinalFilePath { get; set; }
        string FinalSubPath { get; set; }
        int PK1 { get; set; }
        int? PK2 { get; set; }
        int? PK3 { get; set; }
        string WacUploadUser { get; set; }

        bool AssignPK(int pkNum, int? pkValue);
        void BuildUploadFilePath();

        FameContractorDocument ConvertToContractorDocument(FileSystemEventArgs e, string fileSubPath, string folderSector, string docSector);

        FameParticipantDocument ConvertToParticipantDocument(FileSystemEventArgs e, string fileSubPath, string folderSector, string docSector);
    }
}