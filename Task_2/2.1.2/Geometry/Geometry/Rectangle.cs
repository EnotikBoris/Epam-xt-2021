using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    /// <summary>
    /// прямоугольник
    /// </summary>
    class Rectangle : Figure
    {
        public Rectangle(Point p1, Point p2, Point p3, Point p4) : base (p1)
        {
            P2 = p2;
            P3 = p3;
            P4 = p4;
        }

        public Point P2 { get; set; }
        public Point P3 { get; set; }
        public Point P4 { get; set; }
        public override double Perimeter => 2 * (P.X - P2.X + P3.Y - P4.Y);
        public double Square => (P.X - P2.X) * (P3.Y - P4.Y);

        public override string ToString()
        {
            return $"Прямоугольник: Периметр - {Perimeter} --- Площадь {Square}";
        }
    }
}
