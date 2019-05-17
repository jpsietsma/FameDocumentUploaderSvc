using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmDocumentFilepathUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Y:\FAMEDOCS\A\";
            string[] oldFiles = Directory.GetFiles(path);

            foreach (string _file in oldFiles)
            {
                string filename = _file.Split('\\').Last();
                string[] nameparts = filename.Split('_');
               
            }
        }
    }
}           
