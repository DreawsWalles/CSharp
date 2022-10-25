using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace project
{
    class LinkNode<T>
    {
        public T node;
        public LinkNode<T> pred;
        public LinkNode<T> next;

        public LinkNode(T value)
        {
            node = value;
            pred = null;
            next = null;
        }
        public LinkNode()
        {
            pred = null;
            next = null;
        }
    }
    class LinkedList<T> : IList<T> where T : IComparable<T>
    {
        LinkNode<T> head;

        public int Count
        {
            get;
            private set;
        }

        public LinkedList()
        {
            Count = 0;
            head = null;

        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexListException();
                int current = 0;
                LinkNode<T> tmp = head;
                while (current < index)
                {
                    current++;
                    tmp = tmp.next;
                }
                return tmp.node;
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexListException();
                int current = 0;
                LinkNode<T> tmp = head;
                while (current < index)
                {
                    current++;
                    tmp = tmp.next;
                }
                tmp.node = value;
            }
        }
        public void Add(T value)
        {
            if (head == null)
                head = new LinkNode<T>(value);
            else
            {
                LinkNode<T> tmp = new LinkNode<T>(value);
                LinkNode<T> current = head;
                while (current.next != null)
                    current = current.next;
                current.next = tmp;
                tmp.pred = current;
            }
            Count++;
        }
        public void Clear()
        {
            head = null;
            Count = 0;
        }
        public int IndexOf(T value)
        {
            int result = 0;
            LinkNode<T> current = head;
            while (current != null)
            {
                if (current.node.CompareTo(value) == 0)
                    return result;
                result++;
                current = current.next;
            }
            return -1;
        }
        public bool Contains(T value)
        {
            LinkNode<T> current = head;
            while (current != null)
            {
                if (current.node.CompareTo(value) == 0)
                    return true;
                current = current.next;
            }
            return false;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexListException();
            else
            {
                if (index == 0)
                {

                    head = head.next;
                    head.pred = null;
                }
                else if (index == Count - 1)
                {
                    LinkNode<T> currnet = head;
                    int new_index = 0;
                    while (new_index < index - 1)
                    {
                        new_index++;
                        currnet = currnet.next;
                    }
                    LinkNode<T> Del = currnet.next;
                    currnet.next = null;
                    Del = null;
                }
                else
                {
                    LinkNode<T> currnet = head;
                    int new_index = 0;
                    while (new_index < index - 1)
                    {
                        new_index++;
                        currnet = currnet.next;
                    }
                    LinkNode<T> Del = currnet.next;
                    currnet.next = Del.next;
                    Del = null;
                }
            }
            Count--;
        }

        public void Remove(T value)
        {
            int index = IndexOf(value);
            if (index != -1)
                RemoveAt(index);
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > Count)
                throw new IndexListException();
            else
            {
                if (Count == 0)
                    Add(value);
                else if (index == 0)
                {
                    Count++;
                    LinkNode<T> new_node = new LinkNode<T>(value);
                    new_node.next = head;
                    head = new_node;
                }
                else if (index == Count)
                {
                    Count++;
                    LinkNode<T> current = head;
                    while (current.next != null)
                        current = current.next;
                    LinkNode<T> new_node = new LinkNode<T>(value);
                    current.next = new_node;
                }
                else
                {
                    Count++;
                    LinkNode<T> new_node = new LinkNode<T>(value);
                    LinkNode<T> current = head;
                    int index_new = 0;
                    while (index_new < index - 1)
                    {
                        index_new++;
                        current = current.next;
                    }
                    new_node.next = current.next;
                    current.next = new_node;
                    new_node.pred = current;
                }
            }   
        }

        public IList<T> subList(int fromIndex, int toIndex)
        {
            if (fromIndex < 0 && ((toIndex + 1) == Count))
                throw new RangeListException();
            IList<T> result = new LinkedList<T>();
            LinkNode<T> current = head;
            for (int i = 0; i <= fromIndex-1; i++)
                current = current.next;
            for (int i = fromIndex; i <= toIndex; i++)
            {
                result.Add(current.node);
                current = current.next;
            }
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            // Перебираем все элементы связного списка, для представления в виде коллекции элементов.
            var current = head;
            while (current != null)
            {
                yield return current.node;
                current = current.next;
            }
        }

        /// <summary>
        /// Вернуть перечислитель, который осуществляет итерационный переход по связному списку.
        /// </summary>
        /// <returns> Объект IEnumerator, который используется для прохода по коллекции. </returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            // Просто возвращаем перечислитель, определенный выше.
            // Это необходимо для реализации интерфейса IEnumerable
            // чтобы была возможность перебирать элементы связного списка операцией foreach.
            return GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Save(string path, int type, int realization, bool mutable)
        {
            StreamWriter file = new StreamWriter(File.Create(path));
            if (mutable)
                file.WriteLine("+");
            else
                file.WriteLine("-");
            file.WriteLine(type);
            file.WriteLine(realization);
            LinkNode<T> current = head;
            while (current != null)
            {
                file.WriteLine(current.node);
                current = current.next;
            }
            file.Close();
        }
    }
}
