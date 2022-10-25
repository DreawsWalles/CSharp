using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ParThread
{
    class ThreadController
    {
        //Буфер
        MessageBuffer buff;
        //Общее число читателей и писателей
        int num = 2;
        //Списки потоков читателей и писателей
        List<Thread> readersThreads;
        List<Thread> writersThreads;

        //Текстбоксы читателей и писателей
        TextBox tbReaders, tbWriters;

        public ThreadController(MessageBuffer buff, TextBox tbReaders, TextBox tbWriters)
        {
            this.buff = buff;
            this.tbReaders = tbReaders;
            this.tbWriters = tbWriters;
            readersThreads = new List<Thread>();
            writersThreads = new List<Thread>();
        }

        //Основной метод создания читателей и писателей, а так же запуска их работы
        public void Run()
        {
            Random rnd = new Random();
            for (int i = 0; i < num; i++)
            {
                Writer writer = new Writer(tbWriters, buff, i + 1);
                Thread writerThread = new Thread(writer.Write);
                writersThreads.Add(writerThread);
                writerThread.Start();

                Thread.Sleep(rnd.Next(300));

                Reader reader = new Reader(tbReaders, buff, i + 1);
                Thread readerThread = new Thread(reader.Read);
                readersThreads.Add(readerThread);
                readerThread.Start();

                Thread.Sleep(rnd.Next(100));
            }
        }
        
        //Остановка работы
        public void Stop()
        {
            for (int i = 0; i < readersThreads.Count; i++)
                readersThreads[i].Abort();
            for (int i = 0; i < writersThreads.Count; i++)
                writersThreads[i].Abort();
            buff.Clear();
        }


        //Продолжение работы
        public void Resume()
        {
            for (int i = 0; i < readersThreads.Count; i++)
            {
                if (readersThreads[i].ThreadState == ThreadState.Suspended)
                    readersThreads[i].Resume();
            }
            for (int i = 0; i < writersThreads.Count; i++)
            {
                if (writersThreads[i].ThreadState == ThreadState.Suspended)
                    writersThreads[i].Resume();
            }
        }
        
        //Пауза
        public void Pause()
        {
            for (int i = 0; i < readersThreads.Count; i++)
            {
                if (readersThreads[i].ThreadState == ThreadState.Running || readersThreads[i].ThreadState == ThreadState.WaitSleepJoin)
                    readersThreads[i].Suspend();
            }
            for (int i = 0; i < writersThreads.Count; i++)
            {
                if (writersThreads[i].ThreadState == ThreadState.Running || writersThreads[i].ThreadState == ThreadState.WaitSleepJoin)
                    writersThreads[i].Suspend();
            }
        }
    }
}
