using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Checking for target/destination files");
            checkFilesClass CheckFiles = new checkFilesClass();
            CheckFiles.status();
            Console.ReadKey();
        }
    }
}
