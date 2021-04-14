using System;

namespace Task_3_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test".GetWordCategory());
            Console.WriteLine("Тест".GetWordCategory());
            Console.WriteLine("1234789".GetWordCategory());
            Console.WriteLine("Test1234789".GetWordCategory());
        }
    }
}
