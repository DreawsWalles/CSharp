using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Task_4
{
    class LThread
    {
        // Значение, до которого считаем
        public long VALUE = 10000000; // 100 000 000
        static Random r = new Random();
        // Лог
        private TextBox tbLog = null;
        // Поток
        public Thread thread = null;
        // Билеты потока
        public int tickets { get; set; }
        // Счетчик
        private long count = 0;
        // Номер потока
        public int ID;
        //Блокировка потока внешним устройством
        public bool state = false;
        //Таймер
        public int timer = 0;

        Action callback;

        public LThread(int _ID, TextBox _tbLog, int _tickets, Action callback)//создание потока
        {
            tbLog = _tbLog;
            //workTime = _workTime;
            tickets = _tickets;
            thread = new Thread(new ThreadStart(this.mainThread));
            ID = _ID;
            this.callback = callback;
            thread.Name = _ID.ToString();
            VALUE *= r.Next(1, 6);

        }

        public void Resume()// перезапуск потока
        {
                if (thread.ThreadState == ThreadState.Suspended)
                    thread.Resume();
                else if (thread.ThreadState == ThreadState.Unstarted)
                    thread.Start();
        }

        public void Suspend() //приостанавливаем
        {
            try
            {
                if (thread.ThreadState == ThreadState.Running || thread.ThreadState == ThreadState.WaitSleepJoin)
                    thread.Suspend();
            }
            catch
            { }

        }

        public long Count
        {
            get { return count; }
        }

        public void mainThread()
        {
            while (count < VALUE)
            {
                ++count;
                state = r.Next(100000000) < 2;
                if (state)
                {
                    this.timer = r.Next(4, 10);
                    callback();
                }

            }

            callback();


        }

        public ThreadState threadState
        {
            get { return thread.ThreadState; }
        }

        public long GetCount
        {
            get { return count; }
        }
    }
}
