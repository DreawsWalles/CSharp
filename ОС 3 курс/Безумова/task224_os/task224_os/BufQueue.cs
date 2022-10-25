using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace task224_os
{
    public class BufQueue
    {
        /// <summary>
        /// Размер буфера
        /// </summary>
        public int N;

        /// <summary>
        /// Очередь, в которую будут поступать сообщения поставщиков, и из которой они будут извлекаться потребителями
        /// </summary>
        public static Queue<int> Buffer;

        /// <summary>
        /// Поставщик, записывает данные в буфер
        /// </summary>
        public static Semaphore WriteSemaphore;

        /// <summary>
        /// Потребитель, считывает данные из буфера
        /// </summary>
        public static Semaphore ReadSemaphore;

        /// <summary>
        /// Мьютекс, синхронизирующий процессы
        /// </summary>
        public static Mutex AppMutex;

        /// <summary>
        /// Текстовое поле, на которое переносятся сообщения из буфера
        /// </summary>
        protected readonly TextBox MyTextBox;

        public BufQueue(TextBox myTextBox, int size)
        {
            N = size;
            MyTextBox = myTextBox;
            Buffer = new Queue<int>();
            WriteSemaphore = new Semaphore(N, N);
            ReadSemaphore = new Semaphore(0, N);
            AppMutex = new Mutex();
        }


        public void Push()
        {
            WriteSemaphore.WaitOne();                     
            AppMutex.WaitOne(); // синхронизация   

            var s = Thread.CurrentThread.Name;
            if (s != null)
                Buffer.Enqueue(Int32.Parse(s));
            ReadSemaphore.Release();
            
            // мьютекс освобождается
            AppMutex.ReleaseMutex();            
        }

        public void Pop()
        {
            ReadSemaphore.WaitOne();
            AppMutex.WaitOne(); // синхронизация   

            Buffer.Dequeue();
            WriteSemaphore.Release();

            // мьютекс освобождается
            AppMutex.ReleaseMutex();

        }

        public static readonly List<MainThreads> Workers = new List<MainThreads>();

        public static void Abort()
        {
            foreach (var worker in Workers)
                worker.Abort();
        }

        /// <summary>
        /// Пауза
        /// </summary>
        public static void Stop(bool forWriters)
        {
            foreach (var worker in Workers)
                if (worker.ImWriter && forWriters || !worker.ImWriter && !forWriters)
                    worker.Stop();
        }

        /// <summary>
        /// Возобновление
        /// </summary>
        public static void Resume(bool forWriters)
        {
            foreach (var worker in Workers)
                if (worker.ImWriter && forWriters || !worker.ImWriter && !forWriters)
                    worker.Resume();
        }
    }
}
