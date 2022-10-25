using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task1._2._3._3
{
    class Writer
    {
        private volatile bool shouldStop = false;
        IBuffer buffer;
        int dataId = 0;

        public Writer(IBuffer buffer)
        {
            this.buffer = buffer;
        }

        public void RequestStop()
        {
            shouldStop = true;
        }

        public void Add()
        {
            while (!shouldStop)
            {
                Thread.Sleep(2000);
                buffer.Add(new Data(Thread.CurrentThread.ManagedThreadId, dataId));
                dataId++;
            }
        }
    }
}
