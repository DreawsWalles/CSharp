using System;
using System.Threading;
using System.Collections.Generic;

namespace OS1
{
    static class Buffer
    {
        static Mutex mutex = null;

        public static void InitializeMutex()
        {
            if (mutex == null)
                mutex = new Mutex();
        }

        public static void DisposeMutex()
        {
            if (mutex != null)
                mutex.Dispose();
        }

        static Queue<string> buffer = new Queue<string>();

        public static int RecordsCount
        {
            get { return buffer.Count; }
        }

        static Semaphore WritersSemaphore = null;

        static Semaphore ReadersSemaphore = null;

        public static void InitializeSemaphore()
        {
            if(WritersSemaphore == null)
                WritersSemaphore = new Semaphore(maxBufferSize, maxBufferSize);
            if (ReadersSemaphore == null)
                ReadersSemaphore = new Semaphore(0, maxBufferSize);
        }

        public static void DisposeSemaphore()
        {
            if (WritersSemaphore != null)
                WritersSemaphore.Dispose();
            if (ReadersSemaphore != null)
                ReadersSemaphore.Dispose();
        }

        static int maxBufferSize = 10;

        public static int MaxBufferSize
        {
            get { return maxBufferSize; }
        }

        public static string WorkWithBuffer(Worker worker)
        {
            string result = "";
            if (worker is Writer)
            {
                WritersSemaphore.WaitOne();
                mutex.WaitOne();
                buffer.Enqueue(worker.Name + " added record #" + worker.PerformedActions.ToString());
                mutex.ReleaseMutex();
                ReadersSemaphore.Release();
            }
            else
            {
                WritersSemaphore.Release();
                mutex.WaitOne();
                result = buffer.Dequeue();
                mutex.ReleaseMutex();
                ReadersSemaphore.WaitOne();
            }
            Thread.Sleep(1000);
            return result;
        }

        public static string BufferToString()
        {
            string result = "";
            foreach (string str in buffer)
                result += str + Environment.NewLine;
            return result;
        }
    }
}
