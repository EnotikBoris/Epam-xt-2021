using BLL_Contracts.Entities;
using BLL_Contracts.Interfaces;
using FSL.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Steps
{
    class ChangeFIleStatusStep : IStep
    {
        private ISystemWorker worker;
        public ChangeFIleStatusStep(ISystemWorker worker)
        {
            this.worker = worker;
        }

        public FileSystemResponse Response { get; set; }
        public IStep Step(FileSystemRequest request)
        {
            if (IsCommited(request))
            {
                Response = new FileSystemResponse(request);
                Response.FileStatus = request.FileStatus;
                Response.IsSuccess = false;
            }
            else
            {
                Response = Commit(request);
            }

            return this;
        }

        private FileSystemResponse Commit(FileSystemRequest request)
        {
            try
            {
                var file = request.FileStatus[0];

                file.Content = worker.Read(request).FileStatus[0].Content;

                file.FileName = file.FileName + $"_{DateTime.Now}";
                file.FolderName += ".Backup";
                request.FileStatus[0] = file;
                
                var response = worker.Write(request);
                response.IsSuccess = true;
                
                return response;
            }
            catch (Exception)
            {
                return new FileSystemResponse(request) {IsSuccess=false };
            }
        }

        private bool IsCommited(FileSystemRequest request)
        {
            var readFileResult = worker.Read(request);
            var file = readFileResult.FileStatus[0];
            var readFileBackupResult = worker.Read(GetRequestForBackup(request));
            return ConditionFiles(file, readFileBackupResult.FileStatus[readFileBackupResult.FileStatus.Count - 1]);
        }

        private FileSystemRequest GetRequestForBackup(FileSystemRequest request)
        {
            var fslRequest = (FileSystemRequest)request.Clone();
            foreach (var item in fslRequest.FileStatus)
            {
                item.FolderName = item.FolderName + ".Backup";
                item.FileName = item.FileName + "%Date%";
            }
            return fslRequest;
        }

        private bool ConditionFiles(FileStatus status, FileStatus status1)
        {
            if (status == null || status1 == null) return false;
            return status.Content == status1.Content;
        }
    }
}
