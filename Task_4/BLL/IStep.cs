using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public interface IStep
    {
        IStep Step(BLLEntity entity);
    }
}
