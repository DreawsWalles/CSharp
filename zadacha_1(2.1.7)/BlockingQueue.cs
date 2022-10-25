using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zadacha_1
{
    public class BlockingQueue<T>
    {
        private readonly Queue<T> queue = new Queue<T>();
        private readonly int maxSize;
        static object locker = new object();

        private static BlockingQueue<T> blockingQueue;

        private BlockingQueue(int size)
        {
            maxSize = size;
        }
        public static BlockingQueue<T> GetInstanse()
        {
            lock (locker)
            {
                if (blockingQueue == null)
                    blockingQueue = new BlockingQueue<T>(FormMain.maxSize);
            }
            return blockingQueue;
        }


        public bool IsEmpty
        {
            get
            {
                return queue.Count == 0;
            }
        }
        public bool TryEnqueue(T item)
        {
            lock (queue)
            {
                if (queue.Count == maxSize)
                {
                    FormMain.GetInstanse().AddNewMessage(Thread.CurrentThread.Name + " будет уничтожен", "logThreads");
                    return false;
                }
                else
                {
                    queue.Enqueue(item);
                    FormMain.GetInstanse().AddElement((dynamic)item);

                    return true;
                }
            }
        }

        public bool TryDequeue(out T value)
        {
            lock (queue)
            {
                if (queue.Count == 0)
                {
                    value = default(T);
                    return false;
                }

                value = queue.Dequeue();
                FormMain.GetInstanse().RemoveElement();
                return true;
            }
        }
    }
}
