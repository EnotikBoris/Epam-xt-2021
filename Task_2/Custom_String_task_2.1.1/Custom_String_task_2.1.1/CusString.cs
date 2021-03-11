using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_String_task_2._1._1
{
    class CusString : ICusString
    {
        private char[] _array;

        public CusString(char[] array)                                    // конструктор который конвертирует из массива символов 
        {
            _array = array;
        }

        public bool Compare(ICusString cusString)                       // (реализация интерфейса /выполнили контракт ) метод сравнения
        {
            //  throw new NotImplementedException();
            char[] array = cusString.ToChatArray();

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

        public char[] ToChatArray()                                      // конвертация в массив символов
        {
            // throw new NotImplementedException();
            return _array;
        }
    }
}
