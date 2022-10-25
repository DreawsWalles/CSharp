using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace n1
{
    class Buffer
    {
        public static int max_capacity = 10;
        Queue<string> messages_queue;
        private TextBox queue_tb;
        public Buffer(TextBox output)
        {
            queue_tb = output;
            messages_queue = new Queue<string>();
        }

        public void Clear()
        {
            messages_queue.Clear();
        }

        void RemoveFirstLine()
        {
            if (queue_tb.Lines.Length > 0)
            {
                List<string> list = queue_tb.Lines.ToList();
                list.RemoveAt(0);
                queue_tb.Lines = list.ToArray();
            }
        }

        public bool Write(string s)
        {
            Monitor.Enter(this);
            try
            {
                if (messages_queue.Count >= max_capacity)
                    return false;
                else
                {
                    queue_tb.Invoke(new Action(() => queue_tb.Text += s + "\r\n"));
                    messages_queue.Enqueue(s);
                }
                return true;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
        public bool Read(out string s)
        {
            Monitor.Enter(this);
            try
            {
                if (messages_queue.Count == 0)
                {
                    s = "";
                    return false;
                }
                else
                {
                    queue_tb.Invoke(new Action(RemoveFirstLine));
                    s = messages_queue.Dequeue();
                }
                return true;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
    }
}
