using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    class Writer
    {
        private Object lockObj = new Object();
        private QueueBuffer _buffer;
        private Thread _thread;
        private TextBox _output;              
        private int _messagesQuantity;    
        private int _writerNumber;      

        /// <summary>
        /// Конструктор класса "Писатель"
        /// </summary>
        /// <param name="output">TextBox для вывода информации</param>
        /// <param name="messagesQuantity">Количество сообщений для записи</param>
        /// <param name="writerNumber">Номер читателя</param>
        /// <param name="buffer">Очередь для записи элементов</param>
        public Writer(TextBox output, int messagesQuantity, int writerNumber, QueueBuffer buffer)
        {
            _output = output;
            _buffer = buffer;
            _messagesQuantity = messagesQuantity;
            _writerNumber = writerNumber;
            _thread = new Thread(this.Write);
            _thread.Start();
        }

        /// <summary>
        /// Запись элементов в очередь
        /// </summary>
        public void Write()
        {
            Random rnd = new Random();

            while (_messagesQuantity > 0)
            {
                int tmp = rnd.Next(_writerNumber * 2 + 7);
                _buffer.Enqueue(tmp.ToString());
                _output.Invoke(new Action(() => _output.Text += "Writer " + _writerNumber.ToString() + " add number " + tmp.ToString() + Environment.NewLine));
                _messagesQuantity--;
                Thread.Sleep(rnd.Next(500, 2000));
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
            if(_thread.ThreadState == ThreadState.Running)
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
