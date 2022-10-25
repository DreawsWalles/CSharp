using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
//нет блокировки процессов; нет разделения процессорного времени
namespace n4
{
    class SampleThread
    {
        const long min_number = 10000000,
           max_number = 100000000;
        const int min_timeout = 10;
        const int max_timeout = 200;
        private Thread th;
        private long number, count;
        private bool stopped;
        private static Random rnd = new Random();
        private int timeout;
        Action callback;
        public long CurrentCountState
        {
            get { return count; }
        }
        public long MaxCountNumber
        {
            get { return number; }
        }
        public string ThreadName
        {
            get { return th.Name; }
        }
        public ThreadState ThState
        {
            get { return th.ThreadState; }
        }
        public int Timeout
        {
            get { return timeout; }
            set { timeout = value; }
        }
        public SampleThread(string name, Action callback)
        {
            this.callback = callback;
            th = new Thread(new ThreadStart(this.Run));
            th.Name = name;
            count = 0;
            number = rnd.Next(1, 4) * rnd.Next((int)min_number, (int)max_number);
        }
        private void Run()
        {
            stopped = false;
            while (count < number && !stopped)
                count += 1;
            this.Timeout += rnd.Next(min_timeout, max_timeout);
            callback();
        }
        public void Suspend()
        {
            Monitor.Enter(th);
            try
            {
                if (th.ThreadState == ThreadState.Running || th.ThreadState == ThreadState.WaitSleepJoin)
                    th.Suspend();
            }
            finally
            {
                Monitor.Exit(th);
            }
        }
        public void Resume()
        {
            Monitor.Enter(th);
            try
            {
                if (th.ThreadState == ThreadState.Suspended)
                    th.Resume(); 
                else if (th.ThreadState == ThreadState.Unstarted)
                    th.Start();
            }
            finally
            {
                Monitor.Exit(th);
            }
        }
        public void Start()
        {
            if (th != null && th.ThreadState == ThreadState.Unstarted)
            {
                th.Start();
                stopped = false;
            }
        }
        public void Stop()
        {
            stopped = true;
        }
    }
}
