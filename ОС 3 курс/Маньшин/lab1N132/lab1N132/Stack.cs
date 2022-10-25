using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab1N132
{
    class Buffer<T>
    {
        public event Action<bool> Changed;

        object locker = new object();
        int capacity;
        Stack<T> stack;

        public int Capacity { get { return capacity; } }

        public Buffer(int cap)
        {
            capacity = cap;
            stack = new Stack<T>(capacity);
        }

        public bool Put(T info)
        {
            Monitor.Enter(locker);
            if (stack.Count == capacity)
            {
                Monitor.Exit(locker);
                return false;
            }

            stack.Push(info);
            Changed(true);
            Monitor.Exit(locker);
            return true;
        }

        public bool Take(out T info)
        {
            Monitor.Enter(locker);
            try
            {
                info = stack.Pop();
            }
            catch (InvalidOperationException e)
            {
                info = default(T);
                return false;
            }
            finally
            {
                Monitor.Exit(locker);
            }

            Changed(false);
            return true;
        }
    }
}
