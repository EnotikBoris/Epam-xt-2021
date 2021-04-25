using BLL_Contracts.Entities;
using BLL_Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Steps
{
    class CommandStrategyStep : IStep
    {
        private IStep nextStep;


        public CommandStrategyStep()
        {

        }

        public FileSystemResponse Response => throw new NotImplementedException();

        public IStep Step(FileSystemRequest request)
        {
            CreatePipeLine(request);
            return nextStep;
        }

        private void CreatePipeLine(FileSystemRequest request)
        {
            switch (request.Command)
            {
                case "Commit":
                    nextStep = new ChangeFIleStatusStep();
                    break;
                case "Reset":
                    nextStep = new ResetFileSystemStep();
                    break;
                case "Status":
                    nextStep = new CheckFileSystemStep();
                    break;
            }
        }
    }
}
