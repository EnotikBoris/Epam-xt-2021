using System;
using BLL_Contracts.Interfaces;
using BLL_Contracts.Entities;
using BLL.Steps;
using System.Collections.Generic;
using FSL;

namespace VCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var setupStep = new SetupStep(new FileSystemWorker());

            var request = new FileSystemRequest()
            {
                Command = "Commit test.txt",
                FileStatus = new List<FileStatus>()
                {
                    new FileStatus()
                    {
                        Content = null,
                        FileName = "test.txt",
                        FolderName = "C:/test",
                    }
                }
            };

            var response = setupStep.Step(request).Response;

            Console.WriteLine(response.IsSuccess);
            Console.WriteLine(response.FileStatus[0].Content);
        }
    }
}
