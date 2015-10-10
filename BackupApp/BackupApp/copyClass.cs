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
        private List<String> newDestinations = new List<String>();
        public copyClass(String[] targets, String[] destinations) {
            this.targets = targets;
            this.destinations = destinations;
        }
        public void runCopying() {
            List<String> executableCommands;
            foreach (String i in destinations) {
                createDestinationFolders(i);
            }
            Console.WriteLine("test");
            executableCommands = createExecutableCommands(newDestinations);
            copyFiles(executableCommands);
            
        }
        private void createDestinationFolders(String destination) {
            Directory.CreateDirectory(destination+@"Backup"+timeOfBackup);
            Console.WriteLine(destination + @"Backup" + timeOfBackup);
            newDestinations.Add(destination + @"Backup" + timeOfBackup);
            
        }
        
        private void copyFiles(List<String> commands)
        {
            foreach (String command in commands)
            {
                executeCommand(command);
            }
            
        }
        private List<String> createExecutableCommands(List<String> destinations) {
            List<String> commands = new List<string>();
            foreach (String dest in destinations) {
                foreach (String target in targets) {
                    commands.Add("/C xcopy \""+target+"\" \""+dest+"\" /S /I");
                }
            }
            return commands;
        }
        private void executeCommand(String command)
        {
            Console.WriteLine("Executing command : "+ command);
            /*System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = command;
            process.StartInfo = startInfo;
            process.Start();*/
            System.Diagnostics.Process.Start("CMD.exe", command);

        }
        
    }
}
