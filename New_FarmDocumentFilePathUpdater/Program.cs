using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_FarmDocumentFilePathUpdater
{
    class Program
    {
        string oldDir = @"Y:\famedocs\part\";
        string docsHome = @"J:\CONTRACTORS\Contractor_docs";

        string[] oldFiles = Directory.GetFiles(oldDir);

        List<string> validFiles = new List<string>();
        Dictionary<string, List<KeyValuePair<string, string>>> validUpdated = new Dictionary<string, List<KeyValuePair<string, string>>>();
        List<string> validCreated = new List<string>();

        List<string> invalidFiles = new List<string>();
        List<string> notInFame = new List<string>();
        List<string> fameDuplicate = new List<string>();

        List<string> cert = new List<string>();
        List<string> w9 = new List<string>();
        List<string> work = new List<string>();

            foreach (string _file in oldFiles)
            {
                string filename = _file.Split('\\').Last();
        string[] nameparts = filename.Split('_');

        Console.WriteLine();
                Console.WriteLine(filename);
                Console.WriteLine();

                if (nameparts.Count() > 2)
                {
                    string docType = nameparts[0];
        string contractor = nameparts[1];

                    switch (docType)
                    {
                        case "CERTLIAB":
                            {
                                cert.Add(_file);
                                string folderName = "General Liability";

        AnalyzeDocument(_file, folderName, docsHome, contractor, filename, ref validFiles, ref validUpdated, ref notInFame, ref fameDuplicate);

                                break;
                            }

                        case "IRSW9":
                            {
                                w9.Add(_file);
                                string folderName = "W-9";

    AnalyzeDocument(_file, folderName, docsHome, contractor, filename, ref validFiles, ref validUpdated, ref notInFame, ref fameDuplicate);

                                break;
                            }

                        case "WORKCOMP":
                            {
                                work.Add(_file);
                                string folderName = "Workers Comp";

AnalyzeDocument(_file, folderName, docsHome, contractor, filename, ref validFiles, ref validUpdated, ref notInFame, ref fameDuplicate);
                                                                                           
                                break;
                            }

                        default:
                            {
                                invalidFiles.Add(_file);

                                break;
                            }
                    }
                }
                else
                {
                    invalidFiles.Add(_file);
                }                

            }

            ShowSummary(oldDir, oldFiles, ref validFiles, ref validUpdated, ref invalidFiles, ref notInFame, ref cert, ref w9, ref work, ref fameDuplicate);
          
        }

        public static void ShowSummary(string sOldDir, string[] lOldFiles, ref List<string> lValidFiles, ref Dictionary<string, List<KeyValuePair<string, string>>> lValidUpdated, ref List<string> lInvalidFiles, ref List<string> lNotInFame, ref List<string> lCertDocs, ref List<string> lW9Docs, ref List<string> lWorkDocs, ref List<string> lFameDuplicates)
{
    Console.Clear();
    Console.WriteLine($@"Scan of { sOldDir } completed..");
    Console.WriteLine();
    Console.WriteLine($@"Total Files Scanned: { lOldFiles.Count() }");
    Console.WriteLine($@"Total Matching Records: { lValidFiles.Count() }");
    Console.WriteLine($@"Total Records Updated: { lValidUpdated.Keys.Count() }");
    Console.WriteLine($@"Invalid Filenames: { lInvalidFiles.Count() }");
    Console.WriteLine($@"Valid Files not in fame: { lNotInFame.Count() }");
    Console.WriteLine($@"Duplicate DB Records: { lFameDuplicates.Count() }");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine($@"CertLiab docs: { lCertDocs.Count() }");
    Console.WriteLine($@"IRS W-9 docs: { lW9Docs.Count() }");
    Console.WriteLine($@"WorkComp docs: { lWorkDocs.Count() }");

    MakeDecision(ref lInvalidFiles, ref lNotInFame, ref lValidUpdated, ref lFameDuplicates);
}

public static void MakeDecision(ref List<string> lInvalidFiles, ref List<string> lNotInFame, ref Dictionary<string, List<KeyValuePair<string, string>>> lValidUpdated, ref List<string> lFameDuplicates, bool invalidSelection = false, string value = null)
{
    Console.WriteLine();
    Console.WriteLine();

    if (invalidSelection)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($@"{ value } is not a valid option.  Please make another selection.");
        Console.WriteLine();
        Console.ResetColor();
    }

    Console.WriteLine("Choose your action: ");
    Console.WriteLine("  [0] - Exit the Program.");
    Console.WriteLine("  [1] - Show files marked by the scanner as having invalid filenames.");
    Console.WriteLine("  [2] - Show files that appear to have valid names but no record in the FAME database.");
    Console.WriteLine("  [3] - Show files that were updated in the FAME database.");
    Console.WriteLine("  [4] - Show files with duplicate FAME database records.");
    Console.WriteLine();
    string x = Console.ReadLine();

    switch (x)
    {
        case "1":
            {
                Console.Clear();
                Console.WriteLine("Results: ");
                Console.WriteLine();
                Console.WriteLine("Invalid Files: ");

                DisplayListResults(ref lInvalidFiles, ref lValidUpdated);

                MakeDecision(ref lInvalidFiles, ref lNotInFame, ref lValidUpdated, ref lFameDuplicates);

                break;
            }

        case "2":
            {
                Console.WriteLine("Results: ");
                Console.WriteLine();
                Console.WriteLine("Missing from FAME: ");

                DisplayListResults(ref lNotInFame, ref lValidUpdated);

                MakeDecision(ref lInvalidFiles, ref lNotInFame, ref lValidUpdated, ref lFameDuplicates);

                break;
            }

        case "3":
            {
                Console.WriteLine("Results: ");
                Console.WriteLine();
                Console.WriteLine("Updated in FAME: ");

                DisplayListResults(ref lFameDuplicates, ref lValidUpdated, true);



                MakeDecision(ref lInvalidFiles, ref lNotInFame, ref lValidUpdated, ref lFameDuplicates);

                break;
            }

        case "4":
            {
                Console.WriteLine("Results: ");
                Console.WriteLine();
                Console.WriteLine("FAME duplicate records: ");

                DisplayListResults(ref lFameDuplicates, ref lValidUpdated);

                MakeDecision(ref lInvalidFiles, ref lNotInFame, ref lValidUpdated, ref lFameDuplicates);

                break;
            }

        case "0":
            {
                break;
            }

        default:
            {

                MakeDecision(ref lInvalidFiles, ref lNotInFame, ref lValidUpdated, ref lFameDuplicates, true, x);

                break;
            }
    }

}

public static void AnalyzeDocument(string sFilePath, string sFolderName, string sDocsHome, string sContractorName, string sFileName, ref List<string> lValidFiles, ref Dictionary<string, List<KeyValuePair<string, string>>> dValidUpdated, ref List<string> lNotInFame, ref List<string> lFameDuplicates, bool bScanDoUpdate = false)
{
    if (sContractorName.EndsWith(@"."))
    {
        sContractorName = sContractorName.Remove(sContractorName.Length - 1);
    }

    string finalPath = $@"{ sDocsHome }\{ sContractorName }\{ sFolderName }\{ sFileName }";

    using (Entities conn = new Entities())
    {
        List<documentArchive> a = conn.documentArchive.Where(w => w.filename_actual == sFileName).ToList();

        //if document record exists
        if (a.Count() > 0)
        {
            if (a.Count() > 1)
            {
                lFameDuplicates.Add(sFileName);
            }

            using (Entities db = new Entities())
            {
                try
                {
                    List<documentArchive> record = db.documentArchive.Where(w => w.filename_actual == sFileName).ToList();

                    if (record != null)
                    {
                        string insertedPath = finalPath.Replace(@"J:\CONTRACTORS\Contractor_docs\", "");

                        if (insertedPath != record.First().filepath)
                        {
                            List<KeyValuePair<string, string>> _entry = new List<KeyValuePair<string, string>>();
                            _entry.Add(new KeyValuePair<string, string>("Old Path", record.First().filepath));
                            _entry.Add(new KeyValuePair<string, string>("New Path", insertedPath));

                            if (bScanDoUpdate)
                            {
                                record.First().filepath = insertedPath;
                                db.SaveChangesAsync();
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("--- Mocking Database Update ---");
                                Console.ResetColor();
                                Console.WriteLine();
                            }

                            dValidUpdated.Add(sFileName, _entry);
                        }

                        if (!File.Exists(finalPath))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(finalPath));

                            File.Copy(sFilePath, finalPath);

                            Console.WriteLine();
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine($@"File created at { finalPath }");
                            Console.ResetColor();
                            Console.WriteLine();
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            lValidFiles.Add(sFilePath);
        }
        else
        {
            lNotInFame.Add(sFilePath);
        }
    }
}

public static void DisplayListResults(ref List<string> _list, ref Dictionary<string, List<KeyValuePair<string, string>>> lValidUpdated, bool isUpdateList = false)
{
    if (isUpdateList)
    {
        foreach (string key in lValidUpdated.Keys)
        {
            Console.WriteLine($@"######################## {key} ########################");
            Console.WriteLine($@"Old Path: ");
            Console.WriteLine(lValidUpdated[key][0].Value);
            Console.WriteLine($@"New Path: ");
            Console.WriteLine(lValidUpdated[key][1].Value);
            Console.WriteLine($@"##############################################################################################");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
    else
    {
        foreach (string item in _list)
        {
            Console.WriteLine(item);
        }
    }
}
    }
}
