using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace n1
{
    class ThreadGenerator
    {
        Buffer buff;
        int writers_num = 0;
        List<Thread> writers;
        Reader reader;
        Thread reader_thread;
        TextBox reader_tb,
                writer_tb;

        public ThreadGenerator(Buffer buff, TextBox r_tb, TextBox w_tb)
        {
            this.buff = buff;
            reader_tb = r_tb;
            writer_tb = w_tb;
            writers = new List<Thread>();
        }

        public void Run()
        {
            reader = new Reader(reader_tb, buff);
            reader_thread = new Thread(reader.Read);
            reader_thread.Start();
            while (true)
            {
                writers_num += 1;
                Writer writer = new Writer(writer_tb, buff, writers_num);
                Thread writer_thread = new Thread(writer.Write);
                writers.Add(writer_thread);
                writer_thread.Start();
                Thread.Sleep(new Random().Next(2000, 5000));
            }
        }

        public void Stop()
        {
            reader_thread.Abort();
            for (int i = 0; i < writers.Count; i++)
                writers[i].Abort();
            buff.Clear();
        }

        public void Pause()
        {
            if (reader_thread.ThreadState == ThreadState.Running || reader_thread.ThreadState == ThreadState.WaitSleepJoin)
                reader_thread.Suspend();
            for (int i = 0; i < writers.Count; i++)
            {
                if (writers[i].ThreadState == ThreadState.Running || writers[i].ThreadState == ThreadState.WaitSleepJoin)
                    writers[i].Suspend();
            }
        }

        public void Resume()
        {
            if (reader_thread.ThreadState == ThreadState.Suspended)
                reader_thread.Resume();
            for (int i = 0; i < writers.Count; i++)
            {
                if (writers[i].ThreadState == ThreadState.Suspended)
                    writers[i].Resume();
            }
        }

    }
}
