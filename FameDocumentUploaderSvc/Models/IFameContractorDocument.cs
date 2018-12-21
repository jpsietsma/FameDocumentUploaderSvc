namespace FameDocumentUploaderSvc.Models
{
    public interface IFameContractorDocument
    {
        string ContractorName { get; set; }
        int ParticipantID { get; set; }

        bool AssignPK(int pkNum, int? pkValue);
        void BuildUploadFilePath();
    }
}