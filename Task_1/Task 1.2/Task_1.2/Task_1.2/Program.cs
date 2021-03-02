using System;

namespace Task_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите номер задачи:");
                string taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":
                        NumberOfLetters();
                        break;
                    case "2":
                        Doubler();
                        break;
                    case "3":
                        LowerCase();
                        break;
                    case "4":
                        Validation();
                        break;
                    default:
                        Console.WriteLine("Такой задачи нет");
                        break;
                }
            }
            

        }

        public static int NumberOfLetters()                 // TASK 1.2.1
        {
            Console.WriteLine("ввод: ");
            string input = Console.ReadLine();
            int ind = 0;                                // кол-во букв
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))       
                    ind++;
            }

            string[] subs = input.Split(' ');                             

            int a = ind / subs.Length;                  // Кол слов / кол букв
            Console.WriteLine(a);   

            return a;
        }
        public static void Doubler()                            //TASK 1.2.2
        {
            string vod1 = Console.ReadLine();
            string vod2 = Console.ReadLine();
            
            char[] a = vod2.ToCharArray();
            foreach (var item in a)
            {
                if (vod1.Contains(item) && char.IsLetter(item))
                {
                   vod1 = vod1.Replace(item.ToString(), item.ToString() + item);
                }
            }

            Console.WriteLine(vod1);
        }

        public static void LowerCase()
        {
            string vod = Console.ReadLine();
            char[] separators = new char[] { '.', '!', '?', ' ', ',' };

            string[] subs = vod.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int summ = GetSumm(subs);

            Console.WriteLine(summ);
        }

        public static void Validation()
        {
            string vod = Console.ReadLine();
            char[] separators = new char[] { '.', '!', '?' };

            foreach (var separator in separators)
            {
                string[] sub = vod.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                if (sub.Length > 1)
                {
                    vod = "";
                }

                foreach (var s in sub)
                {
                    if (sub.Length > 1)
                    {
                        char[] symbs = s.Trim().ToCharArray();

                        symbs[0] = char.ToUpper(symbs[0]);

                        vod
                            \+= new String(symbs) + separator + ' ';
                    }
                }
            }

            Console.WriteLine(vod);

        }

        private static int GetSumm(string[] subs)
        {
            int summ = 0;

            foreach (var sub in subs)
            {
                foreach (var s in sub)
                {
                    if (s != ' ' && char.IsUpper(s))
                    {
                        break;
                    }
                    else if (s != ' ' && char.IsLower(s))
                    {
                        summ++;
                        break;
                    }
                }
            }

            return summ;
        }


    }
}
