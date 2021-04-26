using BLL_Contracts.Entities;
using BLL_Contracts.Interfaces;
using FSL.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
                request.FileStatus[0].FileName = request.FileStatus[0].FileName.Replace("%Date%", string.Empty);
                file.Content = worker.Read(request).FileStatus[0]?.Content;

                file.FileName = (file.FileName.Replace(".txt", string.Empty) + $"_{DateTime.Now}" + ".txt").Replace(":", ".");
                file.FolderName += "\\Backup";
                request.FileStatus[0] = file;
                
                var response = worker.Write(request);
                response.IsSuccess = true;
                
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new FileSystemResponse(request) {IsSuccess=false };
            }
        }

        private bool IsCommited(FileSystemRequest request)
        {
            var readFileResult = worker.Read(request);
            var file = readFileResult.FileStatus.FirstOrDefault(x => x.FileName.Split('\\')[x.FileName.Split('\\').Length-1] == request.FileStatus[0].FileName);
            var backupFile = worker.Read(GetRequestForBackup(request)).FileStatus.Where(x => x.Content == file.Content).FirstOrDefault();

            if (backupFile == null)
                return false;

            return ConditionFiles(file, backupFile);
        }

        private FileSystemRequest GetRequestForBackup(FileSystemRequest request)
        {
            var fslRequest = (FileSystemRequest)request.Clone();
            foreach (var item in fslRequest.FileStatus)
            {
                item.FolderName = item.FolderName + "\\Backup";
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
