using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    /// <summary>
    /// фигура
    /// </summary>
     abstract class Figure
    {
       public Figure(Point p)
        {
            P = p;
        }

        public Point P { get; }
        public abstract double Perimeter { get; }
    }
}
