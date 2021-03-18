using System;
using System.Collections.Generic;
using System.Text;

namespace MuGeme
{
    /// <summary>
    /// игровой объект
    /// </summary>
    abstract class GameObject 
    {  
        public GameObject(Point p, String name)
        {
            P = p;
            Name = name;
        }
        public Point P { get; set; }

        public String Name { get; }



    }
}
