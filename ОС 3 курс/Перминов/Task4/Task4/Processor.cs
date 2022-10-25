using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    class Processor
    {
        private Thread _thread;
        private TextBox _output;
        private List<PageHandler> _list;
        private PageList _pages;
        private int _workTime;
        private bool _overwrite;

        /// <summary>
        /// Создание обработчика
        /// </summary>
        /// <param name="memory">Модель памяти</param>
        /// <param name="output">TextBox для логирования</param>
        public Processor(DataGridView memory, TextBox output)
        {
            _output = output;
            _list = new List<PageHandler>();
            _pages = new PageList(memory);
            _thread = new Thread(this.Run);
            _workTime = 1000;
            _overwrite = false;
        }

        /// <summary>
        /// Запуск процесса создания новых потоков и удаления отработавших
        /// </summary>
        private void Run()
        {
            while (true)
            {
                _list.Add(new PageHandler(_pages, _output));
                Thread.Sleep(new Random().Next(500 + _workTime, 1500 + _workTime));
                int i = 0;
                while (i < _list.Count)
                {
                    if (!_list[i].isAlive)
                        _list.RemoveAt(i);
                    else
                        i++;
                }
            }
        }

        /// <summary>
        /// Изменение способа добавления страниц вручную (с перезаписью/без перезаписи)
        /// </summary>
        public void ChangeAddStyle()
        {
            _overwrite = !_overwrite;
        }

        /// <summary>
        /// Добавление страниц вручную
        /// </summary>
        /// <param name="no">Номер процесса</param>
        /// <param name="qty">Количество страниц</param>
        public void AddPages(int no, int qty)
        {
            if (!_pages.Add(no, qty))
                _output.Invoke(
                    new Action(() => _output.Text += "Not enough free memory to create new pages" + Environment.NewLine));
            else
            {
                _output.Invoke(
                    new Action(() => _output.Text += "Thread creates pages with number " + no + Environment.NewLine));
                return;
            }
            if (_overwrite && qty <= _pages.MaxSize)
            {
                while(!_pages.Add(no, qty))
                    _output.Invoke(
                    new Action(() => _output.Text += "Thread deletes pages with number " + _pages.DeleteOldest() + " to free some memory" + Environment.NewLine));
            }
        }

        /// <summary>
        /// Удаление страниц с заданным номером
        /// </summary>
        /// <param name="no">Номер процесса</param>
        public void DeletePages(int no)
        {
            if (_pages.DeleteByNum(no))
                _output.Invoke(
                    new Action(() => _output.Text += "Thread deletes pages with number " + no + Environment.NewLine));
            else
                _output.Invoke(
                    new Action(
                        () =>
                            _output.Text +=
                                "Thread can not delete pages with number " + no + " for they do not exist anymore" +
                                Environment.NewLine));
        }

        /// <summary>
        /// Изменение скорости создания новых потоков
        /// </summary>
        /// <param name="workTime">Модификатор скорости создания новых потоков</param>
        public void ChangeWorkTime(int workTime)
        {
            _workTime = workTime;
        }

        /// <summary>
        /// Запуск процесса обработки
        /// </summary>
        public void Start()
        {
            _thread.Start();
        }

        /// <summary>
        /// Завершение процесса обработки и всех запущенных им процессов
        /// </summary>
        public void Halt()
        {
            try
            {
                _thread.Abort();
            }
            catch (Exception)
            {
            }

            foreach (var handler in _list)
            {
                handler.Halt();
            }
            _thread = new Thread(this.Run);
        }

        /// <summary>
        /// Остановка процесса обработки
        /// </summary>
        /// <param name="withSubthreads">Флаг - остановить или нет все процессы, запущенные основным</param>
        public void Pause(bool withSubthreads)
        {
            _thread.Suspend();

            if (withSubthreads)
                for (int i = 0; i < _list.Count; i++)
                {
                    _list[i].Pause();
                }
        }

        /// <summary>
        /// Продолжение процесса обработки
        /// </summary>
        /// <param name="withSubthreads">Флаг - продолжить или нет все процессы, запущенные основным</param>
        public void Continue(bool withSubthreads)
        {
            _thread.Resume();

            if (withSubthreads)
                for (int i = 0; i < _list.Count; i++)
                {
                    _list[i].Continue();
                }
        }
    }
}

