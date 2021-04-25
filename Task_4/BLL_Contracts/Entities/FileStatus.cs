namespace BLL_Contracts.Entities
{
    public class FileStatus
    {
        public string FileName { get; set; }
        public string FolderName { get; set; }
        public string Content { get; set; }
        public FileStatusSetings FileStatusSetings { get; set; }
    }
}