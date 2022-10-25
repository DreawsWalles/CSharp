using System;  
using System.Collections.Generic;

namespace WriterAndReaders
{
    internal class StackBuffer<T>
    {
        private readonly Stack<T> _stack = new Stack<T>();
        private readonly int _maxCount;

        public int Count
        {
            get
            {
                lock (this)
                {
                    return _stack.Count;
                }
            }
        }

 
        public StackBuffer(int max)
        {
            _maxCount = max;
        }


        public void Push(T item)
        {
            lock (this)
            {
                if (_stack.Count > _maxCount)
                    throw new Exception("Trying to enqueue item in full buffer");
                _stack.Push(item);
            }
        }

        public bool Pop(ref T item)
        {
            lock (this)
            {
                if (_stack.Count <= 0)
                    return false;
                item = _stack.Pop();
                return true;
            }
        }
    }
}
