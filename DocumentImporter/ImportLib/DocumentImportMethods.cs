using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentImporter.ImportLib
{
    public static class DocumentImportMethods
    {
        /// <summary>
        /// Create dictionary of existing file name as key and new file name as value
        /// </summary>
        /// <param name="directoryPath">directory name to search</param>
        /// <returns>Dictionary with current filenames as key</returns>
        public static Dictionary<string, string> GetDocuments(string directoryPath)
        {
            Dictionary<string, string> documentList = new Dictionary<string, string>();

            foreach (string filePath in Directory.GetFiles(directoryPath))
            {
                if (filePath.Contains(".pdf"))
                {
                    string[] name = filePath.Split('\\');
                    name.Reverse();
                    documentList.Add(name[3], DetermineNewFilepath(name[3]));
                }                
            }

            return documentList;
        }


        public static void UpdateDictionaryValue(Dictionary<string, string> dictionary, string dictionaryKey)
        {
            dictionary[dictionaryKey] = DetermineNewFilepath(dictionaryKey);
        }

        /// <summary>
        /// Generate new file path for document in new file structure
        /// </summary>
        /// <param name="filename">filename</param>
        /// <returns>string new file path</returns>
        public static string DetermineNewFilepath(string filename)
        {
            string docFinalPath = string.Empty;

            string docType = filename.Split('_')[0];

            if (filename.Contains(".pdf") | filename.Contains(".docx") | filename.Contains(".doc"))
            {
                try
                {
                    string docEntity = filename.Split('_')[1];

                    switch (filename.Split('_')[0])
                    {
                        //Document types to ignore
                        case "PPD":
                        case "FRP":    //Farm Ranking Priority doc
                        case "PAPP":
                        case "WFP3":
                        case "WFP3SUBF":
                        case "WFP8":
                        case "WFP6Q":
                        case "WFP5M":
                        case "WFP5C":
                        case "WFP4":
                            {
                                docFinalPath = "--Ignored--";

                                break;
                            }

                        case "ASBUILT":
                            {                              
                                docFinalPath = $@"{ docEntity }\Final Documentation\As-Builts and Procurement\{ filename }";
                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath);

                                break;
                            }

                        case "AEM":
                            {
                                docFinalPath = $@"{ docEntity }\AEM\{ filename }";
                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath);

                                break;
                            }

                        case "ALTR":
                            {
                                docFinalPath = $@"{ docEntity }\Final Documentation\WFP-0,WFP-1,WFP-2\COS\{ filename }";
                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath);

                                break;
                            }

                        case "ASR":
                            {
                                docFinalPath = $@"{ docEntity }\Final Documentation\ASRs\{ filename }";
                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath);

                                break;
                            }

                        case "COS":
                            {
                                docFinalPath = $@"{ docEntity }\Final Documentation\WFP-0,WFP-1,WFP-2\COS\{ filename }";
                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath);

                                break;
                            }

                        case "CORR":
                        case "DR":
                            {
                                docFinalPath = $@"{ docEntity }\Correspondence\{ filename }";
                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath);

                                break;
                            }

                        case "CRP1":
                            {
                                docFinalPath = $@"{ docEntity }\Procurement\CREP\{ filename }";
                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath);

                                break;
                            }

                        case "NMCP":
                            {
                                docFinalPath = $@"{ docEntity }\Final Documentation\Nutrient Mgmt\Nm Credits\{ filename }";
                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath);

                                break;
                            }

                        case "NMP":
                            {
                                docFinalPath = $@"{ docEntity }\Final Documentation\Nutrient Mgmt\Nm Credits\{ filename }";
                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath);

                                break;
                            }

                        case "OM":
                            {
                                docFinalPath = $@"{ docEntity }\Final Documentation\O&Ms\{ filename }";
                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath);

                                break;
                            }

                        case "RFP":
                        case "FPD":
                            {
                                docFinalPath = $@"{ docEntity }\Final Documentation\As-Builts & Procurement\{ filename }";
                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath);

                                break;
                            }

                        case "TIER1":
                        case "TIER-1":
                            {
                                docFinalPath = $@"{ docEntity }\AEM\Tier1\{ filename }";
                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath);

                                break;
                            }

                        case "TIER2":
                        case "TIER-2":
                            {
                                docFinalPath = $@"{ docEntity }\AEM\Tier2\{ filename }";
                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath);

                                break;
                            }

                        case "WFP0":
                        case "WFP-0":
                            {
                                docFinalPath = $@"{ docEntity }\Final Documentation\WFP-0,WFP-1,WFP-2\WFP-0\{ filename }";
                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath);

                                break;
                            }

                        case "WFP1":
                        case "WFP-1":
                            {
                                docFinalPath = $@"{ docEntity }\Final Documentation\WFP-0,WFP-1,WFP-2\WFP-1\{ filename }";
                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath);

                                break;
                            }                        
                            
                        case "WFP2":
                        case "WFP-2":
                        case "WFP2RS":
                            {
                                docFinalPath = $@"{ docEntity }\Final Documentation\WFP-0,WFP-1,WFP-2\WFP-2\{ filename }";
                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath);

                                break;
                            }                      

                        case "GeneralLiability":
                        case "LIABILITY":
                        case "CERTLIAB":
                            {
                                docFinalPath = $@"{ docEntity }\General Liability\{ filename }";
                                docFinalPath.Replace(" ", "");

                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath, "contractor");

                                break;
                            }

                        case "WORKCOMP":
                            {
                                docFinalPath = $@"{ docEntity }\Workers Comp\{ filename }";
                                docFinalPath.Replace(" ", "");

                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath, "contractor");

                                break;
                            }

                        case "IRSW9F":
                            {
                                docFinalPath = $@"{ docEntity }\W-9\{ filename }";
                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath);

                                break;
                            }

                        case "IRSW9":
                            {
                                docFinalPath = $@"{ docEntity }\W-9\{ filename }";
                                docFinalPath.Replace(" ", "");

                                CopyFileToArchives(new FileInfo(ConfigurationManager.AppSettings["OldDocumentDirectory"] + filename), docFinalPath, "contractor"); 

                                break;
                            }

                        default:
                            {
                                docFinalPath = "-- Ignored --";
                                break;
                            }
                    }
                }
                catch (Exception)
                {} 

                
            }            

            return docFinalPath;
        }

        /// <summary>
        /// Search for the document in the database and update filepath column for the record
        /// </summary>
        /// <param name="filename">old filename</param>
        /// <param name="newPath">new filepath</param>
        /// <returns>true if update successful</returns>
        public static void UpdateDocumentFilepath(string filename, string newPath, out bool IsSuccessful)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=POTOKTEST;Initial Catalog=wactest;Persist Security Info=True;User ID=gisadmin;Password=gis10admin"))
            {
                conn.Open();
                IsSuccessful = false;

                string sqlUpdate = $@"SET NOCOUNT OFF; UPDATE dbo.DocumentArchive SET filepath = '{ newPath }' WHERE filename_actual = '{ filename }' ";

                SqlCommand sql = new SqlCommand(sqlUpdate, conn);

                int results = sql.ExecuteNonQuery();

                if (newPath != null)
                {
                    IsSuccessful = true;
                }                
            }

        }

        /// <summary>
        /// Copy the file from the archives to the destination path
        /// </summary>
        /// <param name="file"></param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        public static bool CopyFileToArchives(FileInfo file, string destinationPath, string entityType = "participant")
        {
            string finalDest = null;
                        
            try
            {
                if (entityType == "participant")
                {
                    finalDest = ConfigurationManager.AppSettings["FarmDocsHome"].ToString() + destinationPath;
                    //file.CopyTo(finalDest);
                    if (!File.Exists(finalDest))
                    {
                        File.Copy(file.FullName, finalDest);
                    }
                    
                }
                else if (entityType == "contractor")
                {
                    finalDest = ConfigurationManager.AppSettings["ContractorDocsHome"] + destinationPath;
                    //file.CopyTo(finalDest);
                    if (!new FileInfo(finalDest).Exists)
                    {
                        File.Copy(file.FullName, finalDest);
                    }
                }
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("File copy failed! Exception: " + ex.Message);                                             
                Console.WriteLine();

                return false;
            }

        }
        
    }
}
