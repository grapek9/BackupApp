﻿using System;
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
        private List<String> newDestinations;
        public copyClass(String[] targets, String[] destinations) {
            this.targets = targets;
            this.destinations = destinations;
        }
        public void runCopying() {
            List<String> executableCommands;
            foreach (String i in destinations) {
                createDestinationFolders(i);
            }
            executableCommands = createExecutableCommands(newDestinations);
        }
        private void createDestinationFolders(String destination) {
            Directory.CreateDirectory(destination+@"\Backup"+timeOfBackup);
            newDestinations.Add(destination + @"\Backup" + timeOfBackup);
        }
        
        private void copyFiles(List<String> commands) {
            foreach (String command in commands) {
                executeCommand(command);
            }
            
        }
        private String extractName(String path) {
            String[] name = path.Split('/');
            return name[name.Length-1];
        }
        private List<String> createExecutableCommands(List<String> destinations) {
            List<String> commands = null;
            foreach (String dest in destinations) {
                foreach (String target in targets) {
                    commands.Add("/C "+target+" "+dest+" /S /I");
                }
            }
            return commands;
        }
        private void executeCommand(String command)
        {
            
        }
        
    }
}
