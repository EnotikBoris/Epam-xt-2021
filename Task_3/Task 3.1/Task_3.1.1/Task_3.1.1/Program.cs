using System;

namespace Task_3._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManage();
        }

        private static void TaskManage()
        {
            Console.WriteLine($"WeakestLink --- 1{Environment.NewLine}TextAnalyser --- 2");

            if (int.TryParse(Console.ReadLine(), out int num))
            {
                switch (num)
                {
                    case 1:
                        WeakestLinkWork();
                    break;
                    case 2:
                        TextAnalysis();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void WeakestLinkWork()
        {
            var weakestLink = new WeakestLink(10);

            Console.WriteLine(weakestLink);

            weakestLink.Run();

            Console.WriteLine(weakestLink);
        }

        private static void TextAnalysis()
        {
            Console.WriteLine("Input text:");

            var analyser = new TextAnalyser(Console.ReadLine());

            analyser.Analyse().Show();
        }
    }
}
