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
                FileStatus = GetCloneFileStaus(this.FileStatus),
                Command = (string)Command.Clone()
            };
        }

        private List<FileStatus> GetCloneFileStaus(List<FileStatus> fileStatuses)
        {
            var list = new List<FileStatus>(fileStatuses.Count);

            for (int i = 0; i < fileStatuses.Count; i++)
            {
                list.Add(new FileStatus
                {
                    Content = (string)fileStatuses[i]?.Content?.Clone(),
                    FileName = (string)fileStatuses[i]?.FileName?.Clone(),
                    FolderName = (string)fileStatuses[i]?.FolderName?.Clone(),
                    FileStatusSetings = fileStatuses[i].FileStatusSetings,
                });
            }

            return list;
        }
    }
}
