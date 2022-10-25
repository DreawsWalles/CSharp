using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Task1
{
    class Processor
    {
        private QueueBuffer _buffer;
        private Thread _thread;
        private TextBox _mainOutput;
        private TextBox _writerOutput;
        private TextBox _readerOutput;
        private List<object> _list;
        private bool _readerPaused = false;
        private bool _writerPaused = false;
        public bool WritersActive { get { return !_writerPaused; } }
        public bool ReadersActive { get { return !_readerPaused; } }

        /// <summary>
        /// Конструктор класса "Обработчик"
        /// </summary>
        /// <param name="buffer">Очередь для обработки</param>
        /// <param name="writerOutput">TextBox для вывода информации о писателях</param>
        /// <param name="readerOutput">TextBox для вывода информации о читателях</param>
        public Processor(QueueBuffer buffer, TextBox mainOutput, TextBox writerOutput, TextBox readerOutput)
        {
            _buffer = buffer;
            _mainOutput = mainOutput;
            _writerOutput = writerOutput;
            _readerOutput = readerOutput;
            _thread = new Thread(this.Run);
            _thread.Start();
            _list = new List<object>();
        }

        /// <summary>
        /// Запуск процесса обработки
        /// </summary>
        private void Run()
        {
            int i = 0;
            int switcher;
            Random rnd = new Random();
            while (true)
            {
                switcher = rnd.Next(2);
                switch (switcher)
                {
                    case 0:
                        if (!(_writerPaused))
                        {
                            _list.Add(new Writer(_writerOutput, 3, i, _buffer));
                            _mainOutput.Invoke(new Action(() => _mainOutput.Text += "Writer " + i.ToString() + " created" + Environment.NewLine));
                        }
                        break;
                    case 1:
                        if (!(_readerPaused))
                        {
                            _list.Add(new Reader(_readerOutput, 3, i, _buffer));
                            _mainOutput.Invoke(new Action(() => _mainOutput.Text += "Reader " + i.ToString() + " created" + Environment.NewLine));
                        }
                        break;
                }
                Thread.Sleep(new Random().Next(500, 1500));
                i++;
            }
        }

        /// <summary>
        /// Завершение процесса обработки
        /// </summary>
        public void Exit()
        {
            _thread.Abort();
            foreach (var thread in _list)
            {
                if (thread is Writer)
                    ((Writer)thread).Abort();
                else
                    ((Reader)thread).Abort();
            }
            _list.Clear();
        }

        /// <summary>
        /// Приостановить добавление читателей
        /// </summary>
        public void WaitReaders()
        {
            foreach (var thread in _list)
                if ((thread is Reader))
                    ((Reader)thread).Wait();
            _readerPaused = true;
        }

        /// <summary>
        /// Возобновить добавление читателей
        /// </summary>
        public void PulseReaders()
        {
            foreach (var thread in _list)
                if (thread is Reader)
                    ((Reader)thread).Pulse();
            _readerPaused = false;
        }

        /// <summary>
        /// Приостановить добавление писателей
        /// </summary>
        public void WaitWriters()
        {
            foreach (var thread in _list)
                if (thread is Writer)
                    ((Writer)thread).Wait();
            _writerPaused = true;
        }

        /// <summary>
        /// Возобновить добавление писателей
        /// </summary>
        public void PulseWriters()
        {
            foreach (var thread in _list)
                if (thread is Writer)
                    ((Writer)thread).Pulse();
            _writerPaused = false;
        }
    }
}
