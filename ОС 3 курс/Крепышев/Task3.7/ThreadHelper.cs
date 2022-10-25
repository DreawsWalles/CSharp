using System;
using System.Threading;

namespace Task3._7
{
    public static class ThreadHelper
    {

        public  static void ThreadStart(Thread thread, Action method)
        {
            if (thread != null)
                if (thread.ThreadState != ThreadState.Stopped)
                    thread.Abort();

            thread = new Thread(new ThreadStart(method));
            thread.Start();
            thread.Join();
        }


    }
}
