using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace n1
{
    class Writer
    {
        const int message_count = 5;
        TextBox input;
        Buffer buff;
        int writer_num;

        public Writer(TextBox i, Buffer b, int num)
        {
            input = i;
            buff = b;
            writer_num = num;
        }

        public void Write()
        {
            int wrt_msgs = 0;
            input.Invoke(new Action(() => input.Text += "Писатель " + writer_num.ToString() + " начал работу" + Environment.NewLine));
            while (wrt_msgs < message_count)
            {
                wrt_msgs += 1;
                string tmpmsg = "Писатель " + writer_num.ToString() + ": " + new Random().Next(1000).ToString();
                if (buff.Write(tmpmsg))
                    input.Invoke(new Action(() => input.Text += "Писатель " + writer_num.ToString() + " добавил сообщение" + Environment.NewLine));
                else
                    input.Invoke(new Action(() => input.Text += "Писателю " + writer_num.ToString() + " не удалось добавить сообщение: буфер полон" + Environment.NewLine));
                Thread.Sleep(new Random().Next(500, 1500));
            }
            input.Invoke(new Action(() => input.Text += "Писатель " + writer_num.ToString() + " завершил работу" + Environment.NewLine));
        }
    }
}
