using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    class Provider
    {
        private TextBox OutMessageP;
        public static int CountAdd = 4;
        OwnStack OS;
        public int num;

        public Provider(TextBox _OutMessageP, OwnStack _OS, int _num)
        {
            OutMessageP = _OutMessageP;
            OS = _OS;
            num = _num;
        }

        public void Provide()
        {
            int i = 0;

            while (i < CountAdd)
            {
                i++;
                int temp = new Random().Next(1000);
                if (OS.Provide(temp))
                    OutMessageP.Invoke(new Action(() => OutMessageP.Text += "Поставщик " + num.ToString() + " добавил товар " + temp.ToString() + "\r\n"));

                Thread.Sleep(new Random().Next(300, 500));
            }

        }

    }
}
