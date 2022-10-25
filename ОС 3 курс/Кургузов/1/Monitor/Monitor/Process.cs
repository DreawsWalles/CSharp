using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public class Process : IDisposable
    {
        #region Fields

        /// <summary>
        /// Текстбокс для вывода сообщений объектов-писателей
        /// </summary>
        public static TextBox _tbWriter = null;

        /// <summary>
        /// Текстбокс для вывода сообщений объектов-читателей
        /// </summary>
        public static TextBox _tbReader = null;

        /// <summary>
        /// Буффер 
        /// </summary>
        private Buffer _buffer = null;

        /// <summary>
        /// Список объектов (читатели, писатели)
        /// </summary>
        private List<object> _list = null;

        /// <summary>
        /// Поток для запуска работы объектов
        /// </summary>
        private Thread _mainThread = null;

        #endregion

        #region Properties

        /// <summary>
        /// Флаг, оповещающий об остановке создания очередного объекта-читателя
        /// </summary>
        public bool ReaderSuspend { get; set; }

        /// <summary>
        /// Флаг, оповещающий об остановке создания очередного объекта-писателя
        /// </summary>
        private bool WriterSuspend { get; set; }

        /// <summary>
        /// Количество потоков
        /// </summary>
        public int ThreadsCount { get; set; }

        /// <summary>
        /// Количество обращений к буфферу
        /// </summary>
        public int ActionsCount { get; set; }

        /// <summary>
        /// Размер буффера
        /// </summary>
        public int BufferSize { get; set; }

        /// <summary>
        /// Текущая заполненность в буффере
        /// </summary>
        public int InBufferNow
        {
            get { return _buffer.Queue.Count; }
        }

        #endregion

        #region Constructor/destructor

        /// <summary>
        /// Конструкторв
        /// </summary>
        private Process(Settings settings)
        {
            _tbWriter = settings.TxtWriter;
            _tbReader = settings.TxtReader;

            ThreadsCount = settings.ThreadsNumder;
            ActionsCount = settings.ActionsNumber;

            _list = new List<object>();

            BufferSize = settings.BufferSize; 
            _buffer = Buffer.CreateObject(settings.TxtBuffer, BufferSize);
        }

        /// <summary>
        /// Метод создания объекта
        /// </summary>
        /// <param name="num"></param>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Process CreateObject(Settings settings)
        {
            return new Process(settings);
        }

        /// <summary>
        /// Деструктор
        /// </summary>
        public void Dispose()
        {
            Abort();
            if (_tbReader != null)
            {
                _tbReader.Clear();
                _tbReader = null;
            }

            if (_tbWriter != null)
            {
                _tbWriter.Clear();
                _tbWriter = null;
            }

            if (_buffer != null)
            {
                _buffer = null;
            }

            if (_list != null && _list.Count != 0)
            {
                _list.Clear();
            }

            if (_mainThread != null)
            {
                _mainThread.Abort();
                _mainThread = null;
            }

          ThreadsCount = 0;

        }

        #endregion

        #region Methods

        /// <summary>
        /// Основной метод класса
        /// </summary>
        private void Start()
        {
            var index = 0;
            var choice = 0;
            var rnd = new Random();
            while (index < ThreadsCount)
            {
                choice = rnd.Next(2);
                switch (choice)
                {
                    case 0:
                        {
                            if (!WriterSuspend && _buffer.Queue.Count < _buffer.Max)
                                _list.Add(Writer.CreateObject(_tbWriter, ActionsCount, index, _buffer));
                            break;
                        }
                    case 1:
                        {
                            if (!ReaderSuspend &&_buffer.Queue.Count != 0)
                                _list.Add(Reader.CreateObject(_tbReader, ActionsCount, index, _buffer));
                            break;
                        }
                }
                Thread.Sleep(new Random().Next(200, 500));
                index++;
            }
        }

        /// <summary>
        /// Запуск потока
        /// </summary>
        public void Run()
        {
            _mainThread = new Thread(Start);
            _mainThread.Start();
        }

        /// <summary>
        /// Метод немедленного завершения всех потоков
        /// </summary>
        public void Abort()
        {
            if (_mainThread != null)
            {
                for (var i = 0; i < _list.Count; i++)
                {
                    if (_list[i] is Writer)
                        ((Writer)_list[i]).Abort();
                    if (_list[i] is Reader)
                        ((Reader)_list[i]).Abort();
                }
                _mainThread.Abort();
                _list.Clear();
                _list = null;

                ReaderSuspend = false;
                WriterSuspend = false;
            }
        }

        /// <summary>
        /// Метод остановки потоков-читателей
        /// </summary>
        public void StopReaders()
        {
            if (!ReaderSuspend)
            {
                for (var i = 0; i < _list.Count; i++)
                {
                    if (_list[i] is Reader)
                        ((Reader)_list[i]).Stop();
                }

                ReaderSuspend = true;
            }
        }

        /// <summary>
        /// Метод возобновления работы потоков-читателей
        /// </summary>
        public void ResumeReaders()
        {
            if (ReaderSuspend)
            {
                for (var i = 0; i < _list.Count; i++)
                {
                    if (_list[i] is Reader)
                        ((Reader)_list[i]).Resume();
                }

                ReaderSuspend = false;
            }
        }

        /// <summary>
        /// Метод остановки потоков-писателей
        /// </summary>
        public void StopWriters()
        {
            if (!WriterSuspend)
            {
                for (var i = 0; i < _list.Count; i++)
                {
                    if (_list[i] is Writer)
                        ((Writer)_list[i]).Stop();
                }

                WriterSuspend = true;
            }           
        }

        /// <summary>
        /// Метод возобновления работы потоков-писателей
        /// </summary>
        public void ResumeWriters()
        {
            if (WriterSuspend)
            {
                for (var i = 0; i < _list.Count; i++)
                {
                    if (_list[i] is Writer)
                        ((Writer)_list[i]).Resume();
                }

                WriterSuspend = false;
            }
        }
        #endregion
    }
}
