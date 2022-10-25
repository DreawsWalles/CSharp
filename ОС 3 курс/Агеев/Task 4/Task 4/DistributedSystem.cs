using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Threading;

namespace Task_4
{
    /// <summary>
    /// Система, в которой работает алгоритм
    /// </summary>
    class DistributedSystem
    {
        /// <summary>
        /// Координатор
        /// </summary>
        Manager coord;
        /// <summary>
        /// Потоки писаталей
        /// </summary>
        List<Thread> WritersThreads;
        /// <summary>
        /// Писатели
        /// </summary>
        List<Writer> Writers;

        public DistributedSystem(TextBox monitor, TextBox resource)
        {
            Resource.CreateInstance(resource).Clear(); // создаем ресурс
            coord = new Manager(); // создаем координатора
            Thread.Sleep(200);
            Writers = new List<Writer>
            {
                new Writer(monitor, coord.threadID),
                new Writer(monitor, coord.threadID),
                new Writer(monitor, coord.threadID),
                new Writer(monitor, coord.threadID),
                new Writer(monitor, coord.threadID)
            }; // создаем писателей
            WritersThreads = new List<Thread>();
            foreach (var wrtr in Writers)
            {
                WritersThreads.Add(new Thread(wrtr.Work) { Name = "Writer" + wrtr.N });
            } // создаем потоки писателей
        }
        /// <summary>
        /// Запуск системы
        /// </summary>
        public void Start()
        {
            foreach (var t in WritersThreads)
            {
                t.Start();
            }
        }
        /// <summary>
        /// Остановка системы
        /// </summary>
        public void Stop()
        {
            foreach (var t in WritersThreads)
            {
                t.Abort();
            }
            coord.Stop();
        }
    }
}
