using System;
using System.Collections.Generic;
using System.Text;

namespace MuGeme
{
    /// <summary>
    /// игровой объект
    /// </summary>
    class GameObject 
    {  
        /// <summary>
        ///  агригация
        /// </summary>
        Point p;

        public GameObject(Point p, String name)
        {

        }
        public Point P { get; set; }

        public String Name { get; }



    }
}
