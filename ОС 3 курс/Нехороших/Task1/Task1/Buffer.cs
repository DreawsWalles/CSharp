using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Task1
{
    public static class Buffer
    {
        public static Queue<int> Buff = new Queue<int>();
        public const int Max = 7;

        public static Semaphore writeSem = new Semaphore (Max, Max);
        public static Semaphore readSem = new Semaphore(0, Max);
        public static Mutex mut = new Mutex();

        public static void Push(int elem, TextBox pb)
        {
            writeSem.WaitOne();
            mut.WaitOne();
            Buff.Enqueue(elem);
            PrintInfo(pb);
            mut.ReleaseMutex();
            readSem.Release();
        }

        public static void Pop(TextBox pb)
        {
            readSem.WaitOne();
            mut.WaitOne();
            Buff.Dequeue();
            PrintInfo(pb);
            mut.ReleaseMutex();
            writeSem.Release();
        }

        static void PrintInfo(TextBox pritbuf)
        {
            pritbuf.Clear();
            foreach (int i in Buffer.Buff)
                pritbuf.AppendText(i + Environment.NewLine);
        }
    }
    
}
