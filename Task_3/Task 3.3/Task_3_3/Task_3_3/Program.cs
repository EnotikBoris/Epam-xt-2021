using System;
using System.Linq;

namespace Task_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"Выберите задачу:{Environment.NewLine}" +
                $"1. 3.3.1 {Environment.NewLine}" +
                $"2. 3.3.3 {Environment.NewLine}");

            if (int.TryParse(Console.ReadLine(), out int i))
            {
                switch (i)
                {
                    case 1:
                        FirstTaskExample();
                        break;
                    case 2:
                        ThirdTaskExample();
                        break;
                    default:
                        break;
                }
            }

        }

        private static void FirstTaskExample()
        {
            var array = new int[] { 4, 1, 2, 3, 4, 5, 6, 7, 8, 1, 1, 8, 8, 8, 8, 8, 8, 8, 8, 3, 3, 3, 3, 3, 3, 3, 3, 3 };

            array.DoSomething(i => i * 2);
            Console.WriteLine($"Summ: {array.GetSumm()}");
            Console.WriteLine($"Frequently: {array.GetFrequently()}");
            Console.WriteLine(array.GetAverageValue());

            array.ToList().ForEach(i => Console.WriteLine(i));
        }

        private static void ThirdTaskExample()
        {
            Console.WriteLine("Введите имя, вид пиццы и её цену");

            var name = Console.ReadLine();
            var pizzaType = Console.ReadLine();
            var cost = int.Parse(Console.ReadLine());

            var user = new User { Name = name };
            var pizza = new Pizza { Name = "Пицца 4 сыра", Price = 880 };

            var restoraunt = new Restaraunt();

            restoraunt.OnCreated += (user, pizza) => Console.WriteLine($"{pizza.Name} за {pizza.Price} готова. {user.Name} заберите заказ.");

            restoraunt.CreatePizza(pizza, user);
        }
    }
}
