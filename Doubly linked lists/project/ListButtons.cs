using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public class DataButton
    {
        public string path;
        public int type;
        public int realization;
        public string name;
        public bool mutable;
        public DataButton()
        {

        }
        public DataButton(string s,string n, int t, int r, bool m)
        {
            path = s;
            type = t;
            realization = r;
            name = n;
            mutable = m;
        }
    }
    public class NodeButton
    {
        public DataButton node;
        public NodeButton next;
        public NodeButton(DataButton n)
        {
            node = n;
            next = null;
        }
    }

    public class ListButtons
    {
        public NodeButton head;
        public int Count { get; set; }
        public ListButtons()
        {
            head = null;
        }
        public void Add(string path, string name, int type, int realization, bool mutable)
        {
            DataButton n = new DataButton(path, name, type, realization, mutable);
            if (head == null)
            {
                head = new NodeButton(n);
            }
            else
            {
                NodeButton current = head;
                while (current.next != null)
                    current = current.next;
                current.next = new NodeButton(n);
            }
            Count++;
        }
        public void Delete(string path)
        {
            if (head.node.path == path)
            {
                head = head.next;
            }
            else
            {
                NodeButton current = head;
                while (current != null && current.next.node.path != path)
                    current = current.next;
                if (current.next.next == null)
                {
                    current.next = null;
                }
                else
                {
                    NodeButton tmp = current.next.next;
                    current.next = tmp;
                }
            }
            Count--;
        }
        public void Clear()
        {
            NodeButton current = head;
            NodeButton tmp;
            while(current != null)
            {
                tmp = current;
                Delete(tmp.node.path);
                current = current.next;
            }
        }
    }
}
