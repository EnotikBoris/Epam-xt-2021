using System;
using System.Collections.Generic;
using System.Text;

namespace MuGeme
{
    /// <summary>
    /// персонаж
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


        public void Move(PlayerMovement movement)
        {
            switch (movement)
            {
                case PlayerMovement.Left: P.X--;
                    break;
                case PlayerMovement.Right: P.X++;
                    break;
                case PlayerMovement.Up: P.Y--;
                    break;
                case PlayerMovement.Down: P.Y++;
                    break;
                default:
                    break;
            }
        }
        
    }
}
