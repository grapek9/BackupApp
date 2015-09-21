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
            createFiles.makeFiles(CheckFiles);
            Console.ReadKey();
        }
    }
}
