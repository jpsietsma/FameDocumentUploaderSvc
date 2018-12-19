namespace FameDocumentUploaderSvc.Models
{
    public interface IFameDocument
    {
        string DocumentEntity { get; set; }
        string DocumentName { get; set; }
        string DocumentPath { get; set; }
        string DocumentType { get; set; }
        string DocumentTypeFolderSectorCode { get; set; }
        string DocumentTypeSectorCode { get; set; }
        string FinalFilePath { get; set; }
        string FinalSubPath { get; set; }
        int ParticipantID { get; set; }
        int PK1 { get; set; }
        int? PK2 { get; set; }
        int? PK3 { get; set; }
        string WacUploadUser { get; set; }

        bool AssignPK(int pkNum, int? pkValue);
        void BuildUploadFilePath();
    }
}