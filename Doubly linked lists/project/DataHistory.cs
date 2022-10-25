using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace project
{
    public struct DataNode
    {
        public string name;
        public string path;
        public string date;
    }
    class Data
    {
       public  DataNode node;
       public Data next;

        public Data()
        {
            next = null;
        }
        public Data(DataNode n)
        {
            node = n;
            next = null;
        }
    }
    public class DataHistory
    {
        Data head;
        public int Count { get; set; }
        StreamReader fileR;
        StreamWriter fileW;
        public DataHistory()
        {
            head = null;
            Count = 0;
            if (!Directory.Exists("history"))
            {
                Directory.CreateDirectory("history");
                File.Create("history/history.bin");
            }
            if (!File.Exists("history/history.bin"))
                File.Create("history/history.bin");
            else
            {
                fileR = new StreamReader(File.Open("history/history.bin", FileMode.Open));
                DataNode n;
                while (fileR.Peek() > -1)
                {
                    n.name = fileR.ReadLine();
                    n.path = fileR.ReadLine();
                    n.date = fileR.ReadLine();
                    Add_private(n);
                }
                fileR.Close();
            }
        }
        void Add_private(DataNode n)
        {
            if (head == null)
                head = new Data(n);
            else
            {
                Data tmp = new Data(n);
                Data current = head;
                while (current.next != null)
                    current = current.next;
                current.next = tmp;
            }
            Count++;
        }
        public void Add(DataNode n)
        {
            if (head == null)
                head = new Data(n);
            else
            {
                Data tmp = new Data(n);
                Data current = head;
                while (current.next != null)
                    current = current.next;
                current.next = tmp;
            }
            Count++;
            fileW = new StreamWriter(File.Open("history/history.bin", FileMode.Append));
            fileW.WriteLine(n.name);
            fileW.WriteLine(n.path);
            fileW.WriteLine(n.date);
            fileW.Close();
        }
        public DataNode getNode(int i)
        {
            int current = 0;
            Data tmp = head;
            while (current < i)
            {
                tmp = tmp.next;
                current++;
            }
            return tmp.node;
        }
    }
}
