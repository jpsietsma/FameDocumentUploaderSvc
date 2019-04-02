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
            string FarmHome = @"E:\Projects\fame uploads\Farms\";
            string TemplateHome = @"E:\Projects\fame uploads\Farms\~NewFarmBusinessTemplate\";

            //Define our list of Farm IDS, template folders, and final folder creations
            List<string> list_farms = new List<string>();
            List<string> list_templatefolders = new List<string>();
            List<string> list_finalAdditions = new List<string>();

            //Iterate through the list of farm paths and populate list_farms with farmIDs
            foreach (string _dirPath in Directory.GetDirectories(FarmHome).ToList())
            {
                
                //Skip folders that start with a period, the number 1, letters 'A' or 'C', '~' character or the string 'ITTEST'
                if (!_dirPath.Split('\\').Last().StartsWith("~") && !_dirPath.Split('\\').Last().StartsWith("ITTEST") && !_dirPath.Split('\\').Last().StartsWith(".") && !_dirPath.Split('\\').Last().StartsWith("1") && !_dirPath.Split('\\').Last().StartsWith("A") && !_dirPath.Split('\\').Last().StartsWith("C"))
                {
                    list_farms.Add(_dirPath.Split('\\').Last());
                }                
            }

            //Iterate through the list of template folder paths and populate list_templateFolders with folder names from the template farm directory
            foreach (string _templateFolder in Directory.GetDirectories(TemplateHome).ToList())
            {
                list_templatefolders.Add(_templateFolder.Split('\\').Last());
            }

            //Finally, iterate through the list of farm folders, for each of them iterate through the list_templateFolders to see if the folder already exists
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

                    }

                }

            }

                                                  
        }
    }
}
