using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BackupApp
{
    class copyClass
    {
        String timeOfBackup = DateTime.Now.ToString().Replace("/", "-").Replace(":", "-").Replace(" ", "_");
        private String[] targets;
        private String[] destinations;
        public copyClass(String[] targets, String[] destinations) {
            this.targets = targets;
            this.destinations = destinations;
        }
        public void runCopying() {
            foreach (String i in destinations) {
                checkForDestinationFolders(i);
                copyFiles(i);
            }
        }
        private void createDestinationFolders(String destination) {
            Directory.CreateDirectory(destination);
            copyFiles(destination);
        }
        private void checkForDestinationFolders(String destination) {

            if (!Directory.Exists(destination + @"Backup" + timeOfBackup)) {
                createDestinationFolders(destination + @"Backup" + timeOfBackup);
            }
        }
        private void copyFiles(String destination) {
            String nameOfFolder = "";
            String destDirFolder = "";
            foreach (String i in targets) {
                nameOfFolder = extractName(i);
                if (!Directory.Exists(destination + @"\Backup" + timeOfBackup+"\\"+nameOfFolder))
                {
                    createDestinationFolders(destination + @"\Backup" + timeOfBackup + "\\" + nameOfFolder);
                }
                destDirFolder = destination + @"\Backup" + timeOfBackup + "\\" + nameOfFolder;
                DirectoryInfo dir = new DirectoryInfo(i);
                DirectoryInfo[] directories = dir.GetDirectories();       
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDirFolder, file.Name);
                    file.CopyTo(temppath, false);
                }
                foreach (DirectoryInfo subdir in directories)
                {
                    string temppath = Path.Combine(destDirFolder, subdir.Name);
                    File.Copy(subdir.FullName, temppath, true);
                }
            }
        }
        private String extractName(String path) {
            String[] name = path.Split('/');
            return name[name.Length-1];
        }
        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
