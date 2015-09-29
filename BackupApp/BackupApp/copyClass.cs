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
        private String[] targets;
        private String[] destinations;
        public copyClass(String[] targets,String[] destinations) {
            this.targets = targets;
            this.destinations = destinations;
        }
        public void runCopying() {
            foreach (String i in destinations) {
                checkForDestinationFolders(i);
            }
        }
        private void createDestinationFolders(String destination) {
            Directory.CreateDirectory(destination);
            copyFiles(destination);
        }
        private void checkForDestinationFolders(String destination) {
            String dayOfBackup = DateTime.Now.ToString().Replace("/", "-").Replace(":", "-").Replace(" ", "-");
            if (!Directory.Exists(destination+"/Backup"+dayOfBackup)) {
                createDestinationFolders(destination + "/Backup" + dayOfBackup);
            } 
        }
        private void copyFiles(String destination) {
        }
    }
}
