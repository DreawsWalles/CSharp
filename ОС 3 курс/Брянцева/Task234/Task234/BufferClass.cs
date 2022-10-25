using System.Collections.Generic;
using System.Threading;

namespace Task234
{
    public static class BufferClass
    {
        public static readonly Queue<int> Buffer = new Queue<int>();

        public static int Count => Buffer.Count;

        public const int Max = 6;

        private static readonly object Lock = new object();

        public static bool Push(int elem)
        {
            Monitor.Enter(Lock);
            try
            {
                if (Buffer.Count >= Max)
                    return false;
                Buffer.Enqueue(elem);
                return true;
            }
            finally
            {
                Monitor.Exit(Lock);
            }
        }

        public static bool Pop(out int elem)
        {
            elem = 0;
            Monitor.Enter(Lock);
            try
            {
                if (Buffer.Count == 0)
                    return false;
                elem = Buffer.Dequeue();
                return true;
            }
            finally
            {
                Monitor.Exit(Lock);
            }
        }
    }
}
