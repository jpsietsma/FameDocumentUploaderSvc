using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc.Models
{
    public class FameContractorDocument : FameBaseDocument, IFameDocument, IFameContractorDocument
    {
        public string ContractorName { get; set; }
        public int ParticipantID { get; set; }

        public FameContractorDocument(FileSystemEventArgs e, string fileSubPath, string folderSector, string docSector) : base(e)
        {
            DocumentName = base.DocumentName;
            DocumentPath = base.DocumentPath;
            DocumentType = base.DocumentType;
            ContractorName = base.DocumentEntity;
            FinalSubPath = fileSubPath;
            DocumentTypeFolderSectorCode = folderSector;
            DocumentTypeSectorCode = docSector;

            ParticipantID = FameLibrary.GetParticipantIDFromContractor(ContractorName);

            BuildUploadFilePath();

        }

        //Assign the passed pkValue to the passed pkNum
        /// <summary>
        /// Assign the passed value to the passed pk num (1, 2, or 3)
        /// </summary>
        /// <param name="pkNum">Number of the pk to set</param>
        /// <param name="pkValue">Value to set for the pk</param>
        /// <returns>True if value was successfully set, false if not</returns>
        public override bool AssignPK(int pkNum, int? pkValue)
        {
            bool finalStatus;

            switch (pkNum)
            {
                case 1:
                    {
                        this.PK1 = FameLibrary.GetParticipantIDFromContractor(this.ContractorName);
                        finalStatus = true;
                        break;
                    }

                case 2:
                    {
                        this.PK2 = pkValue;
                        finalStatus = true;
                        break;
                    }

                case 3:
                    {
                        this.PK3 = pkValue;
                        finalStatus = true;
                        break;
                    }

                default:
                    finalStatus = false;
                    break;
            }

            return finalStatus;
        }

        //Build final destination file path for contractor document
        /// <summary>
        /// Build FinalUploadPath string, represents final path for file upload
        /// </summary>
        /// <returns>string representing move destination final path</returns>
        public override void BuildUploadFilePath()
        {
            FinalFilePath = $@"{ Configuration.wacContractorHome }\{ ContractorName }\{ FinalSubPath }\{ DocumentName }";
            FinalFilePath = FinalFilePath.Replace(@"\\\\", @"\\");
        }

    }
}
