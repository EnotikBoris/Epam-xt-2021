using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    /// <summary>
    /// окружность
    /// </summary>
    class Circle
    {
       // Figure figure = new Figure();                     //
        public Circle(int radius, Point p)
        {
            Radius = radius;
            Point point = new Point();
        }

        public  int Radius { get;}

        public double OverradePirimetr 
        {
            get
            {
                return 3.14 * 2 * Radius;
            }
        }



    }
}
