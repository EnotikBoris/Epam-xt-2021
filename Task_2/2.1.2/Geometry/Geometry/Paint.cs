using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    class Paint
    {
        private List<Figure> Figures { get; }

        public Paint()
        {
            Figures = new List<Figure>();
        }

        public void AddRectangle()
        {
            var p1 = ReadPoint(1);
            var p2 = ReadPoint(2);
            var p3 = ReadPoint(3);
            var p4 = ReadPoint(4);

            var rect = new Rectangle(p1, p2, p3, p4);

            Figures.Add(rect);
        }
        
        public void AddSquare()
        {
            var p1 = ReadPoint(1);
            var p2 = ReadPoint(2);
            var p3 = ReadPoint(3);
            var p4 = ReadPoint(4);

            var square = new SquareFigure(p1, p2, p3, p4);

            Figures.Add(square);
        }

        public void AddCircle()
        {
            var circle = new Circle(ReadRadius(), ReadPoint());

            Figures.Add(circle);
        }
        
        public void AddRound()
        {
            var round = new Round(ReadPoint(), ReadRadius());

            Figures.Add(round);
        }
        
        public void AddRing()
        {
            var ring = new Ring(ReadRadius(), ReadRadius("внутренний"), ReadPoint());

            Figures.Add(ring);
        }

        public void Show()
        {
            foreach (var figure in Figures)
            {
                Console.WriteLine(figure);
            }
        }

        public void Clear()
        {
            Figures.Clear();
        }

        private Point ReadPoint(int? number = null)
        {
            Console.WriteLine($"Введите координаты точки {(number.HasValue?number.Value.ToString():null)}");

            if (int.TryParse(Console.ReadLine(), out int x) 
                && int.TryParse(Console.ReadLine(), out int y))
            {
                return new Point { X = x, Y = y, };
            }

            throw new ArgumentNullException("Требуется ввести в качестве координат число");
        }

        private int ReadRadius(string option = null)
        {
            Console.WriteLine($"Введите {option} радиус");

            if (int.TryParse(Console.ReadLine(), out int x))
            {
                return x;
            }

            throw new ArgumentNullException("Требуется ввести в качестве координат число");
        }
    }
}
