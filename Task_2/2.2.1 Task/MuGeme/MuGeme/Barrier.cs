using System;
using System.Collections.Generic;
using System.Text;

namespace MuGeme
{
    /// <summary>
    /// барьер репятст
    /// </summary>
    class Barrier : Subject
    {
        public Barrier(Point p, String name, Point p2, Point length) : base(p, name)
        {
            P2 = p2;
            Length = length;
        }

        public Point P2 { get; }
        public Point Length { get; }
    }
}
