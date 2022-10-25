using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Task1
{
    class Writer
    {
        //поле отображения информации
        private TextBox txtBox;
        //общее количество сообщений 
        private int MesNumber;
        //номер писателя
        private int num;
        //Буфер
        private BufStack Buf;
        //Поток писателя
        private Thread myThread;
        
        //конструктор
        public Writer(TextBox textB, int MesNum,int number, BufStack buf)
        {
            txtBox = textB;
            MesNumber = MesNum;
            Buf = buf;
            num = number;
            myThread = new Thread(this.Write);
            myThread.Start();
        }

        //вывод
        public void Write()
        {
            Random myRandom = new Random();
            txtBox.Invoke(new Action(() => txtBox.Text += "Писатель " + num.ToString() + " создан"+ Environment.NewLine));
               
            while(MesNumber>0)
            {
                
                int tmp = myRandom.Next(num+1);
                Buf.Push(num, tmp.ToString());
                MesNumber--;
                Thread.Sleep(myRandom.Next(300, 800));
            }
            txtBox.Invoke(new Action(() =>txtBox.Text += "Писатель " + num.ToString() + " уничтожен"+ Environment.NewLine));
        }

        //завершение потока
        public void Abort()
        {
            if (myThread != null) {
                if (myThread.ThreadState == ThreadState.Suspended)
                    myThread.Resume();
                myThread.Abort();
            }
        }
        //пауза
        public void Stop()
        {
            if ((myThread.ThreadState == ThreadState.Running) || (myThread.ThreadState == ThreadState.WaitSleepJoin))
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

