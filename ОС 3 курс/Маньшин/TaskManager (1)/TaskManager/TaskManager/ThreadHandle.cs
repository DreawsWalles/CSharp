using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace TaskManager
{
    class ThreadHandle //Планируемый поток
    {
        public event Action UnexpectedEndOrBlocking;

        static long max_id = 0;
        public static int QuantumLength { get; set; } = 300; //"длина" кванта процессорного времени

        int remainingWork; 
        Thread thread;
        ManualResetEvent resetEvent;
        public readonly long ID;

        #region Свойства
        public ThreadState ThreadState
        {
            get { return thread.ThreadState; }
        }

        public string ThreadName
        {
            get { return thread.Name; }
        }

        public bool Blocked { get; private set; }
        public int BlockTime { get; private set; }

        public Thread Thread
        {
            get
            {
                return thread;
            }
        }

        /// <summary>
        /// Оставшееся время выполнения
        /// </summary>
        public int RemainingWork
        {
            get { return remainingWork; }
        }
        #endregion

        /// <summary>
        /// Инициализирует новый объект ThreadHandle
        /// </summary>
        /// <param name="workingTime">Ожидаемое время работы процесса</param>
        public ThreadHandle(int workingTime)
        {
            remainingWork = workingTime;
            max_id++;
            ID = max_id;

            resetEvent = new ManualResetEvent(false);

            thread = new Thread(new ThreadStart(Run));
            thread.IsBackground = true;
            thread.Name = ID.ToString();
            thread.Start(); //т.к. изначально задано несигнальное состояние AutoResetEvent, процесс всё равно будет ожидать разрешения на продолжение от планировщикаы
        }
        
        /// <summary>
        /// Запуск процесса
        /// </summary>
        private void Run()
        {
            int random;
            resetEvent.WaitOne();
            while (remainingWork > 0)
            {
                resetEvent.WaitOne();
                Random r = new Random(); 
                random = r.Next(1, 100); //случайным образом генерируется шанс того, что поток прервёт работу, не отработав всего положенного времени
                if (random % 30 == 0)
                {
                    resetEvent.Reset();
                    Block();
                    continue;
                }

                remainingWork--; //типа выполнение работы
                Thread.Sleep(1);
                resetEvent.WaitOne();
            }
            UnexpectedEndOrBlocking(); 
        }

        /// <summary>
        /// Приостановка процесса
        /// </summary>
        public void Pause()
        {
            resetEvent.Reset();
        }

        /// <summary>
        /// Возобновление работы потока
        /// </summary>
        public void Resume()
        {
            resetEvent.Set();
        }

        void Block()
        {
            Random r = new Random();
            BlockTime = r.Next(10, 100) * ThreadHandle.QuantumLength;
            Blocked = true;
            UnexpectedEndOrBlocking();
            Thread.Sleep(BlockTime);
            Blocked = false;
        }
    }
}
