using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1._1
{
    class WeakestLink
    {
        private string[] _names = new string[] { "Игорь", "Ваня", "Даша", "Мага", "Маша", "Петро", "Дима", "Дина", "Лёша", "Галя", "Валя", 
            "Валентина", "Андрей", "Геральт", "Цирилла", "Гермиона", "Harry", "Рон", "Тоби", "Леголас", "Роланд", "Фродо", "Дамблдор",
            "Гимли", "Бильбо", "Гэндальф", "Северус Снейп"};

        private int _n;
        private int _step;
        private int _counter = 1;
        private List<string> _peoples;

        public WeakestLink(int n) : this(n, 2)
        {
        }

        public WeakestLink(int n, int step)
        {
            _n = n;
            _step = step;

            FillPeoples();
        }

        public void Run()
        {
            int i = 0;

            while (true)
            {
                ReCreate();

                if (_peoples.Count >= _step)
                {
                    i = UpdateCounter(i);

                    DropPeople(i);
                    i++;
                }
                else
                {
                    Console.WriteLine("Не могу больше удалять чуловеков © Бэндер");
                    break;
                }
            }
        }

        private int UpdateCounter(int i)
        {
            if (i >= _peoples.Count - 1)
            {
                i = 0;
            }

            return i;
        }

        private void ReCreate()
            => _peoples.RemoveAll(s => s.Equals(string.Empty));

        private void DropPeople(int counter)
        {
            if (_counter % _step == 0)
            {
                Console.WriteLine($"Был удалён {_peoples[counter]}, осталось {_peoples.Count} человеков. © Бэндер");
                _peoples[counter] = string.Empty; //""
            }

            _counter++;
        }

        private void FillPeoples()
        {
            _peoples = new List<string>(_n);
            var rnd = new Random();

            for (int i = 0; i < _peoples.Capacity; i++)
            {
                _peoples.Add(_names[rnd.Next(0, _names.Length - 1)]);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < _peoples.Count ; i++)
            {
                sb.Append($"{_peoples[i]} --- {i + 1} \n");
            }

            return sb.ToString();
        }
    }
}
