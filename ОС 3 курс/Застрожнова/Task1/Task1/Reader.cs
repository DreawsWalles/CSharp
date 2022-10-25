using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading;

namespace Task1
{
    class Reader
    {
        //поле отображения информации
        private TextBox txtBox;
        //общее количество сообщений 
        private int MesNumber;
        //номер читателя
        private int num;
        //Буфер
        private BufStack Buf;
        //Поток читателя
        private Thread myThread;

        //конструктор
        public Reader(TextBox textB, int MesNum,int number,BufStack buf)
        {
            txtBox = textB;
            MesNumber = MesNum;
            Buf = buf;
            num = number;
            myThread = new Thread(this.Read);
            myThread.Start();
        }

        //вывод
        public void Read()
        {
            Random myRandom = new Random();
            txtBox.Invoke(new Action(() => txtBox.Text += "Читатель " + num.ToString() + " создан" + Environment.NewLine));

            while (MesNumber > 0)
            { 
                if (Buf.countBuf > 0)
                {
                    Buf.Pop(num);
                    MesNumber--;
                }
                Thread.Sleep(myRandom.Next(300, 800));
            }
            txtBox.Invoke(new Action(() => txtBox.Text += "Читатель " + num.ToString() + " уничтожен" + Environment.NewLine));
        }

        //завершение потока
        public void Abort()
        {
            if (myThread != null)
                if (myThread.ThreadState == ThreadState.Suspended)
                {
                    myThread.Resume();
                    myThread.Abort();
                }
        }
        //пауза
        public void Stop()
        {
            if ((myThread.ThreadState == ThreadState.Running)||(myThread.ThreadState == ThreadState.WaitSleepJoin))
                myThread.Suspend();
        }
        //продолжение
        public void Resume()
        {
            if (myThread.ThreadState == ThreadState.Suspended)
                myThread.Resume();
        }
    }
}
