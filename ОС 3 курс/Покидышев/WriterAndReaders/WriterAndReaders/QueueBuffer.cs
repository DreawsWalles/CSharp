using System;
using System.Collections.Generic;

namespace WriterAndReaders
{
    internal class QueueBuffer<T>
    {
        private readonly Queue<T> _queue = new Queue<T>();
        private readonly int _maxCount;

        public int Count
        {
            get
            {
                lock (this)
                {
                    return _queue.Count;
                }
            }
        }

 
        public QueueBuffer(int max)
        {
            _maxCount = max;
        }


        public void Enqueue(T item)
        {
            lock (this)
            {
                if (_queue.Count > _maxCount)
                    throw new Exception("Trying to enqueue item in full buffer");
                _queue.Enqueue(item);
            }
        }

        public bool Dequeue(ref T item)
        {
            lock (this)
            {
                if (_queue.Count <= 0)
                    return false;
                    //throw new Exception("Trying to dequeue item from empty buffer");
                item = _queue.Dequeue();
                return true;
            }
        }
    }
}
