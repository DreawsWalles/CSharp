using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    class Reader
    {
        private Object lockObj = new Object();
        private QueueBuffer _buffer;
        private Thread _thread;
        private TextBox _output;          
        private int _messagesQuantity;          
        private int _readerNumber;              

        /// <summary>
        /// Конструктор класса "Читатель"
        /// </summary>
        /// <param name="output">TextBox для вывода информации</param>
        /// <param name="messagesQuantity">Количество сообщений для чтения</param>
        /// <param name="readerNumber">Номер читателя</param>
        /// <param name="buffer">Очередь для чтения</param>
        public Reader(TextBox output, int messagesQuantity, int readerNumber, QueueBuffer buffer)
        {
            _output = output;
            _buffer = buffer;
            _messagesQuantity = messagesQuantity;
            _readerNumber = readerNumber;
            _thread = new Thread(this.Read);
            _thread.Start();
        }

        /// <summary>
        /// Чтение элементов из очереди
        /// </summary>
        public void Read()
        {
            Random rand = new Random();

            while (_messagesQuantity > 0)
            {
                if (_buffer.Count > 0)
                {
                    string tmp = _buffer.Dequeue();
                    _output.Invoke(new Action(() => _output.Text += "Reader " + _readerNumber.ToString() + " read number " + tmp.ToString() + Environment.NewLine));
                    _messagesQuantity--;
                }
                Thread.Sleep(rand.Next(500, 2000));
            }
        }

        /// <summary>
        /// Завершить поток
        /// </summary>
        public void Abort()
        {
            _thread.Abort();
        }

        /// <summary>
        /// Приостановить поток
        /// </summary>
        public void Wait()
        {
            if (_thread.ThreadState == ThreadState.Running)
                _thread.Suspend();
        }

        /// <summary>
        /// Продолжить выполнение потока
        /// </summary>
        public void Pulse()
        {
            if (_thread.ThreadState == ThreadState.Suspended)
                _thread.Resume();
        }
    }
}
