using System.Collections.Generic;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Task1
{
    class mainThread
    {
        //Буфер-стек
        private BufStack buffer;
        //Размер стека
        private int max_size;
        //Список читателей/писателей
        private List<object> list;
        //Главный поток
        private Thread myThread;
        //Текстбоксы писателей и читателей для вывода сообщений
        private TextBox WriterTBox;
        private TextBox ReaderTBox;
        //Флаги, информирующие об остановке создания писателя/читателя
        private bool isR_Suspend = false;
        private bool isW_Suspend = false;

        //Конструктор
        public mainThread(int num, BufStack buf,TextBox textB_r,TextBox textB_w)
        {
            ReaderTBox = textB_r;
            WriterTBox = textB_w;
            list = new List<object>();

            buffer = buf;
            max_size = num;

            myThread = new Thread(this.Go);
            myThread.Start();
        }

        //Пуск
        private void Go()
        {
            int i = 0;
            Random r = new Random();
            while (i < max_size)
            {
                var for_switch = r.Next(2);
                switch (for_switch)
                {
                    case 0:
                        if (!(isW_Suspend))
                            list.Add(new Writer(WriterTBox, 5, i, buffer));
                        break;
                    case 1:
                        if (!(isR_Suspend))
                            list.Add(new Reader(ReaderTBox, 5, i, buffer));
                        break;
                }
                Thread.Sleep(new Random().Next(200,500));
                i++;
            }
        }

        //Завершить
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

        //Пауза для читателя
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
        //Продолжение для читателя
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
        //Пауза для писателя
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
        //Продолжение для писателя
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

        //Пауза главного потока
        public void Stop()
        {
            if (myThread.ThreadState != ThreadState.Suspended && myThread.ThreadState != ThreadState.Stopped)
            {
                StopReaders();
                StopWriters();
                myThread.Suspend();
            }
        }
        //Продолжение главного потока
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
