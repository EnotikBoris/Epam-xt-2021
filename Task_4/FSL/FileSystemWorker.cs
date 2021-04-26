using BLL_Contracts.Entities;
using FSL.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace FSL
{
    public class FileSystemWorker : ISystemWorker
    {
        public FileSystemResponse Read(FileSystemRequest request)
        {
            string[] fileNames = null;
            var folder = request.FileStatus[0].FolderName;

            fileNames = GetFilesFromDirectory(folder);
            fileNames = GetFileNames(request, fileNames);

            // string content = null;
            List<FileStatus> files = new List<FileStatus>();

            foreach (var fileName in fileNames)
            {
                var fileStatus = new FileStatus()
                {
                    FileName = fileName,
                    FolderName = folder,
                };

                fileStatus.Content = ReadContent(fileName);

                var splitFileName = fileName.Split('_')[0].Split('\\').Last();

                if (request.FileStatus[0].FileName.Contains(splitFileName))
                    files.Add(fileStatus);
            }

            var response = new FileSystemResponse(request)
            {
                FileStatus = files,
            };

            return response;
        }

        



        public FileSystemResponse Read(string folder)
        {
            string[] fileNames = null;

            try
            {
                fileNames = Directory.GetFiles(folder);
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(folder);
                fileNames = Directory.GetFiles(folder);
            }

            var files = new List<FileStatus>();

            foreach (var fileName in fileNames)
            {
                var fileStatus = new FileStatus()
                {
                    FileName = fileName,
                    FolderName = folder,
                };

                using (FileStream fstream = File.OpenRead(fileName))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    fileStatus.Content = System.Text.Encoding.Default.GetString(array);
                    fileStatus.FileStatusSetings = FileStatusSetings.Commit;
                }

                files.Add(fileStatus);
            }

            var respose = new FileSystemResponse(null);
            respose.FileStatus = files;
            respose.IsSuccess = true;

            return respose;
        }

        public FileSystemResponse Write(FileSystemRequest request)
        {
            try
            {
                File.Delete($"{request.FileStatus[0].FolderName}\\{request.FileStatus[0].FileName}");
            }
            catch (Exception)
            {

            }

            using (FileStream fstream = new FileStream($"{request.FileStatus[0].FolderName}\\{request.FileStatus[0].FileName}", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(request.FileStatus[0].Content);
                fstream.Write(array, 0, array.Length);
            }

            var response = new FileSystemResponse(request)
            {
                FileStatus = new List<FileStatus>() 
                {
                    new FileStatus()
                    {
                        FileName = request.FileStatus[0].FileName,
                        FolderName = request.FileStatus[0].FolderName,
                        Content = request.FileStatus[0].Content,
                        FileStatusSetings = FileStatusSetings.Commit,
                    }
                }
            };

            return response;
        }

        private static string[] GetFileNames(FileSystemRequest request, string[] fileNames)
        {
            if (request.FileStatus[0].FileName.Contains("%Date%"))
            {
                var regex = new Regex(@"\d\d\.\d\d\.\d\d\d\d.*");
                fileNames = fileNames.Where(x => regex.IsMatch(x)).ToArray();
            }

            return fileNames;
        }

        private static string[] GetFilesFromDirectory(string folder)
        {
            string[] fileNames;
            try
            {
                fileNames = Directory.GetFiles(folder);
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(folder);
                fileNames = Directory.GetFiles(folder);
            }

            return fileNames;
        }

        private static string ReadContent(string fileName)
        {
            string content = null;
            using (FileStream fstream = File.OpenRead(fileName))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                content = System.Text.Encoding.Default.GetString(array);
            }

            return content;
        }
    }
}
