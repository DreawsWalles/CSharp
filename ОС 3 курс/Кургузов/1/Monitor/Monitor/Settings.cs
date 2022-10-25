using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public class Settings : IDisposable
    {
        #region Properties

        /// <summary>
        /// Контрол для писателей
        /// </summary>
        public TextBox TxtWriter { get; set; }

        /// <summary>
        /// Контрол для читателей
        /// </summary>
        public TextBox TxtReader { get; set; }

        /// <summary>
        /// Контрол для буффера
        /// </summary>
        public TextBox TxtBuffer { get; set; }

        /// <summary>
        /// Количество потоков
        /// </summary>
        public int ThreadsNumder { get; set; }

        /// <summary>
        /// Количество обращений к буфферу
        /// </summary>
        public int ActionsNumber { get; set; }

        /// <summary>
        /// Размер буффера
        /// </summary>
        public int BufferSize { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="reader"></param>
        /// <param name="buffer"></param>
        /// <param name="threadsnumber"></param>
        /// <param name="actionsnumber"></param>
        public Settings(TextBox writer, TextBox reader, TextBox buffer, int threadsnumber, int actionsnumber, int buffersize)
        {
            TxtWriter = writer;
            TxtReader = reader;
            TxtBuffer = buffer;

            ThreadsNumder = threadsnumber;
            ActionsNumber = actionsnumber;
            BufferSize = buffersize;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Settings()
        {
            
        }

        /// <summary>
        /// Деструктор
        /// </summary>
        public void Dispose()
        {
            TxtBuffer = null;
            TxtWriter = null;
            TxtReader = null;
        }

        #endregion
    }
}
