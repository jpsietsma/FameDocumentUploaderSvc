using fameUploadConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        public static void Main(string[] args)
        {

            string farmID = "DEC-028";

            Console.WriteLine($"Farm ID: { farmID } ");
            Console.WriteLine($"Farm Business: " + DemoLibrary.GetFarmBusinessByFarmId(farmID));
            Console.ReadLine();

            Console.WriteLine();
            Console.ReadLine();

        }
    }
}
