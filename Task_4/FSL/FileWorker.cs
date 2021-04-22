using FSL.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FSL
{
    class FileWorker : IFileWorker
    {
        protected string _path;

        public FileWorker(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string ReadFile(string fileName)
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                try
                {
                    var res = sr.ReadToEnd();
                    return res;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Запись
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool WriteFile(string fileName, string text)
        {
            using (StreamWriter sw = new StreamWriter(_path, false, System.Text.Encoding.Default))
            {
                try
                {
                    sw.WriteLine(text);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
