using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using creator;
using System.IO;

namespace BackupApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Checking for target/destination files");
            checkFilesClass CheckFiles = new checkFilesClass();
            CheckFiles.status();
            Console.WriteLine("\n\nCreating Missing Files,\n Status:");

            createFiles.makeFiles(CheckFiles);
            
            CheckFiles.status();
            String[] targets = File.ReadAllLines("targetFile.txt");
            String[] destination = File.ReadAllLines("destinationFile.txt");
            Console.WriteLine("--Targets--");
            foreach (string i in targets) { Console.WriteLine(i); }
            Console.WriteLine("--Destinations--");
            foreach (string i in destination) { Console.WriteLine(i); }
            copyClass BackupFiles = new copyClass(targets,destination);
            BackupFiles.runCopying();
            Console.ReadKey();
        }
    }
}
