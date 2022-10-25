using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Task1
{
    class BufStack
    {
        //структура данных хранящаяя информацию
        private Stack<string> Stack;
        //поле вывода информации
        private TextBox txtBox;
        //размер
        private int max_size;
        //заполненость буфера
        public int countBuf { get { return Stack.Count; } }

        //конструктор
        public BufStack(TextBox textB, int size)
        {
            max_size = size;
            txtBox = textB;
            Stack = new Stack<string>();
        }

        //добавление
        public void Push(int num,string str)
        {
            System.Threading.Monitor.Enter(this);
            try
            {
                if (Stack.Count < max_size)
                {
                    Stack.Push(str);
                    txtBox.Invoke(new Action(() => txtBox.Text += "Писатель " + num.ToString() + " добавил число " + str.ToString() + Environment.NewLine));
                }
                else txtBox.Invoke(new Action(() => txtBox.Text += "\nДля писателя " + num.ToString() + " нет места в буффере" + Environment.NewLine));
            }
            finally
            {
                System.Threading.Monitor.Exit(this);
            }
        }

        //извлечение
        public void Pop(int num)
        {
            System.Threading.Monitor.Enter(this);
            try
            {
                if (Stack.Count > 0)
                {
                    string tmp = Stack.Pop();
                    txtBox.Invoke(new Action(() => txtBox.Text += "Читатель " + num.ToString() + " забрал число " + tmp.ToString() + Environment.NewLine));
                }

                else txtBox.Invoke(new Action(() => txtBox.Text += "\nДля читателя " + num.ToString() + " буффер пуст" + Environment.NewLine));
            }
            finally
            {
                System.Threading.Monitor.Exit(this);
            }
        }

    }
}
