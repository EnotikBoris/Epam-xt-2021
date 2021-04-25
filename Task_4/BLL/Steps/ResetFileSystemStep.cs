using BLL_Contracts.Entities;
using BLL_Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Steps
{
    class ResetFileSystemStep : IStep
    {
        public FileSystemResponse Response
        {
            get => throw new NotImplementedException();
            private set => throw new NotImplementedException();
        }
        public IStep Step(FileSystemRequest request)
        {
            throw new NotImplementedException();
        }

        private void ResetFiles(FileSystemRequest request) 
        {
        
        }
    }
}
