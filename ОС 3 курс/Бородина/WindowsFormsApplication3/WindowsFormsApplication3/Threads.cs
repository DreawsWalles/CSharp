using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{

    internal enum MyThreadPriority  { Lowest,
            BelowNormal,
            Normal, // Значение по умолчанию.
            AboveNormal,
            Highest
        }

    class Threads
    {

        // Значение, до которого считаем
        public long VALUE = 10000000;
        static Random r = new Random();
       
        private TextBox tbTxt = null;

        // Поток для выполнения вычислений
        public Thread thread = null;
        
        // Счетчик
        private long count = 0;

        // Номер(имя) потока
        public int ID;

        // Приоритет потока(0..4)
        public int priority;

        //Блокировка потока внешним устройством - ввод/вывод
        public bool state = false;

        //Таймер
        public int timer { get; set; }

        //создание потока
        public Threads(int _ID, TextBox _tbLog, int _priority) {
            tbTxt = _tbLog;
            priority = _priority;
            thread = new Thread(new ThreadStart(mainThread));
            ID = _ID;
            thread.Name = _ID.ToString();
            VALUE *= r.Next(1, 6);

        }

        public void Resume()// перезапуск потока
        {
            try
            {
                if (thread.ThreadState == ThreadState.Unstarted)
                    thread.Start();
                else if (thread.ThreadState == ThreadState.Suspended)
                    thread.Resume();
            }
            catch
            { }
        }

        public void Suspend() //приостанавливаем
        {

            try
            {
                if (thread.ThreadState != ThreadState.Stopped && thread.ThreadState != ThreadState.Suspended)
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
            while (count < VALUE && !state)
            {
                ++count;
                state = r.Next(100000000) < 2;
                if (state)
                {
                    timer = r.Next(10, 15);
                    return;
                }
            }
        }

        public ThreadState threadState
        {
           get {return thread.ThreadState; }
        }
    }
}
