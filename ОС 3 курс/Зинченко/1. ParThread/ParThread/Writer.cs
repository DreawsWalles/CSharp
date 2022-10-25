using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace ParThread
{
    class Writer
    {

        //Буфер
        MessageBuffer buff;



        //Текстбокс для вывода состояния
        TextBox output;

        //Номер писателя
        int num;

        public Writer(TextBox output, MessageBuffer buff, int num)
        {
            this.output = output;
            this.buff = buff;
            this.num = num;
        }

        //Жизненный цикл писателя
        public void Write()
        {
            output.Invoke(new Action(() => output.Text += "Писатель " + num.ToString() + " начал работу" + Environment.NewLine));
            while (true)//messagesWrite < messageCount)
            {
                string message = "П" + num.ToString() + " :" + new Random().Next(1000).ToString();
                if (buff.Write(message))
                    output.Invoke(new Action(() => output.Text += "Писатель " + num.ToString() + " положил сообщение " + message + Environment.NewLine));
                else
                    output.Invoke(new Action(() => output.Text += "Писатель " + num.ToString() + " попытался положить сообщение в заполненный" + Environment.NewLine));
                Thread.Sleep(new Random().Next(500, 1500));
            }

            //output.Invoke(new Action(() => output.Text += "Писатель " + num.ToString() + " завершил работу"  + Environment.NewLine));
        }
    }
}
