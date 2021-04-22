using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class BLLEntity
    {
        /// <summary>
        /// Команды
        /// </summary>
        public string CommandName { get; set; }
        /// <summary>
        /// Содержание файла
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Имя папки
        /// </summary>
        public string FolderName { get; set; }
    }
}
