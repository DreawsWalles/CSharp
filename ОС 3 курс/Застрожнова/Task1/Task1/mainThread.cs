using System.Collections.Generic;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Task1
{
    class mainThread
    {
        //буфер
        private BufStack Buf;
        //размер буфера
        private int max_size;
        //список всех читателей/писателей
        private List<object> list;
        //основной поток
        private Thread myThread;
        //текстбоксы писателей и читателей для вывода сообщений
        private TextBox WriterTBox;
        private TextBox ReaderTBox;
        //флаги, информирующие об остановке создания писателя/читателя
        private bool isR_Suspend=false;
        private bool isW_Suspend = false;

        //конструктор
        public mainThread(int num, BufStack buf,TextBox textB_r,TextBox textB_w)
        {
            ReaderTBox = textB_r;
            WriterTBox = textB_w;
            list = new List<object>();

            Buf = buf;
            max_size = num;

            myThread = new Thread(this.Run);
            myThread.Start();
        }

        //запуск
        private void Run()
        {
            int i = 0;
            Random myRandom = new Random();
            while (i < max_size)
            {
                var for_switch = myRandom.Next(2);
                switch (for_switch)
                {
                    case 0:
                        if (!(isW_Suspend))
                            list.Add(new Writer(WriterTBox, 5, i, Buf));
                        break;
                    case 1:
                        if (!(isR_Suspend))
                            list.Add(new Reader(ReaderTBox, 5, i, Buf));
                        break;
                }
                Thread.Sleep(new Random().Next(200,500));
                i++;
            }
        }

        //завершение
        public void Abort()
        {
            if (myThread != null) {
                if (myThread.ThreadState == ThreadState.Suspended)
                    myThread.Resume();
                myThread.Abort();
                foreach (var tr in list)
                {
                    if (tr is Writer)
                        ((Writer)tr).Abort();
                    else
                        ((Reader)tr).Abort();
                }
                list.Clear();
                list = null;
            }
        }

        //пауза - продолжение для читателя
        public void StopReaders()
        {
            if (!isR_Suspend)
            {
                foreach (var tr in list)
                    if ((tr is Reader))
                        ((Reader)tr).Stop();
                isR_Suspend = true;
            } 
        }
        public void ResumeReaders()
        {
            if (isR_Suspend)
            {
                foreach (var tr in list)
                    if (tr is Reader)
                        ((Reader)tr).Resume();
                isR_Suspend = false;
            }
        }
        //пауза - продолжение для писателя
        public void StopWriters()
        {
            if (!isW_Suspend)
            {
                foreach (var tr in list)
                    if ((tr is Writer))
                        ((Writer)tr).Stop();
                isW_Suspend = true;
            }
        }
        public void ResumeWriters()
        {
            if (isW_Suspend)
            {
                foreach (var tr in list)
                    if (tr is Writer)
                        ((Writer)tr).Resume();
                isW_Suspend = false;
            }
        }

        //пауза - продолжение для основного потока
        public void Stop()
        {
            if (myThread.ThreadState != ThreadState.Suspended && myThread.ThreadState != ThreadState.Stopped)
            {
                StopReaders();
                StopWriters();
                myThread.Suspend();
            }
        }

        public void Resume()
        {
            if(myThread.ThreadState == ThreadState.Suspended)
            {
                ResumeReaders();
                ResumeWriters();
                myThread.Resume();
            }
        }
    }
}
