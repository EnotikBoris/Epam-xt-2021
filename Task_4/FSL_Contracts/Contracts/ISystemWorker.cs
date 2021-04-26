using BLL_Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSL.Contracts
{
    public interface ISystemWorker
    {
        public FileSystemResponse Read(FileSystemRequest request);
        public FileSystemResponse Read(string folder);
        public FileSystemResponse Write(FileSystemRequest request);
        //public FileSystemResponse GetFilesInfolder(FileSystemRequest request); // Если будет время реализовать
    }
}
