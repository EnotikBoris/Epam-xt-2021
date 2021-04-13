using System;

namespace Task._3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new DynamicArray<string>(8);

            array.Add("Test_1");
            array.Add("Test_2");
            array.Add("Test_3");
            array.Add("Test_4");

            Console.WriteLine($"Count : {array.Length} --- Capacity : {array.Capacity}");

            Console.WriteLine(array.ToString());
        }
    }
}
