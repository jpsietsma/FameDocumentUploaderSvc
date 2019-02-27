using FameDocumentUploaderSvc.Models;
using static FameDocumentUploaderSvc.FameLibrary;
using static FameDocumentUploaderSvc.ConfigurationHelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace FameDocumentUploaderSvc
{
    public static class ExtensionLib
    {
        #region FameBaseDocument class extension methods

        //Convert  FameBaseDocument to FameContractorDocument
        /// <summary>
        /// Convert the uploaded base document to a Contractor document
        /// </summary>
        /// <param name="baseDoc">Base document to convert</param>
        /// <param name="e">FileSystemEventArgs object responsible for the drop</param>
        /// <returns>FameContractorDocument object pre-populated</returns>
        public static FameContractorDocument ConvertToContractorDocument(this FameBaseDocument baseDoc, FileSystemEventArgs e, string fileSubPath, string folderSector, string docSector)
        {
            FameContractorDocument NewContractorDocument = new FameContractorDocument(e, fileSubPath, folderSector, docSector);

            NewContractorDocument.AssignPK(1, GetParticipantIDFromContractor(NewContractorDocument.ContractorName));
            NewContractorDocument.AssignPK(2, null);
            NewContractorDocument.AssignPK(3, null);

            return NewContractorDocument;
        }

        //Convert FameBaseDocument to FameParticipantDocument
        /// <summary>
        /// Convert the uploaded base document to a Participant document
        /// </summary>
        /// <param name="baseDoc">FameBaseDocument to convert</param>
        /// <param name="e">FileSystemEventArgs object responsible for the drop</param>
        /// <returns>FameParticipantDocument pre-filled with relevent information</returns>
        public static FameParticipantDocument ConvertToParticipantDocument(this FameBaseDocument baseDoc, FileSystemEventArgs e, string fileSubPath, string folderSector, string docSector)
        {
            FameParticipantDocument NewParticipantDocument = new FameParticipantDocument(e, fileSubPath, folderSector, docSector);

            NewParticipantDocument.AssignPK(1, GetFarmBusinessByFarmId(NewParticipantDocument.FarmID));
            NewParticipantDocument.AssignPK(2, null);
            NewParticipantDocument.AssignPK(3, null);

            return NewParticipantDocument;
        }

        #endregion

        #region IFameDocument class extension methods

        //Determines if document is participant or contractor document
        /// <summary>
        /// Determine if document is a participant or contractor document based on DocumentEntity
        /// </summary>
        /// <param name="doc">Document to check type on</param>
        /// <param name="validType">true if validEntityType else false</param>
        /// <returns>string either 'participant' or 'contractor'</returns>
        public static string DetermineDocEntityType(this IFameDocument doc, out bool validType)
        {

            if (GetFarmBusinessByFarmId(doc.DocumentEntity) == 0)
            {
                if (GetParticipantIDFromContractor(doc.DocumentEntity) > 0)
                {
                    validType = true;
                    return "contractor";
                }

                validType = false;
                return null;
            }
            else
            {
                validType = true;
                return "participant";
            }
        }

        //Convert PKs with 0 to NULL for database insert
        /// <summary>
        /// Convert document PKs from 0 to "NULL" for database insert
        /// </summary>
        /// <param name="pkValue">PK to check</param>
        /// <returns>string value of pk</returns>
        public static string CheckNullPks(int? pkValue)
        {
            if (pkValue.HasValue)
                return "'" + pkValue.ToString() + "'";
            else
                return "NULL";
        }


        //Insert document information into the FAME database
        /// <summary>
        /// Insert document info into the FAME database
        /// </summary>
        /// <param name="NewDocument">Document to add to FAME</param>
        /// <param name="errorMessage">populates any error message received when upload fails</param>
        /// <returns></returns>
        public static bool AddFameDoc(this IFameDocument NewDocument, out string errorMessage)
        {
            bool finalStatus;
            int queryResult;

            string uploadTimestamp = DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss.fff");

            string queryString = $@"
                        INSERT INTO { cfgSQLDatabase }.dbo.{ cfgSQLTable } 
                            ( [PK_1], [PK_2], [PK_3], [filename_actual], [fk_participantTypeSectorFolder_code], [created], [created_by], [modified], [modified_by], [filename_display], [filepath])
                        VALUES
                            ('{ NewDocument.PK1 }', { CheckNullPks(NewDocument.PK2) }, { CheckNullPks(NewDocument.PK3) }, '{ NewDocument.DocumentName }', '{ NewDocument.DocumentTypeFolderSectorCode }', '{ uploadTimestamp }', '{ NewDocument.WacUploadUser }', NULL, NULL, '{ NewDocument.DocumentName }', '{ NewDocument.FinalFilePath }')
                        ";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    SqlCommand query = new SqlCommand(queryString, conn);
                    queryResult = query.ExecuteNonQuery();

                    errorMessage = null;
                    finalStatus = true;

                }
                catch (Exception e)
                {
                    WriteFameLog("error", e.Message);

                    errorMessage = e.Message;
                    finalStatus = false;
                }
            }

            return finalStatus;
        }

        #endregion
    }
}
