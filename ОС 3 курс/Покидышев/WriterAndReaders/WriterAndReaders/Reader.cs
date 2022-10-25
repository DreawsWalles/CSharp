using System;
using System.Threading;

namespace WriterAndReaders
{
    internal class Reader : Worker<int>
    {
        public int MessagesLeft { get; private set; }
        public int No { get; }

        public Action StartCallback;
        public Action StopCallback;

        public Action<int> DataReadCallback;

        public Reader(QueueBuffer<int> buf, int messagesNum, int no) : base(buf)
        {
            MessagesLeft = messagesNum;
            No = no;

            Thread = new Thread(Work);
            Thread.Start();
        }

        public override void Work()
        {
            StartCallback?.Invoke();
            
            while (MessagesLeft > 0)
            {
                int item = 0;
                if (Buffer.Dequeue(ref item))
                {
                    DataReadCallback?.Invoke(item);
                    MessagesLeft--;
                }
                Thread.Sleep(Rand.Next(600, 1200));
            }

            StopCallback?.Invoke();
        }
    }
}
