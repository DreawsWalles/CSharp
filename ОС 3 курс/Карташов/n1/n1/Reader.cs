using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace n1
{
    class Reader
    {
        TextBox output;
        Buffer buff;

        public Reader(TextBox o, Buffer b)
        {
            output = o;
            buff = b;
        }

        public void Read()
        {
            output.Invoke(new Action(() => output.Text += "Читатель начал работу" + Environment.NewLine));
            while (true)
            {
                string tmpmsg = "";
                if (buff.Read(out tmpmsg))
                    output.Invoke(new Action(() => output.Text += "Читатель забрал сообщение (" + tmpmsg + ")" + Environment.NewLine));
                else
                    output.Invoke(new Action(() => output.Text += "Читателю не удалось забрать сообщение: буфер был пуст" + Environment.NewLine));
                Thread.Sleep(new Random().Next(100, 1500));
            }
        }
    }
}
