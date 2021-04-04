using System;

namespace Task_3._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var weakestLink = new WeakestLink(10);

            Console.WriteLine(weakestLink);

            weakestLink.Run();

            Console.WriteLine(weakestLink);
        }
    }
}
