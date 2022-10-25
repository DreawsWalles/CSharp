using System;
using System.Collections.Generic;
using System.Threading;

namespace Task4
{
    // Очередь с приоритетом
    public class QueuePriority<T> : IQueue<T> where T : IComparable
    {       
        //элем очереди
        private class Node<T>
        {
            public T Element;
            public Node<T> Next;
            public Node(T elem)
            {
                Element = elem;
                Next = null;
            }
        }

        private Node<T> _head;

        int _count;
        
        // Кол-во элементов в очереди.
        public int Count
        {
            get { return _count; }
        }
        
        // Проверка на пустоту
        public bool IsEmpty
        {
            get { return _count == 0; }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса
        /// </summary>
        public QueuePriority()
        {
            _head = null;
        }

        // Добавлене элемента в очередь
        public void Enqueue(T elem)
        {
            Monitor.Enter(this);//блокируем, чтобы никто не мог обратиться
            try
            {
                if (_head == null)
                    _head = new Node<T>(elem);
                else
                {
                    Node<T> addElem = new Node<T>(elem);
                    if (_head.Element.CompareTo(elem) > 0)//сравниваем
                    {
                        var tmp = _head;
                        while (tmp.Next != null && tmp.Element.CompareTo(elem) > 0)
                            tmp = tmp.Next;
                        addElem.Next = tmp.Next;//добавляем элемент
                        tmp.Next = addElem;
                    }
                    else
                    {
                        addElem.Next = _head;
                        _head = addElem;
                    }
                }
                _count++;
            }
            finally
            {
                Monitor.Exit(this);//снимаем блокировку
            }
        }

        // Очистка очереди
        public void Clear()
        {
            _count = 0;
            _head = null;
        }
        
        // Изъятие элемента из очереди
        public T Dequeue()
        {
            Monitor.Enter(this);//блокируем
            try
            {
                if (_head == null)
                    throw new Exception("Очередь пуста!");
                _count--;// уменьшаем кол-во
                var x = _head.Element;
                _head = _head.Next;
                return x;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node<T> tmp = _head; tmp != null; tmp = tmp.Next)
                yield return tmp.Element;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
