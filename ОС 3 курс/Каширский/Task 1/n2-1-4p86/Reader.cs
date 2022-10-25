using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace n2_1_4p86 {
    class Reader {
        // Сообщения
        TextBox msg;

        // Количество сообщений, которые читает читатель
        const int msgCnt = 5;

        // Буфер, из которого считываем
        Buffer buf;

        // Номер читателя
        int num;

        // Конструктор читателя
        public Reader (TextBox pOut, Buffer pBuffer, int pNum) {
            msg = pOut;
            buf = pBuffer;
            num = pNum;
        } //public Reader

        // Жизненный цикл читателя
        public void Read () {
            int cntSteps = 0;
            msg.Invoke (new Action(() => msg.Text += "Reader " + num.ToString() + " started work" + Environment.NewLine));

            while (cntSteps < msgCnt) {
                cntSteps++;
                string message = "";
                if (buf.WasRead(out message))
                    msg.Invoke(new Action(() => msg.Text += "Reader " + num.ToString() + " got a message '" + message + "'" + Environment.NewLine));
                else
                    msg.Invoke(new Action(() => msg.Text += "Reader " + num.ToString() + " tried get a message, but buffer was empty" + Environment.NewLine));
                Thread.Sleep(new Random().Next(100, 200));
            }

            msg.Invoke(new Action(() => msg.Text += "Reader " + num.ToString() + " finished work" + Environment.NewLine));
        } //public void Read
    } //class Reader
} //namespace n2_1_4p86
