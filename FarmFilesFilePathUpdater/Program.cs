using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFilesFilePathUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            string farmsPath = @"J:\Farms";
            string[] Farms = Directory.GetDirectories(farmsPath);

            List<string> InvalidFolders = new List<string>();
            List<string> ValidFolders = new List<string>();

            List<string> AllDocuments = new List<string>();

            foreach (string farm in Farms)
            {
                string FarmID = farm.Split('\\').Last();
                int FarmDocs = 0;

                Console.WriteLine($@"##################### { farm.Split('\\').Last() } ########################");

                if (FarmID.StartsWith("~") || FarmID.StartsWith(".") || FarmID.StartsWith("1") || FarmID.StartsWith("A") || FarmID.StartsWith("C") || FarmID.StartsWith("Z") || FarmID.StartsWith("fakefarm") || FarmID.StartsWith("john") || FarmID.EndsWith("_BAK") || FarmID.Contains("GIS"))
                {
                    InvalidFolders.Add(FarmID);
                }
                else
                {
                    ValidFolders.Add(FarmID);

                    string[] files = Directory.GetFiles(farm, "*", SearchOption.AllDirectories);

                    foreach (string _file in files)
                    {
                        switch (_file.Split('\\').Last().Split('_').First())
                        {
                            case "ASR":
                                {
                                    //Console.ForegroundColor = ConsoleColor.Blue;
                                    //AllDocuments.Add(_file);
                                    //Console.WriteLine(_file);
                                    //Console.ResetColor();

                                    break;
                                }

                            case "WFP1":
                                {
                                    //Console.ForegroundColor = ConsoleColor.Cyan;
                                    //AllDocuments.Add(_file);
                                    //Console.WriteLine(_file);
                                    //Console.ResetColor();

                                    break;
                                }

                                //Fix WFP2s in J:/Farms
                            case "WFP2":
                                {
                                    //Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    //AllDocuments.Add(_file);
                                    //Console.WriteLine(_file);
                                    //Console.ResetColor();

                                    break;
                                }

                                //nutrient management
                            case "NMP":
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    string docFinalPath = string.Empty;

                                    docFinalPath = _file.Replace(@"J:\Farms\", "");

                                    using (DatabaseEntities conn = new DatabaseEntities())
                                    {
                                        string filename = _file.Split('\\').Last();
                                        string[] nameparts = filename.Split('_');

                                        var x = nameparts[0];
                                        var y = nameparts[1];
                                        var z = nameparts[2];
                                                                                                                    
                                    }

                                    AllDocuments.Add(_file);
                                    Console.WriteLine(_file);
                                    Console.ResetColor();                                  

                                    break;
                                }

                                //nutrient management
                            case "NMCP":
                                {
                                    //Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    //AllDocuments.Add(_file);
                                    //Console.WriteLine(_file);
                                    //Console.ResetColor();

                                    break;
                                }

                            case "OM":
                                {
                                    //Console.ForegroundColor = ConsoleColor.Green;
                                    //AllDocuments.Add(_file);
                                    //Console.WriteLine(_file);
                                    //Console.ResetColor();

                                    break;
                                }

                            case "CERTLIAB":
                                {
                                    //Console.ForegroundColor = ConsoleColor.Red;
                                    //AllDocuments.Add(_file);
                                    //Console.WriteLine(_file);
                                    //Console.ResetColor();

                                    break;
                                }

                            case "WORKCOMP":
                                {
                                    //Console.ForegroundColor = ConsoleColor.Red;
                                    //AllDocuments.Add(_file);
                                    //Console.WriteLine(_file);
                                    //Console.ResetColor();

                                    break;
                                }

                            case "IRSW9F":
                                {
                                    //Console.ForegroundColor = ConsoleColor.DarkRed;
                                    //AllDocuments.Add(_file);
                                    //Console.WriteLine(_file);
                                    //Console.ResetColor();

                                    break;
                                }

                            case "ALTR":
                                {
                                    //Console.ForegroundColor = ConsoleColor.Magenta;
                                    //AllDocuments.Add(_file);
                                    //Console.WriteLine(_file);
                                    //Console.ResetColor();

                                    break;
                                }

                            case "CORR":
                                {
                                    //Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    //AllDocuments.Add(_file);
                                    //Console.WriteLine(_file);
                                    //Console.ResetColor();

                                    break;
                                }

                            case "DR":
                                {
                                    //Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    //AllDocuments.Add(_file);
                                    //Console.WriteLine(_file);
                                    //Console.ResetColor();

                                    break;
                                }

                            case "COS":
                                {
                                    //Console.ForegroundColor = ConsoleColor.DarkGray;
                                    //AllDocuments.Add(_file);
                                    //Console.WriteLine(_file);
                                    //Console.ResetColor();

                                    break;
                                }

                        }
                    }
                    
                    Console.WriteLine($@" -Total Farm Documents: { FarmDocs }");
                    Console.WriteLine();
                }                
            }

            Console.WriteLine();
            Console.WriteLine($@"Total Farms: { ValidFolders.Count() }");
            Console.WriteLine($@"Total Docs: { AllDocuments.Count() }");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($@"-------------- Invalid Farm Folders in Root ({ InvalidFolders.Count() })------------------------");

            foreach (string _folder in InvalidFolders)
            {
                Console.WriteLine($@"- { _folder.Split('\\').Last() }");
            }

            Console.ReadLine();
        }
    }
}
