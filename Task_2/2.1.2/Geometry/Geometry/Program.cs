using System;

namespace Geometry
{
    class Program
    {
        private static bool isWorking = true;

        static void Main(string[] args)
        {
            Paint paint = new Paint();
            
            while (isWorking)
            {
                Work(paint);
            }
        }

        static void Work(Paint paint)
        {
            Console.WriteLine($"Введите действие: {Environment.NewLine}" +
                $"1. Добавить Круг. {Environment.NewLine}" +
                $"2. Добавить Кольцо. {Environment.NewLine}" +
                $"3. Добавить Окружность. {Environment.NewLine}" +
                $"4. Добавить Квадрат. {Environment.NewLine}" +
                $"5. Добавить Прямоугольник. {Environment.NewLine}" +
                $"show. Показать все фигуры {Environment.NewLine}" +
                $"clear. Удалить все фигуры {Environment.NewLine}" +
                $"0. Выход");

            switch (Console.ReadLine())
            {
                case "1":
                    paint.AddRound();
                    break;
                case "2":
                    paint.AddRing();
                    break;
                case "3":
                    paint.AddCircle();
                    break;
                case "4":
                    paint.AddSquare();
                    break;
                case "5":
                    paint.AddRectangle();
                    break;
                case "0":
                    isWorking = false;
                    break;
                case "show":
                    paint.Show();
                    break;
                case "clear":
                    paint.Clear();
                    break;
                default:
                    break;
            }
        }
    }
}
