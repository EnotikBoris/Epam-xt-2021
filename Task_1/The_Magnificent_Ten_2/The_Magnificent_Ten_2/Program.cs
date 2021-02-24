using System;

namespace The_Magnificent_Ten_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // вызов Таски 1.1.5
            Console.WriteLine("Task 1.1.5 \n");
           Summ() ;
            Console.Write("\n");
            
            // task 1.1.6
            Console.WriteLine("Task 1.1.6\n");
            FontAdjustment();

            
        }

        public static void Summ()           // TASK 1.1.5
        {
            int nome = 0;

            for (int i = 0; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    nome += i;
                }

            }

            Console.WriteLine(nome);
        }

        public static void FontAdjustment()                 // Task 1.1.6
        {
           

            string command = Console.ReadLine();

            Fonts fonts = Fonts.None;

            while (true)
            {
                Console.WriteLine("параметры надписи: " + fonts);
                Console.WriteLine("Введите: ");
                Console.WriteLine("\t 1: boid ");
                Console.WriteLine("\t 2: italic");
                Console.WriteLine("\t 3: underline");

                 fonts = ifir(fonts);
            }

        }

        public static Fonts ifir(Fonts fonts)
        {
            if (int.TryParse(Console.ReadLine(), out int font))
            {
                int increment = 0;

                switch (font)
                {
                    case 1:
                        increment = fonts.HasFlag(Fonts.bold) ? -1 : 1;
                        break;
                    case 2:
                        increment = fonts.HasFlag(Fonts.italic) ? -2 : 2;
                        break;
                    case 3:
                        increment = fonts.HasFlag(Fonts.underline) ? -4 : 4;
                        break;
                }

                fonts += increment;
            }

            return fonts;
        }

        [Flags]       
         public enum Fonts
        {
            None = 0,
            bold = 1,
            italic = 2,
            underline = 4,
        }

        public static
       

    }
}
