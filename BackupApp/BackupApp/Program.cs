using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using creator;

namespace BackupApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Checking for target/destination files");
            checkFilesClass CheckFiles = new checkFilesClass();
            CheckFiles.status();
            Console.WriteLine("\n\n Creating Missing Files, \n Status:");

            createFiles.makeFiles(CheckFiles);
            
            CheckFiles.status();
            Console.ReadKey();
        }
    }
}
