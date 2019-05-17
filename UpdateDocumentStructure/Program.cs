using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateDocumentStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            string FarmHome = @"J:\Farms\";
            string TemplateHome = @"J:\Farms\~NewFarmBusinessTemplate\";

            //Define our list of Farm IDS, template folders, and final folder creations
            List<string> list_farms = new List<string>();
            List<string> list_templatefolders = new List<string>();
            List<string> list_finalAdditions = new List<string>();

            //Iterate through the list of farm paths and populate list_farms with farmIDs
            foreach (string _dirPath in Directory.GetDirectories(FarmHome).ToList())
            {
                string farmid = _dirPath.Split('\\').Last();

                //Skip folders that aren't farm folders
                if (!farmid.Contains("_BAK") && !farmid.StartsWith("Farm GIS Tools") && !farmid.StartsWith("fakefarm") && !farmid.StartsWith("john") 
                    && !farmid.StartsWith("Z") && !farmid.StartsWith("~") && !farmid.StartsWith("ITTEST") && !farmid.StartsWith(".") && !farmid.StartsWith("1") 
                    && !farmid.StartsWith("A") && !farmid.StartsWith("C")
                    )
                {
                    list_farms.Add(_dirPath.Split('\\').Last());
                }                
            }

            int x = 0;

            //Iterate through the list of template folder paths and populate list_templateFolders with folder names from the template farm directory
            foreach (string _templateFolder in Directory.GetDirectories(TemplateHome).ToList())
            {
                string folder = _templateFolder.Split('\\').Last();

                list_templatefolders.Add(folder);
            }

            int y = 0;

            //Finally, iterate through the list of farm folders, for each of them iterate through the list_templateFolders to see if the folder already exists
            //Iterate through the subfolders of Final Documentation to make sure all the folders are named correctly
            foreach (string _farmPath in list_farms)
            {
                foreach (string _templateFolder in list_templatefolders)
                {
                    string finalFolderPath = FarmHome + _farmPath + @"\" + _templateFolder;

                    //Create the folder and subfolders if they don't already exist
                    if (!Directory.Exists(finalFolderPath))
                    {
                        list_finalAdditions.Add(finalFolderPath);

                        new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(finalFolderPath.Replace(_farmPath, "~NewFarmBusinessTemplate"), finalFolderPath);
                        Console.WriteLine("Created: " + finalFolderPath);

                    }
                    //else check the existing folders to make sure the subfolders match the structure of the template
                    else
                    {
                        List<string> subfolders = Directory.GetDirectories(finalFolderPath).ToList();
                        string olddir = string.Empty;
                        string newdir = string.Empty;

                        switch (_templateFolder)
                        {
                            case "Final Documentation":
                                {
                                    olddir = finalFolderPath + @"\" + @"WFP-0,WFP-1,WFP-2";
                                    newdir = finalFolderPath + @"\" + @"WFP-1, WFP-2, COS";

                                    string sub1 = newdir + @"\" + "WFP-1";
                                    string sub2 = newdir + @"\" + "WFP-2";
                                    string sub3 = newdir + @"\" + "COS";

                                    //If document structure isn't correct, create the correct subfolders in Final Documentation
                                    if (!Directory.Exists(newdir))
                                    {                                      
                                        Directory.CreateDirectory(newdir);
                                        Console.WriteLine("Created: " + newdir);
                                        Directory.CreateDirectory(sub1);
                                        Console.WriteLine("Created: " + sub1);
                                        Directory.CreateDirectory(sub2);
                                        Console.WriteLine("Created: " + sub2);
                                        Directory.CreateDirectory(sub3);
                                        Console.WriteLine("Created: " + sub3);
                                    }

                                    //Check if old WFP1s folder exists and if so then copy subfiles to new directory path i.e. "Final Documentation\WFP-1, WFP-2, COS\WFP-1\"
                                    if (Directory.Exists(olddir + @"\" + "WFP1s"))
                                    {
                                        string[] wfp1 = Directory.GetFiles(olddir + @"\" + "WFP1s");

                                        if (wfp1.Count() > 0)
                                        {
                                            foreach (string _file in wfp1)
                                            {
                                                string source = _file;
                                                string destination = sub1 + @"\" + _file.Split('\\').Last();

                                                if (!File.Exists(destination))
                                                {
                                                    try
                                                    {
                                                        File.Copy(source, destination);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }

                                            }
                                        }
                                    }

                                    //Check if old WFP1 folder exists and if so then copy subfiles to new directory path i.e. "Final Documentation\WFP-1,WFP-2,COS\WFP-1"
                                    if (Directory.Exists(olddir + @"\" + "WFP1"))
                                    {
                                        string[] wfp1 = Directory.GetFiles(olddir + @"\" + "WFP1");

                                        if (wfp1.Count() > 0)
                                        {
                                            foreach (string _file in wfp1)
                                            {
                                                string source = _file;
                                                string destination = sub1 + @"\" + _file.Split('\\').Last();

                                                if (!File.Exists(destination))
                                                {
                                                    try
                                                    {
                                                        File.Copy(source, destination);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }

                                            }
                                        }
                                    }

                                    //Check if old WFP2s folder exists and if so then copy subfiles to new directory path i.e. "Final Documentation\WFP-1, WFP-2, COS\WFP-2\"
                                    if (Directory.Exists(olddir + @"\" + "WFP2s"))
                                    {
                                        string[] wfp2 = Directory.GetFiles(olddir + @"\" + "WFP2s");

                                        if (wfp2.Count() > 0)
                                        {
                                            foreach (string _file in wfp2)
                                            {
                                                string source = _file;
                                                string destination = sub2 + @"\" + _file.Split('\\').Last();

                                                if (!File.Exists(destination))
                                                {
                                                    try
                                                    {
                                                        File.Copy(source, destination);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }

                                            }
                                        }
                                    }

                                    //Check if old WFP2 folder exists and if so then copy subfiles to new directory path i.e. "Final Documentation\WFP-1, WFP-2, COS\WFP-2\"
                                    if (Directory.Exists(olddir + @"\" + "WFP2"))
                                    {
                                        string[] wfp2 = Directory.GetFiles(olddir + @"\" + "WFP2");

                                        if (wfp2.Count() > 0)
                                        {
                                            foreach (string _file in wfp2)
                                            {
                                                string source = _file;
                                                string destination = sub2 + @"\" + _file.Split('\\').Last();

                                                if (!File.Exists(destination))
                                                {
                                                    try
                                                    {
                                                        File.Copy(source, destination);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }

                                            }
                                        }
                                    }

                                    //Check if old COS folder exists and if so then copy subfiles to new directory path i.e. "Final Documentation\WFP-1, WFP-2, COS\COS\"
                                    if (Directory.Exists(olddir + @"\" + "COS"))
                                    {
                                        string[] cos = Directory.GetFiles(olddir + @"\" + "COS");

                                        if (cos.Count() > 0)
                                        {
                                            foreach (string _file in cos)
                                            {
                                                string source = _file;
                                                string destination = sub1 + @"\" + _file.Split('\\').Last();

                                                if (!File.Exists(destination))
                                                {
                                                    try
                                                    {
                                                        File.Copy(source, destination);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }

                                            }
                                        }
                                    }

                                    break;
                                }

                            case "As-Builts & Procurement":
                                {
                                    olddir = finalFolderPath + @"\" + "CREP";

                                    if (!Directory.Exists(olddir))
                                    {
                                        try
                                        {
                                            Directory.CreateDirectory(olddir);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                    }

                                    break;
                                }

                            default:
                                break;
                        }

                    }

                }

            }

            int z = 0;
                                                  
        }
    }
}
