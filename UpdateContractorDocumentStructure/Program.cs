using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateContractorDocumentStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            string NewContractorDocHome = @"J:\CONTRACTORS\Contractor_docs\";
            string OldContractorDocHome = @"Y:\FAMEDOCS\PART\";

            List<string> list_contractorFolders = Directory.GetDirectories(NewContractorDocHome).ToList();
            List<string> list_contractorDocs = Directory.GetFiles(OldContractorDocHome).ToList();

            int count = 0;

            foreach (string _doc in list_contractorDocs)
            {
                string[] nameparts = _doc.Split('\\').Last().Split('_');

                string docType = nameparts[0];
                string docEntity = nameparts[1];

                if (docType == "CERTLIAB" || docType == "IRSW9" || docType == "WORKCOMP")
                {
                    string finalPath = string.Empty;
                    string finalFile = string.Empty;
                    string contractorRoot = string.Empty;

                    switch (docType)
                    {
                        case "CERTLIAB":
                            {
                                contractorRoot = NewContractorDocHome + docEntity;
                                finalPath = NewContractorDocHome + docEntity + @"\General Liability\";
                                finalFile = finalPath + _doc.Split('\\').Last();

                                try
                                {
                                    if (!Directory.Exists(contractorRoot))
                                    {
                                        //new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(template, finalPath);
                                    }

                                    if (!File.Exists(finalFile))
                                    {
                                        //File.Copy(_doc, finalPath + _doc.Split('\\').Last());
                                        count++;
                                    }
                                    else
                                    {
                                        Console.WriteLine($@"File already exists in destination: {_doc.Split('\\').Last()}");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(ex.Message);
                                }

                                break;
                            }

                        case "IRSW9":
                            {
                                contractorRoot = NewContractorDocHome + docEntity;
                                finalPath = NewContractorDocHome + docEntity + @"\W-9\";
                                finalFile = finalPath + _doc.Split('\\').Last();                                

                                try
                                {
                                    if (!Directory.Exists(contractorRoot))
                                    {
                                        //new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(template, finalPath);
                                    }

                                    if (!File.Exists(finalFile))
                                    {
                                        //File.Copy(_doc, finalPath + _doc.Split('\\').Last());
                                        count++;
                                    }
                                    else
                                    {
                                        Console.WriteLine($@"File already exists in destination: {_doc.Split('\\').Last()}");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(ex.Message);
                                }

                                break;
                            }

                        case "WORKCOMP":
                            {
                                contractorRoot = NewContractorDocHome + docEntity;
                                finalPath = NewContractorDocHome + docEntity + @"\Workers Comp\";
                                finalFile = finalPath + _doc.Split('\\').Last();

                                try
                                {
                                    if (!Directory.Exists(contractorRoot))
                                    {
                                        //new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(template, finalPath);
                                        Console.WriteLine($@"Contractor folder does not exist: { docEntity }");
                                    }

                                    if (!File.Exists(finalFile))
                                    {
                                        //File.Copy(_doc, finalPath + _doc.Split('\\').Last());
                                        count++;
                                    }
                                    else
                                    {
                                        Console.WriteLine($@"File already exists in destination: {_doc.Split('\\').Last()}");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(ex.Message);
                                }

                                break;
                            }

                        default:
                            break;
                    }
                    
                }
            }



            //foreach (string _filename in list_contractorDocs)
            //{
            //    string tmpName = _filename.Split('\\').Last();
            //    string[] nameparts = tmpName.Split('_');
            //    string DocType = nameparts[0];
            //    string DocEntity = nameparts[1].Split('.')[0];

            //    if (DocType == "CERTLIAB" || DocType == "IRSW9" || DocType == "WORKCOMP")
            //    {
            //        if (!Directory.Exists(TmpContractorDocHome + DocEntity))
            //        {
            //            string sourceStr = NewContractorDocHome + "~NewContractorTemplate";
            //            string destStr = TmpContractorDocHome + DocEntity;

            //            new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(sourceStr, destStr);
            //        }
            //    }               
            //}

        }
    }
}
