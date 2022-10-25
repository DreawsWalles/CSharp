using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
{
    class ThreadObserver
    {
        int result1, result2;
        int cntFinished = 0;

        public event Action<ThreadObserver> AllFinished;
        public int Result1 => result1;
        public int Result2 => result2;
        
        public ThreadObserver()
        {
            result1 = result2 = 0;
        }

        public void Finished1(int result)
        {
            Monitor.Enter(this);
            result1 = result;
            ++cntFinished;
            Monitor.Exit(this);
        }

        public void Finished2(int result)
        {
            Monitor.Enter(this);
            result2 = result;
            ++cntFinished;
            Monitor.Exit(this);
        }

        public void Observe()
        {
            while (cntFinished != 2) { }
            AllFinished(this);
        }
    }
}
