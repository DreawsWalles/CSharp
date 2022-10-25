using System;
using System.Threading;

#pragma warning disable 618

namespace WriterAndReaders
{
    internal abstract class Worker<T>
    {
        protected Thread Thread;
        protected QueueBuffer<T> Buffer;
        protected Random Rand = new Random();

        protected Worker(QueueBuffer<T> buf)
        {
            Buffer = buf;
        }

        public void Abort()
        {
            Thread.Abort();
        }

        public void Stop()
        {
            if ((Thread.ThreadState == ThreadState.Running) || (Thread.ThreadState == ThreadState.WaitSleepJoin))
                Thread.Suspend();
        }

        public void Resume()
        {
            if (Thread.ThreadState == ThreadState.Suspended)
                Thread.Resume();
        }

        public abstract void Work();
    }
}