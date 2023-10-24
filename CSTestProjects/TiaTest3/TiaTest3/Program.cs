using Siemens.Engineering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TiaTest3
{
    public class Program
    {
        public static TiaPortal instTIA;
        public static bool openedWithInterface;
        public static ProjectComposition projectsObject;
        public static Project currentProject;

        static void Main(string[] args)
        {
            //DynamicDependencyLoader.Load(@"C:\Program Files\Siemens\Automation\Portal V18\PublicAPI\V18\Siemens.Engineering.Hmi.dll");

            CreateTiaInstance(true);
        }

        public static void CreateTiaInstance(bool guiTia)
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

        public static void OpenProject(string projectDirectoryPath, string projectFilePath)
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
