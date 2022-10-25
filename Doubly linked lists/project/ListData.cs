using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class ListData<T>
    {
        LinkNode<T> head;
        int Count;
        public ListData()
        {
            head = null;
            Count = 0;
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
        public LinkNode<T> Search(int index)
        {
            LinkNode<T> current = head;
            int new_index = 0;
            while (current != null)
            {
                if (new_index == index)
                    return current;
                current = current.next;
                new_index++;
            }
            return null;
        }
    }
}
