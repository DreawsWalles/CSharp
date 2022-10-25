using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Task1
{
    class Writer
    {
        private TextBox tb;
        TextBox pb;
        
        public Writer(TextBox _tb, TextBox _pb)
        {
            tb = _tb;
            pb = _pb;
        }

        // Добавление данных в буфер
        public void WriteInfo()
        {
            Random rand = new Random();
            int addval;
            while (true)
            {
                Thread.Sleep(rand.Next(1000, 2000));
                addval = rand.Next(0, 100);
                //ждем семафор и мьютекс
                tb.AppendText("Писатель ждет семафор и мьютекс" + Environment.NewLine);
                Buffer.Push(addval, pb);
                tb.AppendText("Писатель поместил число " + addval.ToString() + Environment.NewLine);
            }
        }
    }
}
