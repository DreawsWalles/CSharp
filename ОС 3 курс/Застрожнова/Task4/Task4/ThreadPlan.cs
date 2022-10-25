using System;
using System.Threading;
using System.Windows.Forms;

namespace Task4
{
    //класс потока планировщика
    class ThreadPlan
    {
        //текстовое поле для вывода информации о создании потоков и изменении их приоритета
        private TextBox tb;
        //очередь с потоками
        private QueuePriority<ThreadPrior> threadQueue;
        //квант времени
        private int timeslice;
        //кол-во максимальных потоков
        private int maxThreads;
        //поток планировщика
        public Thread thPlan;

        //конструктор
        public ThreadPlan(TextBox tb)
        {
            threadQueue = new QueuePriority<ThreadPrior>();
            this.tb = tb;
            thPlan = new Thread(new ThreadStart(threadPlan));//планировщик
            thPlan.Name = "sch";
        }
        //доступ к макс кол-ву потоков
        public int MaxThreads
        {
            get { return maxThreads; }
            set { maxThreads = value; }
        }
        //доступ к кванту времени
        public int Timeslice
        {
            get { return timeslice; }
            set { timeslice = value; }
        }

        //запускаем поток
        public void Start()
        {
            thPlan.Start();
        }

        // перезапуск, если поток был приостановлен
        public void Resume()
        {
            if(thPlan.ThreadState == ThreadState.WaitSleepJoin || thPlan.ThreadState == ThreadState.Suspended)
                thPlan.Resume();
        }

        //приостанавливаем поток
        public void Suspend()
        {
            if(thPlan.ThreadState == ThreadState.Running || thPlan.ThreadState == ThreadState.WaitSleepJoin)
                thPlan.Suspend();
        }
        //остановка потока
        public void Abort()
        {
            if (thPlan.ThreadState == ThreadState.Running || thPlan.ThreadState == ThreadState.WaitSleepJoin)
                thPlan.Abort();
        }

        //планировщик
        private void threadPlan()
        {
            Random r = new Random(0);
            int threadNumber = 1;
            int iterations = 0;
                        
            while (mainForm.flag)
            {
                iterations++;
                while (threadQueue.Count < maxThreads)
                {
                    ThreadPrior sThread = new ThreadPrior(threadNumber, tb, r.Next(100, 1000), r.Next(0, 5));//создаются потоки
                    threadQueue.Enqueue(sThread);//эти потоки добавляем в очередь
                    tb.Invoke(new Action<string>((lb) => tb.AppendText(lb)), "Создан поток " + threadNumber + " с приоритетом [" + sThread.Priority + "]\r\n");
                    threadNumber++;
                }
                if (threadQueue.Count > 0)
                {
                    var thread = threadQueue.Dequeue();// вытаскиваем поток из очереди

                    Monitor.Enter(thread);//блокируем поток
                    try
                    {
                        int workTime = thread.Worktime;//получаем время работы потока
                        thread.Resume();//запускаем поток
                        if (workTime < timeslice)//сравниваем время работы с квантом времени
                            thread.thread.Join();//блокируем вызывающий поток до завершения потока
                        else
                        {
                            System.Threading.Thread.Sleep(timeslice); 
                            thread.Suspend();//приостанавливаем поток
                        }
                        if (thread.Worktime > 0)
                            threadQueue.Enqueue(thread);//добавляем в очередь
                    }
                    finally
                    {
                        Monitor.Exit(thread);//снимаем блокировку
                    }
                }
               if (iterations % 10 == 0)//часть повышающая приоритеты потоков, лежащих в очереди
               {
                    QueuePriority<ThreadPrior> newQueque = new QueuePriority<ThreadPrior>();
                    while (threadQueue.Count > 0)
                    {
                        var thread = threadQueue.Dequeue();
                        if (thread.thread.ThreadState == ThreadState.Unstarted && thread.Priority > 0)
                        {
                            thread.Priority--;
                            tb.Invoke(new Action<string>((lb) => tb.AppendText(lb)), "Приоритет потока " + thread.thread.Name + " повышен!\r\n");
                        }
                        newQueque.Enqueue(thread);
                    }
                    threadQueue = newQueque;
                }
            }
            }
        }
    }

