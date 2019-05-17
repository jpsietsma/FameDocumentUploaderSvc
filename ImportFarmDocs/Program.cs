using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportFarmDocs
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Y:\FAMEDOCS\A\";
            string[] docs = Directory.GetFiles(path);
            Dictionary<string, List<KeyValuePair<string, string>>> _updatedFiles = new Dictionary<string, List<KeyValuePair<string, string>>>();

            foreach (string _file in docs)
            {
                string filename = _file.Split('\\').Last();
                string[] nameparts = filename.Split('_');

                if (nameparts.Count() >= 2)
                {
                    string documentType = nameparts[0];
                    string farmID = nameparts[1];

                    switch (documentType)
                    {
                        case "NMP":
                            {
                                string finalCopyPath = $@"J:\Farms\{ farmID }\Final Documentation\Nutrient Mgmt\NM Plans\{ filename }";
                                string finalSubdirPath = finalCopyPath.Replace(filename, "");
                                string finalInsertPath = $@"{ farmID }\Final Documentation\Nutrient Mgmt\NM Plans\{ filename }";

                                List<KeyValuePair<string, string>> _listVals = new List<KeyValuePair<string, string>>();
                                _listVals.Add(new KeyValuePair<string, string>("Old Path: ", _file));
                                _listVals.Add(new KeyValuePair<string, string>("New Path: ", finalCopyPath));
                                _listVals.Add(new KeyValuePair<string, string>("DB Path: ", finalInsertPath));

                                using (DatabaseEntities conn = new DatabaseEntities())
                                {
                                    List<documentArchive> a = conn.documentArchive.Where(x => x.filename_actual == filename).ToList();

                                    if (a.Count() > 0)
                                    {
                                        try
                                        {
                                            documentArchive record = a.First();

                                            if (!Directory.Exists(finalSubdirPath))
                                            {
                                                Directory.CreateDirectory(finalSubdirPath);
                                            } 

                                            File.Copy(_file, finalCopyPath);

                                            record.filepath = finalInsertPath;
                                            conn.SaveChanges();
                                           
                                            _updatedFiles.Add(filename, _listVals);
                                        }
                                        catch (Exception ex)
                                        {
                                           Console.WriteLine(ex.Message);
                                           continue;
                                        }
                                    }
                                }

                                break;
                            }
                    }
                }               
            }

            foreach (string _file in _updatedFiles.Keys)
            {
                Console.WriteLine(_file);
            }

            Console.ReadLine();

        }
    }
}
