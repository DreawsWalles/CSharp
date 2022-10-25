using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab1N132
{
    class Writer
    {
        public event Action<string> SendMessage;

        static int count = 0;
        static int max = 0;
        static string msgSuccess = "Отправитель{0} положил сообщение в стек.";
        static string msgFail = "У отправителя{0} не вышло положить в стек - стек полон.";
        static string msgDeath = "Отправитель{0} уничтожен.";

        int Number,
            waitingTime;
        ManualResetEvent pause;
        Buffer<string> buf;

        public Writer(Buffer<string> b, ManualResetEvent re, int wt)
        {
            pause = re;
            waitingTime = wt;
            buf = b;
            Number = max;
            ++count;
            ++max;
        }

        public void Run()
        {
            for (;;)
            {
                pause.WaitOne();
                Random r = new Random(DateTime.Now.Millisecond);
                int n = r.Next(0, 10);
                if (n % 10 == 0) { if (count != 1) break; }
                else if (n % 2 != 0) { Put(); }
                Thread.Sleep(waitingTime);
            }
            SendMessage(string.Format(msgDeath, Number));
            --count;
        }

        public void Put()
        {
            string tmp = "сообщение";
            if (buf.Put(tmp))
                SendMessage(string.Format(msgSuccess, Number));
            else
                SendMessage(string.Format(msgFail, Number));
            return;
        }
    }
}
