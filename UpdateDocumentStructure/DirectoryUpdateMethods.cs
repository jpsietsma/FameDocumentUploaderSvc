using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateDocumentStructure
{
    public static class DirectoryUpdateMethods
    {

        public static bool CopyParticipantDocumentTemplate(this DirectoryInfo _dir, bool recursive = true)
        {
            List<string> templateFolders = Directory.GetDirectories(@"\\walton01\Data\Farms\~NewFarmBusinessTemplate\").ToList();

            List<string> _newFoldersAdded = new List<string>();            

            bool finalCopyStatus = false;

            foreach (string _folder in templateFolders)
            {
                string _name = new DirectoryInfo(_folder).Name;
                templateFolders.Add(_name);
                string tmpFinal = _dir + _name;

                if (Directory.Exists(_dir + _name))
                {

                }
            }
            
            return finalCopyStatus;
        }
    }
}
