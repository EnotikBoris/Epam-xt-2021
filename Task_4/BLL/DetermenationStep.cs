using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    class DetermenationStep : IStep
    {
        private Dictionary<string, IStep> _steps;

        public DetermenationStep(Dictionary<string, IStep> steps)
        {
            _steps = steps;
        }

        public IStep Step(BLLEntity entity)
        {
            var result = Determine(entity).Step(entity);

            return result;
        }


        private IStep Determine(BLLEntity entity)
        {
            switch (entity.CommandName)
            {
                case "Create":
                    return _steps["CreateStep"];
                default:
                    throw new ArgumentOutOfRangeException("");
            } 
        }
    }
}
