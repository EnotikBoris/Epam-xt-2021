using System;

namespace ArrayProcesseng1._1._7
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine( "Task 1.1.7 : ");
             taska1_1_7();
          
            //  task 1.1.8

            Console.WriteLine("Task 1.1.8 : ");
            GenirateArray(3, 3, 3);

            //   task 1.1.9

            Console.WriteLine("Task 1.1.9 : ");
            Console.WriteLine(PositiveSumm());

        }

        private static int PositiveSumm()
        {
            int summa = 0;
            int[] r = new int[10];

            RandomArr(r);

            for(int i = 0; i < r.Length; ++i)
            {
                if (r[i] >= 0 )
                {
                     summa = summa + r[i];
                }
            }
              
            return summa;
        }

        private static int[,,] GenirateArray(int i, int j, int s)           // Task 1.1.8
        {
            int[,,] arr2 = new int[i, j, s];
            Random rand = new Random();

            AddValues(i, j, s, arr2, rand);
            ChangeValues(i, j, s, arr2);

            for (int x = 0; x < i; x++)                                  // вывод на экран
            {
                for (int y = 0; y < j; y++)
                {
                    for (int z = 0; z < s; z++)
                    {
                        Console.Write(arr2[x, y, z] + " ");
                    }
                    Console.WriteLine();
                }
            }

            

            return arr2;
        }

        private static void ChangeValues(int i, int j, int s, int[,,] arr2)                         //1.1.8
        {
            for (int x = 0; x < i; x++)
            {
                for (int y = 0; y < j; y++)
                {
                    for (int z = 0; z < s; z++)
                    {
                        if (arr2[x, y, z] > 0)
                        {
                            arr2[x, y, z] = 0;
                        }
                    }
                }
            }
        }

        private static void AddValues(int i, int j, int s, int[,,] arr2, Random rand)                   // 1.1.8
        {
            for (int x = 0; x < i; x++)
            {
                for (int y = 0; y < j; y++)
                {
                    for (int z = 0; z < s; z++)
                    {
                        arr2[x, y, z] = rand.Next(-10, 10);
                    }
                }
            }
        }

        private static void taska1_1_7()                        // task 1.1.7
        {
            int[] arr = new int[10];

            // вызоврандомного массива

            RandomArr(arr);
            Printarray(arr);

            Console.WriteLine("stage 2");

            // сортировка

            Sort(arr);
            Printarray(arr);

            // поиск максимального и минимального

            int min = arr[0];
            int max = arr[arr.Length - 1];

            Console.WriteLine("min: " + min);
            Console.WriteLine("max: " + max);
        }

        private static void Printarray(int[] arr)                   // 1.1.7
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }

        private static void Sort(int[] arr)                             // 1.1.7
        {
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;


                    }
                }
            }
        }

        private static void RandomArr(int[] arr)                    //1.1.7
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = rand.Next(-10, 10);
        }
    }
}
