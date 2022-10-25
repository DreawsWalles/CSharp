using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TimePlanner
{
    
    /// <summary>
    /// Обертка над потоком: содержит имя, начальное время выполнения и оставшееся.
    /// Реализует все необходимые операции с потоком
    /// </summary>
    public class ThreadWorker
    {
        //Поля класса
        private Thread thread;
        private int time; 
        private int remaining_time;

        private int blocked_for;

        private bool stopped;
        private static Random rnd = new Random();

        Action callback;

        //Свойства для публичного доступа к некоторым полям
        public int RemainingTime
        {
            get { return remaining_time; }
        }
        public long DefaultTime
        {
            get { return time; }
        }
        public string Name
        {
            get { return thread.Name; }
        }
        public ThreadState ThreadState
        {
            get { return thread.ThreadState; }
        }
        
        public int BlockedFor
        {
            get { return blocked_for; }
            set { blocked_for = value; }
        }
        //Конструктор
        public ThreadWorker(string name, Action _callback)
        {
            thread = new Thread(new ThreadStart(this.Run));
            thread.Name = name;
            remaining_time = time = rnd.Next(150, 500);
            callback = _callback;

        }

        
        /// <summary>
        /// Работа потока. 
        /// В цикле каждую миллисекунду уменьшаем счетчик remaining_time, пока он не равен нулю, 
        /// либо пока поток не остановлен
        /// </summary>
        private void Run()
        {
            stopped = false;
            remaining_time = time;

            while (remaining_time > 0 && !stopped)
            {
                Thread.Sleep(1);
                remaining_time -= 1;
                if (rnd.Next(0, 100000) < 5)
                {
                    blocked_for = rnd.Next(1, 10);
                    callback();
                }
            }
            callback();
        }
        //Приостановка потока
        public void Suspend()
        {
            Monitor.Enter(thread);
            try
            {
                if (thread.ThreadState == ThreadState.Running || thread.ThreadState == ThreadState.WaitSleepJoin)
                    thread.Suspend();
            }
            finally
            {
                Monitor.Exit(thread);
            }
        }

        
        /// <summary>
        /// Возобновление работы потока
        /// Если он не начал свою работу, запускаем, если остановлен - возобновляем.
        /// </summary>
        public void Resume()
        {
            Monitor.Enter(thread);
            try
            {
                if (thread.ThreadState == ThreadState.Unstarted)
                    thread.Start();
                else if (thread.ThreadState == ThreadState.Suspended)
                    thread.Resume();
            }
            finally
            {
                Monitor.Exit(thread);
            }
        }
        //Остановка работы потока
        public void Stop()
        {
            stopped = true;
        }

    }
}
