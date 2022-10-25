using System;
using System.Windows.Forms;
using System.Threading;

namespace task1
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
        private Buffer Buf;
        //Поток читателя
        private Thread myThread;

        //конструктор
        public Reader(TextBox _textB, int _MesNum, int _number, Buffer _buf)
        {
            txtBox = _textB;
            MesNumber = _MesNum;
            Buf = _buf;
            num = _number;
            myThread = new Thread(this.Read);
            myThread.Start();
        }

        //вывод
        public void Read()
        {
            Random myRandom = new Random();
            txtBox.Invoke(new Action(() => txtBox.Text += "Reader " + num.ToString() + " was created" + Environment.NewLine));

            while (MesNumber > 0)
            {
                if (Buf.Count > 0)
                {
                    Buf.Pop(num);
                    MesNumber--;
                }
                Thread.Sleep(myRandom.Next(300, 800));
            }
            txtBox.Invoke(new Action(() => txtBox.Text += "Reader " + num.ToString() + " was destroyed" + Environment.NewLine));
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
