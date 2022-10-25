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
        //Текст-бокс отображения информации
        private TextBox txtBox;
        //общее количество сообщений 
        private int MesNumber;
        //номер читателя
        private int num;
        //Буфер
        private BufStack buffer;
        //Поток читателя
        private Thread myThread;

        //конструктор
        public Reader(TextBox textB, int MesNum,int number,BufStack buf)
        {
            txtBox = textB;
            MesNumber = MesNum;
            buffer = buf;
            num = number;
            myThread = new Thread(this.LogWrite);
            myThread.Start();
        }

        //Вывод
        public void LogWrite()
        {
            Random myRandom = new Random();
            txtBox.Invoke(new Action(() => txtBox.Text += "Читатель " + num.ToString() + " создан" + Environment.NewLine));

            while (MesNumber > 0)
            { 
                if (buffer.countBuf > 0)
                {
                    buffer.Pop(num);
                    MesNumber--;
                }
                Thread.Sleep(myRandom.Next(300, 800));
            }
            txtBox.Invoke(new Action(() => txtBox.Text += "Читатель " + num.ToString() + " уничтожен" + Environment.NewLine));
        }

        //Завершение потока
        public void Abort()
        {
            if (myThread != null)
                if (myThread.ThreadState == ThreadState.Suspended)
                {
                    myThread.Resume();
                    myThread.Abort();
                }
        }

        //Пауза
        public void Stop()
        {
            if ((myThread.ThreadState == ThreadState.Running)||(myThread.ThreadState == ThreadState.WaitSleepJoin))
                myThread.Suspend();
        }

        //Продолжение
        public void Resume()
        {
            if (myThread.ThreadState == ThreadState.Suspended)
                myThread.Resume();
        }
    }
}
