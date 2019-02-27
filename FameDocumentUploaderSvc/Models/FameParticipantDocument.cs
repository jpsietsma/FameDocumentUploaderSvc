using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FameDocumentUploaderSvc.Models
{
    public class FameParticipantDocument : FameBaseDocument, IFameDocument, IFameParticipantDocument
    {
        public string FarmID { get; set; }
        public int FarmBusinessID { get; set; }

        public FameParticipantDocument(FileSystemEventArgs e, string fileSubPath, string folderSector, string docSector):base(e)
        {
            string[] nameParts = e.Name.Split('_');

            //Document name
            DocumentName = e.Name;

            //Document path
            DocumentPath = e.FullPath;

            //Type of document (ASR, WFP, etc.)
            DocumentType = nameParts[0];

            //Entity that document belongs to (FarmID)
            FarmID = nameParts[1];

            //Set the file subpath based on file type
            FinalSubPath = fileSubPath;

            
            if (FarmID.Contains(@".pdf"))
            {
                FarmID = FarmID.Replace(@".pdf", "");
            }
            
            //Farm Business ID
            FarmBusinessID = FameLibrary.GetFarmBusinessByFarmId(FarmID);

            if (FarmBusinessID != 0)
            {
                ValidEntity = true;
            }

            WacUploadUser = "FAME_uploader";

            BuildUploadFilePath();

        }

        //Assign the passed pkValue to the passed pkNum
        /// <summary>
        /// Assign the passed value to the passed pk num (1, 2, or 3)
        /// </summary>
        /// <param name="pkNum">Number of the pk to set</param>
        /// <param name="pkValue">Value to set for the pk</param>
        /// <returns>True if value is successfully assigned, false if not</returns>
        public override bool AssignPK(int pkNum, int? pkValue)
        {            
            bool finalStatus = false;

            switch (pkNum)
            {
                case 1:
                    {
                        this.PK1 = FameLibrary.GetFarmBusinessByFarmId(this.FarmID);
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
                        break;
                    }

                default:
                    finalStatus = false;
                    break;
            }

            return finalStatus;
        }

        //Build final destination file path for participant document
        /// <summary>
        /// Build FinalUploadPath string, represents final path for file upload
        /// </summary>
        /// <returns>string representing move destination final path</returns>
        public override void BuildUploadFilePath()
        {
            FinalFilePath = $@"{ ConfigurationHelperLibrary.wacFarmHome }{ FarmID }\{ FinalSubPath }\{ DocumentName }";
        }

    
    }
}
