using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace program_1
{
    class ThreadCreator
    {
        private const int time = 50 * ProgramData.speed;

        private DataStack buff;         // Буфер(стек)
        private Writer writer;          // Писатель
        private Thread tWriter;         // Поток-писатель
        private List<Thread> tReaders;  // Список потоков-читателей
        private TextBox tb;

        private Print status;


        public ThreadCreator(DataStack buff, TextBox textbox)
        {
            this.buff = buff;
            this.tb = textbox;
            this.status = new Print(PrintInfo);

            this.tReaders = new List<Thread>();
        }

        // Оcновной метод работы, создающий писателя и читателей
        public void Run()
        {
            Random rand = new Random();
            int nReader = 1;

            // Писатель
            writer = new Writer(buff, tb, status);
            tWriter = new Thread(new ThreadStart(writer.AddData));
            tWriter.Start();

            // Читатели
            while (true)
            {
                Reader reader = new Reader(buff, ProgramData.NumToString(nReader++), status, rand.Next(1, 4));
                Thread tReader = new Thread(reader.DeletedData);
                tReaders.Add(tReader);
                tReader.Start();

                Thread.Sleep(rand.Next(time, 4 * time));
            }
        }
        
        // Завершение работы
        public void Stop()
        {
            // Писатель
            tWriter.Abort();
            // Читатели
            for (int i = 0; i < tReaders.Count; i++)
                tReaders[i].Abort();
            buff.Clear();
        }

        // Продолжение работы
        public void Resume()
        {
            // Писатель
            if (tWriter.ThreadState == ThreadState.Suspended)
                tWriter.Resume();
            // Читатели
            for (int i = 0; i < tReaders.Count; i++)
                if (tReaders[i].ThreadState == ThreadState.Suspended)
                    tReaders[i].Resume();
        }
        
        // Приостановка работы
        public void Pause()
        {
            // Писатель
            if ((tWriter.ThreadState == ThreadState.Running) || (tWriter.ThreadState == ThreadState.WaitSleepJoin))
                tWriter.Suspend();
            // Читатели
            for (int i = 0; i < tReaders.Count; i++)
                if (tReaders[i].ThreadState == ThreadState.Running || tReaders[i].ThreadState == ThreadState.WaitSleepJoin)
                    tReaders[i].Suspend();
        }

        private void PrintInfo(string str)
        {
            if (tb.InvokeRequired)
                tb.Invoke(new Action<string>((s) => tb.AppendText(s)), str);
            else
                tb.AppendText(str);
        }
    }
}
