using System;
using System.Collections.Generic;
using System.Text;

namespace MuGeme
{
    /// <summary>
    /// игрок
    /// </summary>
    class Player : Person
    {
        public int Record { get; private set; }

        public Player(Point p, int leves, int speed, string name) : base(p, speed, leves, name)
        {

        }

        
    }
}
