﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackupApp;

namespace creator
{
    class createFiles
    {
        public static void makeFiles(checkFilesClass checker)
        {
            Dictionary<String, Boolean> status = checker.getStatus();
            createMissingFiles(status);
        }
        private static void createMissingFiles(Dictionary<String, Boolean> status) {
            foreach (KeyValuePair<String, bool> kvp in status) {
                Console.WriteLine(kvp.Key+" "+kvp.Value);
            }
        }
    }
}
