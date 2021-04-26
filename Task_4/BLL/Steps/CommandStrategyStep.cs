using BLL_Contracts.Entities;
using BLL_Contracts.Interfaces;
using FSL.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Steps
{
    class CommandStrategyStep : IStep
    {
        private IStep nextStep;
        private ISystemWorker worker;


        public CommandStrategyStep(ISystemWorker worker)
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
            CreatePipeLine(request);
            return nextStep.Step(request);
        }

        private void CreatePipeLine(FileSystemRequest request)
        {
            switch (request.Command.Split()[0])
            {
                case "Commit":
                    nextStep = new ChangeFIleStatusStep(worker);
                    break;
                case "Reset":
                    nextStep = new ResetFileSystemStep(worker);
                    break;
                case "Status":
                    nextStep = new CheckFileSystemStep(worker);
                    break;
            }
        }
    }
}
