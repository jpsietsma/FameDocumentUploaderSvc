namespace FameDocumentUploaderSvc.Models
{
    public interface IFameParticipantDocument
    {
        int FarmBusinessID { get; set; }
        string FarmID { get; set; }

        bool AssignPK(int pkNum, int? pkValue);
        void BuildUploadFilePath();
    }
}