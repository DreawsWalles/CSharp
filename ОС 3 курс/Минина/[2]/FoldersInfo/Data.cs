using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldersInfo
{
    public class Data : IDisposable
    {
        #region Properties

        /// <summary>
        /// Всего файлов
        /// </summary>
        public int All { get; set; }

        /// <summary>
        /// Скрытые файлы
        /// </summary>
        public int Hidden { get; set; }

        /// <summary>
        /// Архивные файлы
        /// </summary>
        public int Archives { get; set; }

        /// <summary>
        /// Файлы только для чтения
        /// </summary>
        public int ReadOnly { get; set; }

        /// <summary>
        /// Системные файлы
        /// </summary>
        public int System { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        public Data() { }

        #endregion

        #region Methods

        /// <summary>
        /// Перегрузка метода
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Environment.NewLine + 
                   "Всего: " + All + Environment.NewLine +
                   "Скрытые: " + Hidden + Environment.NewLine +
                   "Для чтения: " + ReadOnly + Environment.NewLine +
                   "Архивные: " + Archives + Environment.NewLine +
                   "Системные: " + System + Environment.NewLine;
        }

        /// <summary>
        /// Реализация метода освобождения памяти
        /// </summary>
        public void Dispose()
        {
            
        }

        /// <summary>
        /// Метод подсчета поля всего
        /// </summary>
        public void CountAll()
        {
            All = Hidden + 
                  ReadOnly + 
                  Archives + 
                  System;
        }

        #endregion
    }
}
