using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BackupApp
{
    class checkFilesClass
    {
        private string targetStatus;
        private string destinationStatus;
        private string settingsStatus;
        public checkFilesClass() {
            this.targetStatus = "File does not exist.";
            this.destinationStatus = "File does not exist.";
            this.settingsStatus = "File does not exist.";
        }
        public void status() {
            checkFiles();
            Console.WriteLine("Target File -> "+this.targetStatus);
            Console.WriteLine("Destination File -> "+this.destinationStatus);
            Console.WriteLine("Settings File -> "+this.settingsStatus);
        }
        private void checkFiles() {
            string targetFile = "targetFile.txt";
            string destinationFile = "destinationFile.txt";
            string settingsFile = "settingsFile.txt";
            if (File.Exists(targetFile)) {
                this.targetStatus = "File exists.";
            }
            if (File.Exists(destinationFile))
            {
                this.destinationStatus = "File exists.";
            }
            if (File.Exists(settingsFile))
            {
                this.settingsStatus = "File exists.";
            }
            
        }
        public Dictionary<String, Boolean> getStatus() {
            Dictionary<String, Boolean> status = new Dictionary<string, bool>();
            status["target"] = (!this.targetStatus.Equals("File does not exist.")) ? true : false;
            status["destination"] = (!this.destinationStatus.Equals("File does not exist.")) ? true : false;
            status["settings"] = (!this.settingsStatus.Equals("File does not exist.")) ? true : false;
            return status;
        }
    }
}

