using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadManager
{
    class Queues
    {
        static public List<PlannedThread> listOfThreads;
        static Mutex listMutex;

        static public Queue<PlannedThread> queueOfPlannedThreads;
        static Mutex queueMutex;

        public Queues()
        {
            listOfThreads = new List<PlannedThread>();
            listMutex = new Mutex();

            queueOfPlannedThreads = new Queue<PlannedThread>();
            queueMutex = new Mutex();
        }

        public PlannedThread TakeFirstFromList()
        {
            listMutex.WaitOne();
            PlannedThread res = listOfThreads[0];
            listOfThreads.RemoveAt(0);
            listMutex.ReleaseMutex();

            return res;
        }

        public void AddToList(PlannedThread varTHread)
        {
            listMutex.WaitOne();
            listOfThreads.Add(varTHread);
            listMutex.ReleaseMutex();
        }

        public int ListCount()
        {
            return listOfThreads.Count;
        }

        public int QueueCount()
        {
            return queueOfPlannedThreads.Count;
        }

        public void Enqueue(PlannedThread varTHread)
        {
            queueMutex.WaitOne();
            queueOfPlannedThreads.Enqueue(varTHread);
            queueMutex.ReleaseMutex();
        }

        public PlannedThread Dequeue()
        {
            queueMutex.WaitOne();
            PlannedThread res = queueOfPlannedThreads.Dequeue();
            queueMutex.ReleaseMutex();

            return res;
        }

        public void TransferFromListToQueue()
        {
            listMutex.WaitOne();
            queueMutex.WaitOne();

            PlannedThread tmpThread = listOfThreads[0];
            listOfThreads.RemoveAt(0);
            queueOfPlannedThreads.Enqueue(tmpThread);

            listMutex.ReleaseMutex();
            queueMutex.ReleaseMutex();
        }

        public bool IsContainsInQueue(PlannedThread varThread)
        {
            queueMutex.WaitOne();
            bool find = false;

            foreach (PlannedThread item in queueOfPlannedThreads)
            {
                if (item != null && item.ThreadName == varThread.ThreadName)
                {
                    find = true;
                    break;
                }
            }

            queueMutex.ReleaseMutex();

            return find;
        }

        public void FromEventToQueue(PlannedThread varThread)
        {
            listMutex.WaitOne();
            queueMutex.WaitOne();
            
            queueOfPlannedThreads.Enqueue(varThread);

            int i = -1;
            foreach (PlannedThread item in listOfThreads)
            {
                i++;
                if (item.ThreadName == varThread.ThreadName)
                {
                    break;
                }
            }

            if (i != -1)
                listOfThreads.RemoveAt(i);

            listMutex.ReleaseMutex();
            queueMutex.ReleaseMutex();
        }

        public void FromEventToBlockList(PlannedThread varThread)
        {
            listMutex.WaitOne();

            listOfThreads.Add(varThread);

            listMutex.ReleaseMutex();
        }

        public string QueueToString()
        {
            queueMutex.WaitOne();

            string result = "";

            foreach (PlannedThread item in queueOfPlannedThreads)
            {
                result += item.ThreadName + " -- ";
            }

            queueMutex.ReleaseMutex();

            return result;
        }

        public string ListToString()
        {
            listMutex.WaitOne();

            string result = "";

            foreach (PlannedThread item in listOfThreads)
            {
                result += item.ThreadName + " -- ";
            }

            listMutex.ReleaseMutex();

            return result;
        }
    }
}
