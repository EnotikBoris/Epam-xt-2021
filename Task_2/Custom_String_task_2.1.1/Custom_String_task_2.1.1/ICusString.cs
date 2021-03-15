using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_String_task_2._1._1
{
    interface ICusString
    {
        char[] ToCharArray();                                                         // объявила метод по конвертации 
        bool Compare(ICusString cusString);                                         // сравнение
        int IndexOf(char value);                                                     // поиск символов
        ICusString ConCat(ICusString cusString);                                    //конкатенация ( сложение строк)
        

        
    }
}
