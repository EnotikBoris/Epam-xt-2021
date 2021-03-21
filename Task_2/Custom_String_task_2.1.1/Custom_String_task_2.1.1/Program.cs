using System;

namespace Custom_String_task_2._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            CusString cs1 = new CusString("Hello".ToCharArray());
            CusString cs2 = new CusString("World".ToCharArray());
            CusString cs3 = new CusString("Hello".ToCharArray());

            Console.WriteLine(cs1.ToCharArray());
            Console.WriteLine(cs2.ConCat(cs1).ToCharArray());
            Console.WriteLine(cs3.IndexOf('l'));
            Console.WriteLine(cs1.Compare(cs3));
            Console.WriteLine(cs1.Compare(cs2));

            foreach (var item in cs1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(cs1 + " " + cs2);
            Console.WriteLine(cs1 == cs3);
            Console.WriteLine(cs1 != cs2);
        }
    }
}
