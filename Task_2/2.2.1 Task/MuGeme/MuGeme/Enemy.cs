using System;
using System.Collections.Generic;
using System.Text;

namespace MuGeme
{
    /// <summary>
    /// враг
    /// </summary>
    class Enemy : Person
    {
        //EnemeType et;

        public EnemeType Type { get;}

        public Enemy(EnemeType type, Point p, int leves , int speed, string name) : base(p, speed, leves, name)
        {
            Type = type;
        }
    }
}
