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
            //Scan the directory for all files and put them into an array
            string path = @"Y:\FAMEDOCS\A\";
            string[] docs = Directory.GetFiles(path);
                     
            Dictionary<string, List<KeyValuePair<string, string>>> _updatedFiles = new Dictionary<string, List<KeyValuePair<string, string>>>();

            //for each file that gets located, create an entry in the dictionary using the key as the filename, and a list of key value string pairs as the value for the key
            //Each filename entry has 3 key value pairs which hold the data, oldPath, newPath, and DB path.  oldpath is current file path ie "C:\test.pdf", newpath is where 
            //the file will be copied once the record is matched to the database, and dbpath is the value for the database column 'filepath' which stores the whole document's record  
            foreach (string _file in docs)
            {

                //Get the filename from the full path to the file
                string filename = _file.Split('\\').Last();

                //split the filename into parts, using an underscore to separate them
                string[] nameparts = filename.Split('_');

                //all files are named like this: [documentType]_[FarmID]_[UploadDateOrDocumentDate].pdf
                //ie NMP_DEC-123_20190517.pdf and therefore should have more than 2 nameparts, otherwise we ignore the file as the name is invalid
                if (nameparts.Count() >= 2)
                {
                    string documentType = nameparts[0];
                    string farmID = nameparts[1];

                    switch (documentType)
                    {
                        //If the document type we encounter has a document type of 'NMP', ie the name begins with 'NMP', then we do everything in the case below matching the document type
                        case "NMP":
                            {
                                //Since we are scanning all the files, each file is handled one by one in a loop, replace "{ whateverThisIs }" with the value for the current document
                                //ie if we are looping and hit NMP_DEC-123_20190517.pdf, the code replaces { FarmID } with the actual value for that file, so DEC-123.  This is dynamically
                                //building the path where the file will be copied to.  And what to update the database with in order to be able to access them.
                                string finalCopyPath = $@"J:\Farms\{ farmID }\Final Documentation\Nutrient Mgmt\NM Plans\{ filename }";
                                string finalSubdirPath = finalCopyPath.Replace(filename, "");
                                string finalInsertPath = $@"{ farmID }\Final Documentation\Nutrient Mgmt\NM Plans\{ filename }";

                                //Here we are setting the values for the dictionary entry for the file, like we mentioned earlier
                                List<KeyValuePair<string, string>> _listVals = new List<KeyValuePair<string, string>>();
                                _listVals.Add(new KeyValuePair<string, string>("Old Path: ", _file));
                                _listVals.Add(new KeyValuePair<string, string>("New Path: ", finalCopyPath));
                                _listVals.Add(new KeyValuePair<string, string>("DB Path: ", finalInsertPath));

                                //Opening a database connection
                                using (DatabaseEntities conn = new DatabaseEntities())
                                {
                                    //Looking for any records in the database where the column 'filename_actual' matches our file we are looping.  There could be duplicate records so we 
                                    //Put the results in a list to expect more than 1 just incase.  
                                    List<documentArchive> a = conn.documentArchive.Where(x => x.filename_actual == filename).ToList();

                                    //If theres more than 0, we found a matching record
                                    if (a.Count() > 0)
                                    {
                                        try
                                        {
                                            //put that record in our code to update the filepath
                                            documentArchive record = a.First();

                                            //Take the final path where we are going to copy the file, and make sure the folder exists, if not then create it.
                                            if (!Directory.Exists(finalSubdirPath))
                                            {
                                                Directory.CreateDirectory(finalSubdirPath);
                                            } 

                                            //Copy the file from the current path '_file' to the new path we built above
                                            File.Copy(_file, finalCopyPath);

                                            //Update the record and save the changes back to the database
                                            record.filepath = finalInsertPath;
                                            conn.SaveChanges();
                                           
                                            //Add a record to the dictionary for the filename, with the appropriate values for oldpath, newpath, and dbpath
                                            _updatedFiles.Add(filename, _listVals);
                                        }
                                        //If something goes wrong, open a window to let us know the error.
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
            
            //Keep the window open to view the results until we push any key to close it
            Console.ReadLine();

        }
    }
}
