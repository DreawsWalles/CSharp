using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace program_1
{
    class DataStack
    {
        private TextBox output;
        public static Stack<int> stack;

        public DataStack(TextBox tb)
        {
            this.output = tb;
            stack = new Stack<int>();
        }     
        
        public void Push(int x)
        {
            lock (this)
            {
                DataStack.stack.Push(x);
                PrintStack();
            }
        }

        public int? Pop()
        {
            lock (this)
            {
                int? x = null;
                if (DataStack.stack.Count > 0)
                     x = DataStack.stack.Pop();
                PrintStack();
                return x;
            }
        }

        void PrintStack()
        {
            output.Invoke(new Action(() => output.Clear()));

            int[] array = new int[stack.Count];
            stack.CopyTo(array, 0);
            
            string text = "";

            for(int i = 0; i < stack.Count; i++)
                text += array[i].ToString() + Environment.NewLine;

            output.Invoke(new Action<string>((s) => output.Text = s), text);
        }

        // Очистка стека
        public void Clear()
        {
            stack.Clear();
        }
    }
}
