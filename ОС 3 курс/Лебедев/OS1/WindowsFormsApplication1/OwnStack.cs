using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{

    class OwnStack
    {
        public static int max = 10;
        public Stack<int> stk = new Stack<int>(max);
        //private Provider prv1, prv2, prv3;
        //private Customer cst1, cst2, cst3;
        private TextBox OutMessageC;
        private TextBox OutMessageP;
        //public static int CountTake = 4;
        //public static int CountAdd = 4;
        private TextBox goods;
        //private object _lock;

        public OwnStack(TextBox _OutMessageC, TextBox _OutMessageP, TextBox _gds)
        {
            stk = new Stack<int>(max);
            OutMessageC = _OutMessageC;
            OutMessageP = _OutMessageP;
            goods = _gds;

            //prv1 = new Provider(OutMessageP, stk, _lock, _j + 1, _gds);
            //prv2 = new Provider(OutMessageP, stk, _lock, _j + 2, _gds);
            //prv3 = new Provider(OutMessageP, stk, _lock, _j + 3, _gds);

            //cst1 = new Customer(OutMessageC, stk, _lock, _i + 1, _gds);
            //cst2 = new Customer(OutMessageC, stk, _lock, _i + 2, _gds);
            //cst3 = new Customer(OutMessageC, stk, _lock, _i + 3, _gds);

        }

        public bool Take(out int tmp)
        {
            lock (this)
            {
                if (stk.Count == 0)
                {
                    tmp = -1;
                    return false;
                }
                else

                    goods.Invoke(new Action(() =>
                    {
                        String[] words = goods.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        if (words.Length == 0)
                            words[0] = "";
                        goods.Text = "";
                        for (int k = 0; k < words.Length - 1; ++k)
                            goods.Text += words[k] + "\r\n";
                    }));
                tmp = stk.Pop();
            }
            return true;
        }
         

        public bool Provide(int tmp)
        {
            lock(this)
            {
                if (stk.Count >= max)
                    return false;

                goods.Invoke(new Action(() => goods.Text += tmp.ToString() + "\r\n"));
                
                stk.Push(tmp);
                return true;
            }
           
        }

        /*goods.Invoke(new Action(() =>
                {
                    String[] words = goods.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length == 0)
                        words[0] = "";
                    goods.Text = "";
                    for (int k = 0; k<words.Length - 1; ++k)
                        goods.Text += words[k] + "\r\n";
                }));*/
        
        /*public void Provide(int _j)
        {
            int i = 0;

            while (i < CountAdd)
            {
                lock (_lock)
                {
                    if (stk.Count == OwnStack.max)
                        continue;
                    int temp = new Random().Next(100);
                    stk.Push(temp);
                    OutMessageP.Invoke(new Action(() => OutMessageP.Text += "Поставщик " + cst1.num.ToString() + " добавил товар " + temp.ToString() + "\r\n"));
                    goods.Invoke(new Action(() => goods.Text += temp.ToString() + "\r\n"));
                    i++;
                    Thread.Sleep(150);
                }
                Thread.Sleep(new Random().Next(300, 500));
            }
            
        }*/

        public void Clear()
        {
            stk.Clear();
        }
    }

    


}
