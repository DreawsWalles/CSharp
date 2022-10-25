using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    class QueueBuffer
    {
        private Queue<string> _buffer;
        private TextBox _output;
        private int _maxQuantity;
        public int Count { get { return _buffer.Count; } }

        /// <summary>
        /// Конструктор класса "Буффер", реализованного с помощью очереди
        /// </summary>
        /// <param name="output">TextBox для вывода информации</param>
        /// <param name="maxQuantity">Максимально допустимое количество элементов в очереди</param>
        public QueueBuffer(TextBox output, int maxQuantity)
        {
            _maxQuantity = maxQuantity;
            _output = output;
            _buffer = new Queue<string>();
        }

        /// <summary>
        /// Добавление элемента в очередь
        /// </summary>
        /// <param name="writerNumber">Номер писателя</param>
        /// <param name="element">Добавляемый элемент</param>
        public void Enqueue(string element)
        {
            Monitor.Enter(this);
            try
            { 
                if (_buffer.Count < _maxQuantity)
                    _buffer.Enqueue(element);
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        /// <summary>
        /// Извлечение элемента из очереди
        /// </summary>
        /// <param name="readerNumber">Номер читателя</param>
        /// <returns>Извлеченный элемент</returns>
        public string Dequeue()
        {
            Monitor.Enter(this);
            try
            {
                string tmp = "";
                if (_buffer.Count > 0)
                    tmp = _buffer.Dequeue();
                return tmp;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
    }
}
