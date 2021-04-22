using System;
using System.Collections.Generic;
using System.Text;

namespace FSL.Contracts
{
    public interface IFileWorker
    {
        bool WriteFile(string fileName, string text);

        string ReadFile(string fileName);
    }
}
