using System.Windows.Forms;
using System.Threading;
using System;

namespace task1
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
        private Buffer Buf;
        //Поток писателя
        private Thread myThread;

        //конструктор
        public Writer(TextBox _textB, int _MesNum, int _number, Buffer _buf)
        {
            txtBox = _textB;
            MesNumber = _MesNum;
            Buf = _buf;
            num = _number;
            myThread = new Thread(this.Write);
            myThread.Start();
        }

        //вывод
        public void Write()
        {
            Random myRandom = new Random();
            txtBox.Invoke(new Action(() => txtBox.Text += "Writer " + num.ToString() + " was created" + Environment.NewLine));

            while (MesNumber > 0)
            {

                int tmp = myRandom.Next(num + 1);
                Buf.Push(num, tmp.ToString());
                MesNumber--;
                Thread.Sleep(myRandom.Next(300, 800));
            }
            txtBox.Invoke(new Action(() => txtBox.Text += "Writer " + num.ToString() + " was destroyed" + Environment.NewLine));
        }
        //завершение потока
        public void Abort()
        {
            if (myThread != null)
            {
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
