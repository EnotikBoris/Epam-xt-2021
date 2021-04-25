using BLL_Contracts.Entities;
using FSL.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSL
{
    public class FileSystemWorker : ISystemWorker
    {
        public FileSystemResponse GetFilesInfolder(FileSystemRequest request)
        {
            var respose = new FileSystemResponse(request);
            respose.FileStatus = new List<FileStatus>()
            {
            new FileStatus()
            {
                Content = "Tzst",
                FileName = "Test.txt",
                FileStatusSetings = FileStatusSetings.Commit,
                FolderName= "Test",
            }
            };
            respose.IsSuccess = true;

            return respose;
        }

        public FileSystemResponse Read(FileSystemRequest request)
        {
            var respose = new FileSystemResponse(request);
            respose.FileStatus = new List<FileStatus>()
            {
            new FileStatus()
            {
                Content = "Tzst",
                FileName = "Test.txt",
                FileStatusSetings = FileStatusSetings.Commit,
                FolderName= "Test",
            }
            };
            respose.IsSuccess = true;

            return respose;
        }

        public FileSystemResponse Write(FileSystemRequest request)
        {
            var respose = new FileSystemResponse(request);
            respose.FileStatus = new List<FileStatus>()
            {
            new FileStatus()
            {
                Content = "Tzst",
                FileName = "Test.txt",
                FileStatusSetings = FileStatusSetings.Commit,
                FolderName= "Test",
            }
            };
            respose.IsSuccess = true;

            return respose;
        }
    }
}
