using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ParThread
{
    class Reader
    {
        //Текстбокс для вывода состояния
        TextBox output;
        //Буфер
        MessageBuffer buff;


        //Номер читателя
        int num;

        public Reader(TextBox Output, MessageBuffer buff, int num)
        {
            output = Output;
            this.buff = buff;
            this.num = num;
        }
        //Жизненный цикл читателя
        public void Read()
        {
            output.Invoke(new Action(() => output.Text += "Читатель " + num.ToString() + " начал работу" + Environment.NewLine));
            while (true)
            {
                string message = "";
                if (buff.Read(out message))
                    output.Invoke(new Action(() => output.Text += "Читатель " + num.ToString() + " забрал сообщение" + message + Environment.NewLine));
                else
                    output.Invoke(new Action(() => output.Text += "Читатель " + num.ToString() + " попытался забрать сообщение, буфер был пуст" + Environment.NewLine));
                Thread.Sleep(new Random().Next(500, 1500));
            }
        }
    }
}
