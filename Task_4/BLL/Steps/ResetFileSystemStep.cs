using BLL_Contracts.Entities;
using BLL_Contracts.Interfaces;
using FSL.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Steps
{
    class ResetFileSystemStep : IStep
    {
        private ISystemWorker worker;
        public ResetFileSystemStep(ISystemWorker worker)
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
            try
            {

                var firstRequest = (FileSystemRequest)request.Clone();
                var command = firstRequest.Command.Split();
                var fileName = command[1].Split('.');
                firstRequest.FileStatus[0].FileName = fileName[0] + "_" + (DateTime.Parse($"{command[2]} {command[3].Replace(".", ":")}")).ToString().Replace(":", ".") + ".txt";
                firstRequest.FileStatus[0].FolderName = request.FileStatus[0].FolderName + "\\Backup";

                var backupFile = worker.Read(firstRequest);
                request.FileStatus[0].Content = backupFile.FileStatus[0].Content;
                var response = worker.Write(request);

                Response = response;
                Response.IsSuccess = true;
            }
            catch (Exception)
            {
                Response.IsSuccess = false;
            }

            return this;
        }


    }
}
