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

            // вызов 2й задачи ;

            int n_2 = GetNumber();
            Console.WriteLine(TRIANGLEEEE(n_2));

            //вызов 3й задачи

            int n_3 = GetNumber();
            Console.WriteLine(ANOTHER_TRIANGLE(n_3));

            // вызов 4й задачи

            int n_4 = GetNumber();
            Console.WriteLine(Herringbone(n_4));


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

        public static string TRIANGLEEEE( int n)                  //task 1.1.2 
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

        public static string ANOTHER_TRIANGLE(int n, int отступ = 0)             //Task 1.1.3 
        {
            string triangle = "";
            int number_of_spaces = n;

            for (int i = 0; i < n; i++)
            {
                number_of_spaces--;

                string star = "";
                star = star.PadLeft(отступ + number_of_spaces, ' ');                // делаем пробелы       make spaces

                addStar(ref triangle, i, ref star);
            }

            return triangle;
        }

        public static string Herringbone(int n)
        {
            string herringbone = "";
            int N = n;

            for (int i = 0; i < n; i++)
            {
                herringbone = herringbone + ANOTHER_TRIANGLE(i, N );
                N --;
            }
            
            return herringbone;
        }

        private static void addStar(ref string triangle, int i, ref string star)                // making stars
        {
            star = star + "*";

            for (int a = 0; a < i; a++)
            {
                star = star + "**";
            }

            star = star + "\n";
            triangle = triangle + star;
        }

        
    } 


}
