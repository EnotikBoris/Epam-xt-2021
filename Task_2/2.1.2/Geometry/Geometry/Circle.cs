using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    /// <summary>
    /// окружность
    /// </summary>
    class Circle : Figure
    {
       // Figure figure = new Figure();                     //
        public Circle(int radius, Point p) : base (p)
        {
            Radius = radius;
            Point point = new Point();
        }

        public  int Radius { get;}

        public override double Perimeter
        {
            get
            {
                return 3.14 * 2 * Radius;
            }
        }

        public override string ToString()
        {
            return $"Окружность: Периметр - {Perimeter}";
        }
    }
}
