using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ThreadsTask_1
{
    class StackBuffer
    {
        private Stack<string> stb;
        private TextBox txtBox;
        private int max_amount;
        public int Count { get { return stb.Count; } }


        public StackBuffer(TextBox t,int m)
        {
            max_amount = m;
            txtBox = t;
            stb = new Stack<string>();
        }

        public void Push(int num,string s)
        {
            lock (this)
            {
                if (stb.Count < max_amount)
                {
                    stb.Push(s);
                    txtBox.Invoke(new Action(() => txtBox.Text += "Писатель " + num.ToString() + " добавил число " + s.ToString() + "\n"));
                }
            }
        }

        public string Pop(int num)
        {
            lock (this)
            {
                string tmp="-1";
                if (stb.Count > 0)
                {
                    tmp = stb.Pop();
                    txtBox.Invoke(new Action(() => txtBox.Text += "Читатель " + num.ToString() + " забрал число " + tmp.ToString() + "\n"));
                }
                return tmp;
            }
            
        }
        


    }
}
