using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab1N132
{
    class Controller
    {
        public event Action<string> SendMessage;
        public event Action<bool> BufferChanged;

        Buffer<string> buffer;
        ManualResetEvent readers, writers;
        bool readersStopped;
        bool writersStopped;

        public bool Stop { get; set; }
        public bool ReadersStopped
        {
            get { return readersStopped; }
            set
            {
                readersStopped = value;
                if (value)
                    readers.Reset();
                else
                    readers.Set();
            }
        }
        public bool WritersStopped
        {
            get { return writersStopped; }
            set
            {
                if (value)
                    writers.Reset();
                else
                    writers.Set();
                writersStopped = value;
            }
        }

        public Controller(int capacity)
        {
            buffer = new Buffer<string>(capacity);
            buffer.Changed += BufferHandler;
            readers = new ManualResetEvent(false);
            writers = new ManualResetEvent(false);
            ReadersStopped = false;
            WritersStopped = false;
            Stop = false;
        }

        void MessageHandler(string msg)
        {
            SendMessage(msg);
        }

        void BufferHandler(bool increase)
        {
            BufferChanged(increase);
        }

        public void Run()
        {
            Reader reader = new Reader(buffer, readers, 1000);
            reader.SendMessage += MessageHandler;
            Thread t = new Thread(reader.Run);
            t.IsBackground = true;
            t.Start();

            Writer writer = new Writer(buffer, writers, 1500);
            writer.SendMessage += MessageHandler;
            t = new Thread(writer.Run);
            t.IsBackground = true;
            t.Start();
            while (!Stop)
            {
                Thread.Sleep(1000);
                Random r = new Random(DateTime.Now.Millisecond);
                if (r.Next(0, 30) % 7 == 0)
                {
                    writer = new Writer(buffer, writers, 1500);
                    writer.SendMessage += MessageHandler;
                    t = new Thread(writer.Run);
                    t.IsBackground = true;
                    t.Start();
                }
            }
            ReadersStopped = true;
            WritersStopped = true;
        }
    }
}
