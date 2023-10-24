using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiaTest.Core.Contracts
{
    public interface ITiaController
    {
        void CreateTiaInstance(bool guiTia);
        void SetWhiteList(string ApplicationName, string ApplicationStartPath);
        void OpenProject(string projectDirectoryPath, string projectFilePath);
        void CloseProjectAndTia(string locationOfTiaExe);
    }
}
