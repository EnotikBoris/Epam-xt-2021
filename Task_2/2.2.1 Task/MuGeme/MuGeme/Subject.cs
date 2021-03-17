using System;
using System.Collections.Generic;
using System.Text;



namespace MuGeme
{
    /// <summary>
    /// субъект
    /// </summary>
   abstract class Subject : GameObject
    {
        public int Size { get; }

        public Subject(Point p, int size)
        {

        }
    }
}
