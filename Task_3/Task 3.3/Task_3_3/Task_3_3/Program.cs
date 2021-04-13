using System;
using System.Linq;

namespace Task_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] {4, 1,2,3,4,5,6,7,8,1,1,8,8,8,8,8,8,8,8,3,3,3,3,3,3,3,3,3 };

            array.DoSomething(i => i * 2);
            Console.WriteLine($"Summ: {array.GetSumm()}");
            Console.WriteLine($"Frequently: {array.GetFrequently()}");
            Console.WriteLine(array.GetAverageValue());

            array.ToList().ForEach(i => Console.WriteLine(i));
        }
    }
}
