using BLL_Contracts.Entities;
using BLL_Contracts.Interfaces;
using FSL.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Steps
{
    public class CheckFileSystemStep : IStep
    {
        private ISystemWorker worker;
        public CheckFileSystemStep(ISystemWorker worker)
        {
            this.worker = worker;
        }

        public FileSystemResponse Response
        {
            get;
            private set;
        }

        public IStep Step(FileSystemRequest request)
        {
            var files = worker.Read(request.FileStatus[0].FolderName);
            var status = new List<FileStatus>();

            foreach (var item in files.FileStatus)
            {
                if (IsCommited(item, request))
                {
                    item.FileStatusSetings = FileStatusSetings.Commit;
                }
                else
                {
                    item.FileStatusSetings = FileStatusSetings.Change;
                }

                status.Add(item);
            }

            files.FileStatus = status;
            Response = files;

            return this;
        }

        private List<FileStatus> GetFilesWithStatus()
        {
            throw new NotImplementedException();
        }

        private bool IsCommited(FileStatus status, FileSystemRequest request)
        {
            var readFileBackupResult = worker.Read(request.FileStatus[0].FolderName + "\\Backup");

            for (int j = 0; j < readFileBackupResult.FileStatus.Count; j++)
            {
                if (ConditionFiles(readFileBackupResult.FileStatus[j], status))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ConditionFiles(FileStatus status, FileStatus status1)
        {
            if (status == null || status1 == null) return false;
            return status.Content == status1.Content;
        }
    }
}
