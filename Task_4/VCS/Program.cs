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

            //Reset text.txt 25.04.2020

            var setupStep = new SetupStep(new FileSystemWorker());

            var request = new FileSystemRequest()
            {
                Command = "Reset test1.txt 26.04.2021 2.28.29",
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
