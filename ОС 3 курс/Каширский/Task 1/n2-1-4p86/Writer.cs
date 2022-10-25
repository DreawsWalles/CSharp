using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace n2_1_4p86 {
    class Writer {
        // Сообщения
        TextBox msg;

        // Количество сообщений, которые читает читатель
        const int msgCnt = 5;

        // Буфер, из которого считываем
        Buffer buf;

        // Номер писателя
        int num;

        // Конструктор писателя
        public Writer (TextBox pOut, Buffer pBuffer, int pNum)
        {
            msg = pOut;
            buf = pBuffer;
            num = pNum;
        } //public Writer

        // Жизненный цикл писателя
        public void Write () {
            int cntSteps = 0;
            msg.Invoke(new Action(() => msg.Text += "Writer " + num.ToString() + " started work" + Environment.NewLine));

            while (cntSteps < msgCnt) {
                cntSteps++;
                string message = "W " + num.ToString() + ": " + new Random().Next(1000).ToString();
                if (buf.WasWrite(message)) 
                    msg.Invoke(new Action(() => msg.Text += "Writer " + num.ToString() + " got a message '" + message + "'" + Environment.NewLine));  
                else
                    msg.Invoke(new Action(() => msg.Text += "Writer " + num.ToString() + " tried get a message, but buffer was full" + Environment.NewLine));
                Thread.Sleep(new Random().Next(100, 200));
            }

            msg.Invoke(new Action(() => msg.Text += "Writer " + num.ToString() + " finished work" + Environment.NewLine));
        } //public void Write ()
    } //class Writer
} //namespace n2_1_4p86
