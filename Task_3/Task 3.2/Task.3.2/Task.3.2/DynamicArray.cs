using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task._3._2
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>, ICloneable, IEnumerator<T>, IEnumerator
    {
        private T[] _array;
        private int _capacity;
        protected int _current = -1;

        #region CTORS

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity">Capacity - максимальная ёмкость массива до пересоздания массива</param>
        public DynamicArray(int capacity)
        {
            InitializeArray(capacity);
        }

        public DynamicArray()
        {
            InitializeArray(8);
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            var count = collection.Count();
            Capacity = count;
            _capacity = count;
            _array = new T[count];

            CopyCollection(collection);
        }

        #endregion

        public T this [int i]
        {
            get 
            {
                if (i >= 0)
                    return GetElement(i);
                else
                    return GetElementRevers(i);
            }
            set 
            {
                if (i < Length)
                {
                    _array[i] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }

            }
        }

        /// <summary>
        /// Ёмкость
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Количество заполненых элементов массива
        /// </summary>
        public int Length { get => _capacity; 
            private set 
            {
                if (Capacity - 1 == Length)
                {
                    var array = (IEnumerable<T>)_array.Clone();

                    Capacity *= 2;
                    _array = new T[Capacity];

                    CopyCollection(array);
                }

                _capacity = value;
            }
        }

        public object Current => _array[_current];

        T IEnumerator<T>.Current => _array[_current];

        public void Add(T item)
        {
            if (Length - 1 == Capacity)
            {
                Capacity = Capacity * 2;
            }

            _array[Length] = item;
            Length++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            Capacity = Capacity + collection.Count();

            var array = (T[])_array.Clone();
            _array = new T[Capacity];

            CopyCollection(array);

            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public bool Remove(T item)
        {
            var array = (T[])_array.Clone();

            for (int i = 0; i < _array.Length; i++)
            {
                bool isEquals = ((array[i]!?.Equals(item)).HasValue ? array[i]!.Equals(item) : false);

                if (isEquals)
                {
                    _array[i] = default;
                }
            }

            if (Length != array.Length)
            {
                return true;
            }

            return false;
        }

        public int Find(T item)
        {
            var index = 0;

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public bool Insert(T item, int index)
        {
            if (index < Capacity)
            {
                _array[index] = item;

                return true;
            }

            return false;
        }

        public T[] ToArray()
        {
            return (T[])_array.Clone();
        }

        public object Clone()
        {
            return new DynamicArray<T>(_array);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public virtual bool MoveNext()
        {
            if (_current < Length)
            {
                _current++;

                return true;
            }

            return false;
        }

        public void Reset()
        {
            _current = -1;
        }

        public void Dispose()
        {
        }

        public override string ToString()
        {
            var sb = new StringBuilder(_capacity);

            foreach (var item in _array)
            {
                sb.Append(item?.ToString() + " \n");
            }

            return sb.ToString();
        }

        private void CopyCollection(IEnumerable<T> collection)
        {
            _capacity = 0;
            foreach (var item in collection)
            {
                if (_array.Length > 0)
                {
                    if (Length < Capacity)
                    {
                        _array[_capacity] = item;
                        _capacity++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private T GetElementRevers(int i)
        {
            i = Math.Abs(i);
            var array = _array.Reverse().ToArray();
            var toggle = new DynamicArray<T>(array);

            return toggle.GetElement(i);
        }

        private T GetElement(int i)
        {
            if (i < Length)
            {
                return _array[i];
            }

            throw new ArgumentOutOfRangeException();
        }

        private void InitializeArray(int capacity)
        {
            _array = new T[capacity];
            Capacity = capacity;
            Length = 0;
        }
    }
}
