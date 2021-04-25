using BLL_Contracts.Entities;
using BLL_Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Steps
{
    public class SetupStep : IStep
    {
        private IStep nextStep;
        public SetupStep()
        {
            nextStep = new CommandStrategyStep();
        }

        public FileSystemResponse Response
        {
            get;
            private set;
        }
        public IStep Step(FileSystemRequest request)
        {
            if (CheckRequest(request))
            {
                return nextStep;
            }

            Response = new FileSystemResponse(request);
            Response.IsSuccess = false;
            return this;
        }

        private bool CheckRequest(FileSystemRequest request)
        {
            switch (request.Command.Split()[0])
            {
                case "Commit": return true;
                case "Status": return true;
                case "Reset": return true;
                default: return false;
            }

            throw new NotImplementedException();
        }
    }
}
