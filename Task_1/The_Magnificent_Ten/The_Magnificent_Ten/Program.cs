using System;

namespace The_Magnificent_Ten
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = GetNumber();
            int l = GetNumber();

            if (GetSquare(i, l) == 0)
            {
                Console.WriteLine(" некоpректные данные");
            }
            else
            {
                Console.WriteLine(GetSquare(i, l));
            }

            // вызов второй задачи ;

            // string N_string = Console.ReadLine();

            int n = GetNumber();
            Console.WriteLine(TRIANGLE(n));

        }

        public static int GetSquare(int a, int b)                 // task 1.1.1
        {

            int square = a * b;

            if (a <= 0 || b <= 0)
            {
                return 0;
            }

            return square;
        }

        public static int GetNumber()                            // string v int
        {
            string command_1 = Console.ReadLine();

            int i = 0;

            int.TryParse(command_1, out i);

            return i;
        }

        public static string TRIANGLEEEE( int n)                  //task 1.1.2 крик души :D
        {
            string star = "*"+ " \n";

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    star = star + "*" ;  
                }
                star = star + "\n";
            }
            
            return star;
        }


    } 

}
