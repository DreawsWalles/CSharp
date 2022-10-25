using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public class Buffer : IDisposable
    {
        #region Fields

        /// <summary>
        /// Контрол для вывода информации
        /// </summary>
        private TextBox _tbOutput = null;

        #endregion

        #region Properties

        /// <summary>
        /// Структура данных для информации
        /// </summary>
        public Queue<string> Queue { get; set; }

        /// <summary>
        /// Размер очереди (ограничитель)
        /// </summary>
        public int Max { get; set; }

        #endregion

        #region Constructor/destructor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="size"></param>
        private Buffer(TextBox tb, int buffersize)
        {
            _tbOutput = tb;
            Max = buffersize;

            Queue = new Queue<string>(buffersize);
        }

        /// <summary>
        /// Статический метод инициализации объекта
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Buffer CreateObject(TextBox tb, int buffersize)
        {
            return new Buffer(tb, buffersize);
        }

        /// <summary>
        /// Деструктор
        /// </summary>
        public void Dispose()
        {
            _tbOutput.Clear();
            _tbOutput = null;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод добавления объекта 
        /// </summary>
        /// <param name="threadnum"></param>
        /// <param name="value"></param>
        public bool Enqueue(int index, string value)
        {
            System.Threading.Monitor.Enter(this);
            var result = false;
            try
            {
                if (Queue.Count != Max)
                {
                    Queue.Enqueue(value);
                    _tbOutput.Invoke(new Action(() => _tbOutput.Text += "Писатель " + index.ToString() + " добавил " + value + Environment.NewLine));
                    result = true;
                }
                else _tbOutput.Invoke(new Action(() => _tbOutput.Text += "Для писателя " + index.ToString() + "нет места в буффере " + Environment.NewLine));
            }
            finally
            {
                System.Threading.Monitor.Exit(this);
            }
           
            return result;
        }

        /// <summary>
        /// Метод извлечения 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string Dequeue(int index)
        {
            System.Threading.Monitor.Enter(this);
            var result = string.Empty;
            try
            {
                if (Queue.Count > 0)
                {
                    result = Queue.Dequeue();
                    _tbOutput.Invoke(new Action(() =>_tbOutput.Text += "Читатель " + index.ToString() + " забрал " + result + Environment.NewLine));
                }
                else if (Queue.Count == 0)
                    _tbOutput.Invoke(new Action(() => _tbOutput.Text += "Для читателя " + index.ToString() + " буффер пуст " + Environment.NewLine));
            }
            finally
            {
                System.Threading.Monitor.Exit(this);
            }
            return result;
        }

        #endregion
    }
}
