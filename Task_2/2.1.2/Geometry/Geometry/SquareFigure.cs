using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    class SquareFigure : Figure
    {
        /// <summary>
        /// квадрут
        /// </summary>
        /// <param name="p1">.1</param>
        /// <param name="p2">.2</param>
        /// <param name="p3">.3</param>
        /// <param name="p4">.4</param>
        public SquareFigure(Point p1, Point p2, Point p3, Point p4) : base(p1)
        {
            P2 = p2;
            P3 = p3;
            P4 = p4;
        }

        public Point P2 { get; set; }
        public Point P3 { get; set; }
        public Point P4 { get; set; }
        public override double Perimeter => 4 * (P.X - P2.X);
        public double Square => (P.X - P2.X) * (P.X - P2.X);

        public override string ToString()
        {
            return $"Квадрат: Периметр - {Perimeter} --- Площадь - {Square}";
        }
    }
}
