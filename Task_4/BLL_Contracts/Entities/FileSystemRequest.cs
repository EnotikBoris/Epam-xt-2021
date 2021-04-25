using System;
using System.Collections.Generic;

namespace BLL_Contracts.Entities
{
    public class FileSystemRequest : ICloneable
    {
        public List<FileStatus> FileStatus { get; set; }
        public string Command { get; set; }

        public object Clone()
        {
            return new FileSystemRequest
            {
                FileStatus = this.FileStatus,
                Command = Command
            };
        }
    }
}
