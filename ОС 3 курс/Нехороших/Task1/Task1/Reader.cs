using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Task1
{
    class Reader
    {
        private TextBox tb;
        TextBox pb;
        string num;


        public Reader(TextBox _tb, TextBox _pb)
        {
            tb = _tb;
            pb = _pb;
            Random rnd = new Random();
            int _num = rnd.Next(15);
            this.num = _num.ToString();
        }

        public void ReadInfo()
        {
            Random rand = new Random();
            tb.AppendText("Создан читатель " + num + Environment.NewLine);
            //Thread.Sleep(rand.Next(7000));
            //ждем семафор и мьютекс
            tb.AppendText("Читатель " + num + " ждет семафор и мьютекс" + Environment.NewLine);
            Buffer.Pop(pb);
            tb.AppendText("Читатель " + num + " извлек данные и ушел " + Environment.NewLine);
        }
    }
}
