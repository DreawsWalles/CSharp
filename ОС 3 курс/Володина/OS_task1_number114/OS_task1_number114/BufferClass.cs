using System.Collections.Generic;

namespace OS_task1_number114
{
    public static class BufferClass
    {
        public static readonly Stack<int> Buffer = new Stack<int>();

        public static int Count => Buffer.Count;

        public const int Max = 4;

        private static readonly object Lock = new object();

        public static bool Push(int elem)
        {
            lock (Lock)
            {
                if (Buffer.Count >= Max)
                    return false;
                Buffer.Push(elem);
                return true;
            }
        }

        public static bool Pop(out int elem)
        {
            elem = 0;
            lock (Lock)
            {
                if (Buffer.Count == 0)
                    return false;
                elem = Buffer.Pop();
                return true;
            }
        }
    }
}
