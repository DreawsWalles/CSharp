using System;
using System.Threading;

#pragma warning disable 618

namespace WriterAndReaders
{
    internal class Writer : Worker<int>
    {
        public Action<int> DataWrittenCallback;

        private int _actionsLeft;
        
        public Writer(QueueBuffer<int> buf, int n) : base(buf)
        {
            _actionsLeft = n;
            Thread = new Thread(Work);
            Thread.Start();
        }

        public override void Work()
        {
            while (_actionsLeft > 0)
            {
                int someRandomNumber = Rand.Next(0, 100);
                Buffer.Enqueue(someRandomNumber);
                DataWrittenCallback?.Invoke(someRandomNumber);
                _actionsLeft--;
                Thread.Sleep(Rand.Next(600, 1200));
            }
        }
    }
}

