using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_3_3_2
{
    public static class Extensions
    {
        public static WordCategory GetWordCategory(this string s)
        {
            var regexForRussian = new Regex(@"^[А-Яа-я][А-Яа-я]+[А-Яа-я]$");
            var regezForEnglish = new Regex(@"^[A-Za-z][A-Za-z]*[A-Za-z]$");
            var regexForNumbers = new Regex(@"^\d\d*\d$");

            if (regexForRussian.IsMatch(s))
            {
                return WordCategory.Ru;
            }else if (regezForEnglish.IsMatch(s))
            {
                return WordCategory.En;
            }else if (regexForNumbers.IsMatch(s))
            {
                return WordCategory.Number;
            }
            else
            {
                return WordCategory.Mixed;
            }
        }
    }

    public enum WordCategory
    {
        Ru = 1,
        En = 2,
        Number = 3,
        Mixed = 4,
    }
}
