using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DocumentImporter.ImportLib.DocumentImportMethods;

namespace DocumentImporter
{
    public class Program
    {
        static void Main(string[] args)
        {
            string masterDocumentPath = @"Y:\FAMEDOCS\A";
            int totalSuccessful = 0;
            int totalFailure = 0;

            Dictionary<string, string> docs = GetDocuments(masterDocumentPath);

            foreach (KeyValuePair<string, string> fileEntry in docs)
            {
                Console.WriteLine("Old Name: " + fileEntry.Key);
                Console.WriteLine("New Name: " + fileEntry.Value);
                Console.WriteLine();
                Console.Write("Updating filepath... ");

                UpdateDocumentFilepath(fileEntry.Key, fileEntry.Value, out bool IsSuccessful);

                if (IsSuccessful)
                {
                    totalSuccessful++;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Update Successful!");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    totalFailure++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Updating filepath failed!");
                    Console.ResetColor();
                    Console.WriteLine();
                }                
            }

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Total Files Scanned: " + docs.Count);
            Console.WriteLine("Successfully copied: " + totalSuccessful + "/" + docs.Count);
            Console.WriteLine("Failed to copy file: " + totalFailure);
            Console.WriteLine("%  files successful: " + ((totalSuccessful / docs.Count) * 100).ToString());

            Console.ReadLine();
        }
    }
}
