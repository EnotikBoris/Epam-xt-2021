using System.Collections.Generic;

namespace BLL_Contracts.Entities
{
    public class FileSystemResponse
    {
        public FileSystemResponse(FileSystemRequest request)
        {
            Request = request;
        }

        public bool IsSuccess { get; set; }
        public List<FileStatus> FileStatus { get; set; }
        public FileSystemRequest Request { get; }

    }
}