using System;
using System.Collections.Generic;
using System.Text;

namespace MuGeme
{
    /// <summary>
    /// репсонаж
    /// </summary>
    abstract class Person : GameObject
    {
        public int Speed { get; }   
        public int Leves { get; }
        public Person(Point p, int speed, int leves, string name) : base(p , name)
        {
            Speed = speed;
            Leves = leves;
        }
        
    }
}
