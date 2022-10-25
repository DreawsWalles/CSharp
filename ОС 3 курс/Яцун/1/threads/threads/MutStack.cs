using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace threads
{
    class MutStack
    {
        TextBox tbStack;
        public static Stack<int> generalStack;
        public static Mutex mut;

        public MutStack(TextBox varTextBox)
        {            
            tbStack = varTextBox;
            mut = new Mutex();
            generalStack = new Stack<int>();
        }     
        
        public void Push(int x)
        {
            mut.WaitOne();
            MutStack.generalStack.Push(x);
            PrintStack();
            mut.ReleaseMutex();
        }

        public int Pop()
        {
            mut.WaitOne();
            int x = MutStack.generalStack.Pop();
            PrintStack();
            mut.ReleaseMutex();

            return x;
        }

        void PrintStack()
        {
            tbStack.Invoke(new Action(() => tbStack.Clear()));

            int[] array = new int[generalStack.Count];
            generalStack.CopyTo(array, 0);
            
            string text = "";

            for(int i = 0; i < generalStack.Count; i++)
            {
                text += array[i].ToString() + Environment.NewLine;
            }

            tbStack.Invoke(new Action<string>((s) => tbStack.Text = s), text);
        }
    }
}
