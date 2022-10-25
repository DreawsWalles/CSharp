using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task1._2._3._3
{
    class Reader
    {
        //private volatile bool shouldStop;
        IBuffer buffer;

        public Reader(IBuffer buffer)
        {
            this.buffer = buffer;
        }

        public void Delete()
        {
            Thread.Sleep(new Random().Next(2000));
            int rnd = new Random().Next(1,4);
            for (int i = 0; i < rnd; i++)
                buffer.Delete();
        }
    }
}
