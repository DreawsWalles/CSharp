using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zadacha_1
{
    public class Reader : IThread
    {
        public Thread MainThread { get; set; }
        public Reader()
        {
        }

        public void Run()
        {
            int a = 0;
            while (true)
            {
                BlockingQueue<int>.GetInstanse().TryDequeue(out a);

                Thread.Sleep(new Random(DateTime.Now.Millisecond).Next(500, 800));
            }
        }
    }
}
