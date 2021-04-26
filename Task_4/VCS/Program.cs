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

            //Reset text.txt 26.04.2021 2.28.29

            var setupStep = new SetupStep(new FileSystemWorker());

            var request = new FileSystemRequest()
            {
                Command = "Status",
                FileStatus = new List<FileStatus>()
                {
                    new FileStatus()
                    {
                        Content = null,
                        FileName = "test1.txt",
                        FolderName = "C:/test",
                    }
                }
            };

            var response = setupStep.Step(request).Response;

            Console.WriteLine(response.IsSuccess);

            foreach (var item in response.FileStatus)
            {
                Console.WriteLine($"{item.FileName} --- {item.FileStatusSetings}");
            }
        }
    }
}
