using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace task1
{
    class Buffer
    {
        //структура данных, хранящаяя информацию
        private Stack<string> stb;
        //поле вывода информации
        private TextBox txtBox;
        //размер
        private int max_size;
        //заполненость буфера
        public int Count { get { return stb.Count; } }


        public Buffer(TextBox t, int m)
        {
            max_size = m;
            txtBox = t;
            stb = new Stack<string>();
        }

        public void Push(int _num, string _s)
        {
            lock (this)
            {
                if (stb.Count < max_size)
                {
                    stb.Push(_s);
                    txtBox.Invoke(new Action(() => txtBox.Text += "Writer " + _num.ToString() + " add number " + _s.ToString() + Environment.NewLine));
                }
            }
        }

        public bool Pop(int _num)
        {
            lock (this)
            {
                if (stb.Count > 0)
                {
                    string tmp = stb.Pop();
                    txtBox.Invoke(new Action(() => txtBox.Text += "Reader " + _num.ToString() + " delete number " + tmp.ToString() + Environment.NewLine));
                    return true;
                }
                return false;
            }

        }
    }
}
