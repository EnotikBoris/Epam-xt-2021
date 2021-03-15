using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_String_task_2._1._1
{
    class CusString : ICusString
    {
        private char[] _array;

        public CusString()
        {
        }

        public CusString(char[] array)                                    // конструктор который конвертирует из массива символов 
        {
            
            _array = array;
        }

        public bool Compare(ICusString cusString)                       // (реализация интерфейса /выполнили контракт ) метод сравнения
        {
            //  throw new NotImplementedException();
            char[] array = cusString.ToCharArray();

            if (array.Length != _array.Length)                          // спавнение на длину массива
            {
                return false;
            }

            for (int i = 0; i < array.Length; i++)                       // посимвольное сравнение 
            {
                if (array[i] != _array[i])
                {
                    return false;
                }
            }
            return true;
        }

        public ICusString ConCat(ICusString cusString)                      // сложение строк
        {
            List<char> resArray = new List<char>();
            resArray.AddRange(_array);
            resArray.AddRange(cusString.ToCharArray());                     // ToCharArray  превращает наш кус стринг в массив символов

            Char[] res = resArray.ToArray();

            return new CusString(res);
        }

        // Возвращает -1, если нет такого символа
        public int IndexOf(char value)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

       

        public char[] ToCharArray()                                      // конвертация в массив символов
        {
            // throw new NotImplementedException();
            return _array;
        }
    }
}
