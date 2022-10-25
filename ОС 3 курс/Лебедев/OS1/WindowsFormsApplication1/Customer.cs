using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace WindowsFormsApplication1
{
    class Customer
    {
        //private Stack<int> stk;
        private TextBox OutMessageC;
        //private object _lock;
        public static int CountTake = 4;
        OwnStack OS;
        public int num;
        //private TextBox goods;

        /*public Customer(TextBox _OutMessageC, Stack<int> _stk, object Lock,int _i, TextBox _gds)
        {
            stk= _stk;
            _lock = Lock;
            OutMessageC = _OutMessageC;
            num = _i;
            goods = _gds;
        }*/

        public Customer(TextBox _OutMessageC, OwnStack _OS, int _num)
        {
            OutMessageC = _OutMessageC;
            OS = _OS;
            num = _num;
        }

        public void Take()
        {
            int i = 0;
            
            while (i < CountTake)
            {
                i++;
                int temp = 0;
                if (OS.Take(out temp))
                    OutMessageC.Invoke(new Action(() => OutMessageC.Text += "Потребитель " + num.ToString() + " забрал товар " + temp.ToString() + "\r\n"));

                Thread.Sleep(new Random().Next(300, 500));
            }

        }
    }
}
