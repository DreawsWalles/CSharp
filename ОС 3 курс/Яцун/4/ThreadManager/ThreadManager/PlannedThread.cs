using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ThreadManager
{
    class PlannedThread //Планируемый поток
    {
        public delegate void forEvent(PlannedThread thread);
        public event forEvent eventBlock;
        //public event forEvent eventEnd;


        static long id = 0;
        static Random rnd = new Random();

        public long VALUE = 1000; //200 0000       
        long count;
        Thread thread;
        bool pause;
        int blockTime;

        public PlannedThread(int time)
        {
            VALUE *= rnd.Next(1, 3);
            count = 0;

            thread = new Thread(new ThreadStart(Run));
            thread.Name = id.ToString();
            id++;
            
            pause = true;
            //thread.Start();
        }
        
        public void ThreadResume()
        {
            //pause = false;
            if (thread.ThreadState == ThreadState.Unstarted)
                thread.Start();
            else if (thread.ThreadState == ThreadState.Suspended)
                thread.Resume();
        }

        public void ThreadSuspend()
        {
            //pause = true;
            thread.Suspend();
        }

        private void Run()
        {
            while (count < VALUE)
            {
                count++;

                if (rnd.Next(-5, 500) < 0)
                {                    
                    eventBlock(this);
                    ThreadBlock();                    
                }
            }
        }

        void ThreadBlock()
        {
            blockTime = 100 * rnd.Next(15, 30);
            Thread.Sleep(blockTime);
            thread.Suspend();
        }

        public ThreadState ThreadState
        {
            get { return thread.ThreadState; }
        }

        public bool PauseState
        {
            get { return pause; }
        }

        public string ThreadName
        {
            get { return thread.Name; }
        }

        public long Count
        {
            get { return count; }
        }

        public Thread Thread
        {
            get
            {
                return thread;
            }
        }

        public int BlockTime
        {
            get
            {
                return blockTime;
            }

            set
            {
                blockTime = value;
            }
        }
    }
}
