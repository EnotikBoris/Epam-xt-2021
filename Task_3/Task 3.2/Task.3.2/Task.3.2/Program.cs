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
            array.Add("Test_5");
            array.Add("Test_6");
            array.Add("Test_7");
            array.Add("Test_8");
            array.Add("Test_9");
            array.Add("Test_10");
            array.Add("Test_11");
            array.Add("Test_12");
            array.Add("Test_13");

            Console.WriteLine(array.Clone());

            Console.WriteLine(array.Find("Test_2"));

            array.Insert("TEST_TEST", 4);

            array.Remove("Test_10");

            array.AddRange(new string[] { "Test_14", "Test_15", "Test_16" });

            Console.WriteLine($"Count : {array.Length} --- Capacity : {array.Capacity}");

            Console.WriteLine(array.ToString());

            Console.WriteLine(array[3]);
            Console.WriteLine(array[-3]);
        }
    }
}
