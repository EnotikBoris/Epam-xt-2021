using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task_3._1._1
{
    class TextAnalyser
    {
        private string _text;
        private Dictionary<string, int> _words = new Dictionary<string, int>();
        
        public TextAnalyser(string text)
        {
            _text = text;
        }

        public TextAnalyser Analyse()
        {
            char[] separators = new char[] { '.', '!', '?', ' ', ',' };         // массив

            var words = _text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                if (_words.ContainsKey(word)) 
                {
                    _words[word] = _words[word] + 1;
                }
                else
                {
                    _words.Add(word, 1);
                }

            }

            return this;
        }

        public void Show()
        {
            _words = _words.OrderByDescending(w => w.Value).ToDictionary(key => key.Key, value => value.Value);

            int counter = 0;

            foreach (var word in _words)
            {
                Console.WriteLine($"{word.Key} --- {word.Value}");
                counter++;

                if (counter == 5)
                    break;
            }
        }
    }
}
