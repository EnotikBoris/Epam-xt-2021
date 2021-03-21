using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Custom_String_task_2._1._1
{
    class CusString : ICusString, IEnumerable<char>, IEnumerator<char>, IEnumerator
    {
        private char[] _array;
        int _position = -1;

        public CusString()
        {
        }

        /// <summary>
        /// конструктор который конвертирует из массива символов
        /// </summary>
        /// <param name="array"></param>
        public CusString(char[] array)                                    
        {
            _array = array;
        }

        #region EnumeratorProps
        public object Current => _array[_position];

        char IEnumerator<char>.Current => _array[_position];
        #endregion

        #region String
        /// <summary>
        /// (реализация интерфейса /выполнили контракт ) метод сравнения
        /// </summary>
        /// <param name="cusString"></param>
        /// <returns></returns>
        public bool Compare(ICusString cusString)                       
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

        /// <summary>
        /// сложение строк
        /// </summary>
        /// <param name="cusString"></param>
        /// <returns></returns>
        public ICusString ConCat(ICusString cusString)                     
        {
            List<char> resArray = new List<char>();
            resArray.AddRange(_array);
            resArray.AddRange(cusString.ToCharArray());                     // ToCharArray  превращает наш кус стринг в массив символов

            Char[] res = resArray.ToArray();

            return new CusString(res);
        }

        /// <summary>
        /// конвертация в массив символов
        /// </summary>
        /// <returns></returns>
        public char[] ToCharArray()
        {
            // throw new NotImplementedException();
            return _array;
        }

        /// <summary>
        ///Возвращает -1, если нет такого символа
        /// </summary>
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

        public static CusString operator +(CusString firstString, CusString secondString)
        {
            return (CusString)firstString.ConCat(secondString);
        }
        
        public static CusString operator +(CusString firstString, string secondString)
        {
            return (CusString)firstString.ConCat(new CusString(secondString.ToCharArray()));
        }

        public static bool operator ==(CusString firstString, CusString secondString)
        {
            return firstString.Equals(secondString);
        }
        
        public static bool operator !=(CusString firstString, CusString secondString)
        {
            return !firstString.Equals(secondString);
        }
        #endregion

        #region IEnumerableMethods
        public bool MoveNext()
        {
            if (_position < _array.Length-1)
            {
                _position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _position = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public void Dispose()
        {
            
        }

        public IEnumerator<char> GetEnumerator()
        {
            return this;
        }
        #endregion

        public override string ToString()
        {
            return new string(_array);
        }

        public override bool Equals(object obj)
        {
            if (obj is CusString)
            {
                return Equals(obj as CusString);
            }

            return false;
        }
        public bool Equals(CusString str)
        {
            return Compare(str);
        }
    }
}
