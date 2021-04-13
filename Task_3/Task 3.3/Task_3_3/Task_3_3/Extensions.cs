using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Task_3_3
{
    static class Extensions
    {
        public static void DoSomething(this int[] array, Func<int, int> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }
        }
        
        public static int GetSumm(this int[] array)
        {
            var summ = 0;

            array.ToList().ForEach(i => summ += i);

            return summ;
        }

        public static double GetAverageValue(this int[] array)
        {
            return array.GetSumm() / array.Length;
        }
        public static int GetFrequently(this int[] array)
        {
            var dictionary = new Dictionary<int, int>();

            array.ToList().ForEach(i =>
            {
                AddToDictionary(array, i, dictionary);
            });

            var frequently = 0;

            foreach (var item in dictionary)
            {
                if (item.Value > frequently)
                    frequently = item.Value;
            }

            return dictionary.Where(dict => dict.Value == frequently).ToList()[0].Key;
        }

        private static void AddToDictionary(int[] array, int i, Dictionary<int, int> dictionary)
        {
            var isAdded = dictionary.TryAdd(i, 1);

            if (!isAdded)
            {
                dictionary[i] = dictionary[i]++;
            }
        }
    }
}
