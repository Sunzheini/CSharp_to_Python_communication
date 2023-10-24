using Siemens.Engineering;
using Siemens.Engineering.CrossReference;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TiaTest
{
    public class Class1
    {
        public static TiaPortal instTIA;
        public static bool openedWithInterface;
        public static ProjectComposition projectsObject;
        public static Project currentProject;

        public void CreateTiaInstance(bool guiTia)
        {
            if (guiTia)
            {
                instTIA = new TiaPortal(TiaPortalMode.WithUserInterface);
                openedWithInterface = true;
            }
            else
            {
                instTIA = new TiaPortal(TiaPortalMode.WithoutUserInterface);
                openedWithInterface = false;
            }
        }

        public void SetWhiteList(string ApplicationName, string ApplicationStartPath)
        {
            // Implementation for SetWhiteList
        }

        public void OpenProject(string projectDirectoryPath, string projectFilePath)
        {
            DirectoryInfo projectDirectoryInfoPath = new DirectoryInfo(projectDirectoryPath);
            FileInfo projectFileInfoPath = new FileInfo(projectFilePath);

            projectsObject = instTIA.Projects;
            currentProject = projectsObject.Open(projectFileInfoPath);
        }

        public void CloseProjectAndTia(string locationOfTiaExe)
        {
            currentProject.Close();

            if (openedWithInterface)
            {
                // Get the process name without the path.
                string tiaExeName = System.IO.Path.GetFileNameWithoutExtension(locationOfTiaExe);

                // Find the TIA Portal process by its name.
                Process[] processes = Process.GetProcessesByName(tiaExeName);

                // Terminate all instances of the TIA Portal process.
                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }
            else    // if without interface
            {
                instTIA.Dispose();
            }
        }
    }
}
