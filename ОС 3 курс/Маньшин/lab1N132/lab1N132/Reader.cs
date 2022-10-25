using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab1N132
{
    class Reader
    {
        public event Action<string> SendMessage;

        static string msgSuccess = "Читатель забрал сообщение из стека.";
        static string msgFail = "Не вышло забрать из стека, стек пуст.";

        ManualResetEvent pause;
        int waitingTime;
        Buffer<string> buf;

        public Reader(Buffer<string> b, ManualResetEvent re, int wt)
        {
            buf = b;
            pause = re;
            waitingTime = wt;
        }

        public void Run()
        {
            for(;;)
            {
                pause.WaitOne();
                Random r = new Random(DateTime.Now.Millisecond);
                int n = r.Next(0, 10);
                if (n % 2 != 0) { Take(); }
                Thread.Sleep(waitingTime);
            }
        }

        void Take()
        {
            string tmp;
            if (buf.Take(out tmp))
                SendMessage(msgSuccess);
            else
                SendMessage(msgFail);
            return;
        }
    }
}
