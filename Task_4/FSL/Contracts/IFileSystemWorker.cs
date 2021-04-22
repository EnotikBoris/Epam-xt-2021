using System;
using System.Collections.Generic;
using System.Text;

namespace FSL.Contracts
{
    public interface IFileSystemWorker
    {
        string GetCoorentDirectory();
        void ChengeDirectory(string directory);

        bool CreatDirectory(string directory);

        bool RemoveDirectory(string directory);
    }
}
