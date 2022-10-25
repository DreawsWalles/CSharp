using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace TimePlanner
{
    /// <summary>
    /// Планировщик потоков. 
    /// Реализована схема: первым выполняется поток с наименьшим оставшимся временем выполнения работы.
    /// Добавление потоков происходит в сортированный по оставшемуся времени выполнения список.
    /// </summary>
    class ThreadPlanner
    {
        //Текстбокс для отображения
        private TextBox tb;

        //Сортированный по времени выполнения список потоков
        private SortedList threads;
        //Список заблокированных потоков
        private SortedList blocked_threads;
        
        //Основной поток планировщика
        private Thread plan_thread;


        private int wait_time;

        //Количество одновременно работающих потоков
        private int thread_quantity = 0; 

        /// <summary>
        /// Максимальный номер потока
        /// Например, если threadquantity = 2, и потоки 1,2,3,5 завершились,
        /// будут работать потоки 4 и 6, max_thread_number = 6
        /// </summary>
        private int max_thread_number = 0;

        volatile private bool stopped = false;

        //Конструктор планировщика
        public ThreadPlanner(TextBox _tb, int _thread_quantity, int _wait_time)
        {
            threads = new SortedList();
            tb = _tb;
            wait_time = _wait_time;

            //Создаем в самом начале количество потоков _thread_quantity и начинаем работу
            plan_thread = new Thread(new ThreadStart(Run));

            blocked_threads = new SortedList();
            for (int i = 0; i < _thread_quantity; i++)
            {
                thread_quantity++;
                threads.Add(new ThreadWorker(thread_quantity.ToString(), CallBack));
                tb.Invoke(new Action(() => tb.AppendText("||| Создан поток " + thread_quantity.ToString() + " |||" + Environment.NewLine + "Время выполнения: " + threads[thread_quantity - 1].RemainingTime.ToString()
                    + "мс" + Environment.NewLine + Environment.NewLine)));
            }
            max_thread_number = thread_quantity;
        }


        private void CallBack()
        {
            try
            {
                plan_thread.Interrupt();
            }
            catch (ThreadInterruptedException)
            {
                plan_thread.Resume();
            }

        }
        //Запуск потока планировщика
        public void Start()
        {
            if (plan_thread != null)
                plan_thread.Start();
        }

        //Останавливает все потоки, включая планировщик
        public void Stop()
        {
            stopped = true;
            foreach (ThreadWorker st in threads)
            {
                st.Stop();
            }
            plan_thread.Abort();
            //planner_thread.Join();
            thread_quantity = 0;
        }


        /// <summary>
        /// Работа планировщика.
        /// Выполняется, пока он не остановлен. 
        /// </summary>
        private void Run()
        {
            while (!stopped)
            {

                bool blocked = false;
                //Если потоков меньше, чем нужно - создаем новый. 
                if (threads.Count < thread_quantity)
                {
                    max_thread_number++;
                    threads.Add(new ThreadWorker(max_thread_number.ToString(), CallBack));
                    tb.Invoke(new Action(() => tb.AppendText(" ||| Создан поток " + max_thread_number.ToString() + " ||| " + Environment.NewLine +
                        "Время выполнения: " + threads[thread_quantity - 1].RemainingTime.ToString() + "мс" + Environment.NewLine + Environment.NewLine)));
                }
                if (threads.Count > 0)
                {
                    //Достаем поток с минимальным временем выполнения из списка
                    ThreadWorker thread = threads.Remove();

                    Monitor.Enter(thread);
                    try
                    {
                        //Возобновляем работу с ним
                        thread.Resume();

                        //Выбранный из сортированного списка поток работает, пока не закончится выделенное на него время
                        Thread.Sleep(wait_time);
                        for (int i = 0; i < blocked_threads.Count; i++)
                        {
                            if (--blocked_threads[i].BlockedFor <= 0)
                            {
                                tb.Invoke(new Action(() => tb.AppendText("---Поток " + blocked_threads[i].Name + " разблокирован---" + Environment.NewLine)));
                                threads.Add(blocked_threads.RemoveAt(i));
                            }
                        }
                    }
                    catch (ThreadInterruptedException e)
                    {
                        thread.Suspend();
                        if (thread.RemainingTime > 0)
                        {
                            if (!tb.IsDisposed)
                                tb.Invoke(new Action(() => tb.AppendText("---Поток " + thread.Name + 
                                    " заблокирован на " + thread.BlockedFor.ToString() + " итераций.---" + Environment.NewLine)));
                            blocked_threads.Add(thread);
                            blocked = true;
                        }
                    }
                    finally
                    {
                        //Затем либо завершается, либо останавливается
                        if (!blocked)
                        {
                            thread.Suspend();
                            if (thread.ThreadState == ThreadState.Stopped)
                                tb.Invoke(new Action(() => tb.AppendText("Поток " + thread.Name + " завершен. \nПрошло: " + thread.DefaultTime.ToString() + "мс" + Environment.NewLine + Environment.NewLine)));
                            else
                            {
                                tb.Invoke(new Action(() => tb.AppendText("Поток " + thread.Name + " приостановлен. \nОсталось: " + thread.RemainingTime.ToString() + "мс" + Environment.NewLine + Environment.NewLine)));
                                threads.Add(thread);
                            }
                        }

                        Monitor.Exit(thread);
                    }
                }
            }
        }
    }
}
