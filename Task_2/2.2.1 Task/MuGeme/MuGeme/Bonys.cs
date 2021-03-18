using System;
using System.Collections.Generic;
using System.Text;

namespace MuGeme
{
    /// <summary>
    /// бонус
    /// </summary>
    class Bonys : Subject
    {
        public int Amount { get; }

        public Bonys(Point p, String name, int amount) : base(p, name)
        {

        }
    }
}
