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

            int n_2 = GetNumber();
            Console.WriteLine(TRIANGLEEEE(n_2));

            //
            вызов третий задачи

            int n_3 = GetNumber();
            Console.WriteLine(ANOTHER_TRIANGLE(n_3));



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

        public static string ANOTHER_TRIANGLE(int n)             //Task 1.1.3 
        {
            if (n == 1)
            {
                return "*";
            }

            string star = "";
            int number_of_spaces = n;

            for (int i = 0; i < n; i++)
            {
                string spaces = "";

                for (int j = 0; j < number_of_spaces; j++)
                {
                    spaces = spaces + " ";
                }

                number_of_spaces --;
                star = star + spaces + "*"; // Добавляем пробелы к следующей строке + 1 звезду для того, чтобы было нечётное количесвто звёзд

                for (int a = 0; a < i; a++)
                {
                    star = star + "**";
                }
                star = star + "\n";
            }

            return star;
        }



       // public static int 









    } 


}
