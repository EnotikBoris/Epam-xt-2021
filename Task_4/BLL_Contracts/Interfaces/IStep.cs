using BLL_Contracts.Entities;
using System;

namespace BLL_Contracts.Interfaces
{
    public interface IStep
    {
        IStep Step(FileSystemRequest request);
        FileSystemResponse Response { get; }
    }
}
