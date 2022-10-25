using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace n2_1_4p86 {
    class ThreadCreator {
        // Буфер
        Buffer buf;

        // Списки потоков-читателей и писателей
        List<Thread> readersThreads;

        // Списки потоков-писателей
        List<Thread> writersThreads;

        // Сообщения читателей
        TextBox FReaders;

        // Сообщения писателей
        TextBox FWriters;

        public ThreadCreator (Buffer pBuffer, TextBox pReaders, TextBox pWriters) {
            buf = pBuffer;
            FReaders = pReaders;
            FWriters = pWriters;
            readersThreads = new List<Thread>();
            writersThreads = new List<Thread>();
        } //public ThreadCreator

        // Оcновной метод работы
        public void Run () {
            Random rnd = new Random();
            int cntReaders = 1, cntWriters = 1; ;
            while (true) {
                if (rnd.Next(2) == 0) {
                    Writer writer = new Writer (FWriters, buf, cntWriters);
                    Thread writerThread = new Thread(writer.Write);
                    writersThreads.Add(writerThread);
                    writerThread.Start();
                    cntWriters++;
                }
                else {
                    Reader reader = new Reader(FReaders, buf, cntReaders);
                    Thread readerThread = new Thread(reader.Read);
                    readersThreads.Add(readerThread);
                    readerThread.Start();
                    cntReaders++;
                }
                Thread.Sleep(rnd.Next(1000, 5000));
            } //while (true)
        } //public void Run

        // Продолжение работы
        public void Resume () {
            for (int i = 0; i < readersThreads.Count; i++)
                if (readersThreads[i].ThreadState == ThreadState.Suspended)
                    readersThreads[i].Resume();

            for (int i = 0; i < writersThreads.Count; i++)
                if (writersThreads[i].ThreadState == ThreadState.Suspended)
                    writersThreads[i].Resume();
        } //public void Resume

        // Приостановка работы
        public void Pause () {
            for (int i = 0; i < readersThreads.Count; i++)
                if (readersThreads[i].ThreadState == ThreadState.Running || readersThreads[i].ThreadState == ThreadState.WaitSleepJoin)
                    readersThreads[i].Suspend();

            for (int i = 0; i < writersThreads.Count; i++)
                if (writersThreads[i].ThreadState == ThreadState.Running || writersThreads[i].ThreadState == ThreadState.WaitSleepJoin)
                    writersThreads[i].Suspend();
        } //public void Pause

        // Завершение работы
        public void Stop() {
            for (int i = 0; i < readersThreads.Count; i++)
                readersThreads[i].Abort();
            for (int i = 0; i < writersThreads.Count; i++)
                writersThreads[i].Abort();
            buf.Clear();
        } //public void Stop
    } //class ThreadCreator
} //namespace n2_1_4p86
