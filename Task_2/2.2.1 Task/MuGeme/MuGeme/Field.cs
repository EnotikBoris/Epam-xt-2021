using System;
using System.Collections.Generic;
using System.Text;

namespace MuGeme
{
    /// <summary>
    /// поле
    /// </summary>
    class Field
    {
        List<GameObject> go;
        public Field(int width, int length)
        {

        }

        public int Width { get; }
        public int Length { get; }

        public void AddObject(GameObject obj)
        {
            throw new NotImplementedException();                            // в том случае если мы не риализовываем ни чего 
        }


    }
}
