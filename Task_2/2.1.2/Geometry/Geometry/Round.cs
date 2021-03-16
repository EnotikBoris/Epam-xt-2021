using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    /// <summary>
    /// круг
    /// </summary>
    internal class Round : Circle
    {
        public Round(Point p, int radius) : base(radius, p)
        {

        }

        public double Square{ get => 3.14 * Radius * Radius;  }

        public override string ToString()
        {
            return $"Круг: Периметр - {Perimeter} --- Площадь - {Square}";
        }
    }
}
