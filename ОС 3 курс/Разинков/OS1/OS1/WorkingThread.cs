using System.Threading;

namespace OS1
{
    class WorkingThread
    {
        Worker worker;
        Thread thread;

        public ThreadState State
        {
            get { return thread.ThreadState; }
        }

        public WorkingThread(Worker w)
        {
            worker = w;
            thread = new Thread(new ThreadStart(w.DoWork));
            thread.IsBackground = true;
            thread.Start();
        }

        public void Stop()
        {
            worker.Stop();
        }
    }
}
