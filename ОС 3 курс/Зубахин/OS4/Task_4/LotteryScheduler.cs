using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Collections;

namespace Task_4
{
    class LotteryScheduler
    {
        public Random r = new Random();
        private TextBox tbLog;
        private List<LThread> threadQueue; // list-base очередь потоков
        private List<LThread> threadQueue_suspend; // list-base очередь потоков для заблокированных потоков
        private int quantum = 0; // Квант
        //private int countTickets = 0;
        private int maxCountTickets { get; set; } //Макс. кол-во билетов для потока
        public Thread scheduler = null; //Планировщик
        public LThread thread_f = null; //Поток для выполнения задания
        bool stopped;
        int index;

        public LotteryScheduler(TextBox _tbLog, int _quantum, int _maxCountTickets)
        {
            threadQueue = new List<LThread>();
            threadQueue_suspend = new List<LThread>();
            tbLog = _tbLog;
            quantum = _quantum;
            //maxThreads = _maxThreads;
            maxCountTickets = _maxCountTickets;
            scheduler = new Thread(new ThreadStart(threadScheduler)); //планировщик
            scheduler.Name = "Lottery";
        }
        /*
                public int MaxThreads
                {
                    get { return maxThreads; }
                    set { maxThreads = value; }
                }
                */
        public int Quantum
        {
            get { return quantum; }
        }

        public int Timeslice
        {
            get { return quantum; }
            set { quantum = value; }
        }

        public void Start() //Запуск
        {
            scheduler.Start();
        }

        public void Resume()// Перезапуск
        {
            scheduler.Resume();
        }

        public void Suspend() //Пауза
        {
            scheduler.Suspend();
        }

        public void Abort()
        {
            threadQueue.Clear();
            if (scheduler?.ThreadState == ThreadState.Suspended)
                scheduler.Resume();
            scheduler.Abort();
        }

        /// <summary>
        /// Функция -- разыграть выигрышный билет
        /// </summary>
        /// <param name="_cntTick">Количество билетов</param>
        /// <returns></returns>
        private int Lottery(int _cntTick) // Получаем выигрышный билет!
        {
            return r.Next(1, _cntTick);
        }


        public void threadScheduler()
        {
            lock (this)
            {
                stopped = false;
                bool blocked = false;
                int threadNumber = 1;
                int cntTick = 0;
                int win_ticket = 0;
                /* Создаем потоки и инициализируем */
                while (threadQueue.Count < 9)
                {
                    int tickets = Convert.ToInt32(Math.Round(maxCountTickets * r.NextDouble(), MidpointRounding.AwayFromZero));
                    cntTick += tickets;
                    LThread sThread = new LThread(threadNumber, tbLog, tickets, CallBackSuspend);//создаются потоки
                    threadQueue.Add(sThread);//эти потоки добавляем в очередь
                    tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "► Created thread "
                        + "[" + threadNumber + "] " + tickets + " tickets ◄" + "\r\n");
                    threadNumber++;
                }

                while (!stopped)
                {
                    try
                    {
                        blocked = false;
                        //Убавляем таймер у всех заблокированных потоков
                        foreach (var thread_tmp in threadQueue_suspend)
                        {
                            thread_tmp.timer--;
                            //И добавляем в гланую очередь все потоки, которые дождались
                            if (thread_tmp.timer <= 0)
                            {
                                thread_tmp.state = false;
                                threadQueue.Add(thread_tmp);
                                tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "○○○ Thread " + thread_tmp.ID
                                + " Unsuspend. Value: " + thread_tmp.Count + " ○○○\r\n");
                                cntTick += thread_tmp.tickets;
                            }

                        }
                        //Удаляем разблокированные потоки
                        threadQueue_suspend.RemoveAll(x => x.timer <= 0);
                        
                        if (threadQueue.Count < 1)
                        {
                            int countT = r.Next(1, 2);
                            for (int i = 0; i < countT; i++)
                            {
                                int tickets = Convert.ToInt32(Math.Round(maxCountTickets * r.NextDouble(), MidpointRounding.AwayFromZero));
                                cntTick += tickets;
                                LThread sThread = new LThread(threadNumber, tbLog, tickets, CallBackSuspend);//создаются потоки
                                threadQueue.Add(sThread);//эти потоки добавляем в очередь
                                tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "► Created thread "
                                    + "[" + threadNumber + "] " + tickets + " tickets ◄" + "\r\n");
                                threadNumber++;
                            }
                        }

                        if (new Random().Next(100) <= FormMain.probability)
                        {
                            //Создаем от 0 до 6 заданий
                            int countT = r.Next(0, 6);
                            for (int i = 0; i < countT; i++)
                            {
                                int tickets = Convert.ToInt32(Math.Round(maxCountTickets * r.NextDouble(), MidpointRounding.AwayFromZero));
                                cntTick += tickets;
                                LThread sThread = new LThread(threadNumber, tbLog, tickets, CallBackSuspend);//создаются потоки
                                threadQueue.Add(sThread);//эти потоки добавляем в очередь
                                tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "► Created thread "
                                    + "[" + threadNumber + "] " + tickets + " tickets ◄" + "\r\n");
                                threadNumber++;
                            }

                        }

                        // Если билетов 0, то очередь пуста
                        if (cntTick > 0)
                        {
                            win_ticket = Lottery(cntTick);
                        }

                        //Сумма билетов для лотереи
                        int sum_ticket = 0;

                        index = 0;
                        foreach (var thread_tmp in threadQueue)
                        {
                            index++;
                            //Считаем сумму билетов
                            sum_ticket += thread_tmp.tickets;
                            //Если сумма >= выигрышный
                            if (sum_ticket >= win_ticket)
                            {
                                break;
                            }
                        }

                        thread_f = threadQueue[index - 1];
                        threadQueue.RemoveAt(index - 1);
                        cntTick -= thread_f.tickets;
                        tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "Thread " + thread_f.ID + " execution. Value: " + thread_f.Count + " Tickets: " + thread_f.tickets + "\r\n");
                        thread_f.Resume();
                        //thread_f.thread.Join(quantum);
                        Thread.Sleep(quantum);

                    }
                    catch (ThreadInterruptedException ex)
                    {
                        thread_f.Suspend();
                        //Вызван callback, если поток не достчитал, то
                        if (thread_f.GetCount < thread_f.VALUE)
                        {
                            tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "●●● Thread " + thread_f.ID + " blocked. Value: " + thread_f.Count + " ●●●\r\n");
                            blocked = true;
                            threadQueue_suspend.Add(thread_f);
                            threadQueue.Remove(thread_f);
                            if (threadQueue.Count > 0)
                            {
                                int randThread = r.Next(0, threadQueue.Count - 1);
                                threadQueue[randThread].tickets = thread_f.tickets;
                            }
                        }

                    }
                    finally
                    {
                        thread_f.Suspend();
                        if (!blocked&&!stopped)
                        {
                            try
                            {
                                //Если не заблокирован
                                if (!blocked)
                                {
                                    tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "Thread " + thread_f.ID + " value: " + thread_f.Count + " \r\n");
                                    if (thread_f.GetCount == thread_f.VALUE)
                                    {
                                        tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "■ Thread " + thread_f.ID + " completed. ■\r\n");
                                    }
                                    else
                                    {
                                        threadQueue.Insert(index - 1, thread_f);
                                        cntTick += thread_f.tickets;
                                    }
                                }

                            }
                            catch
                            { }
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Метод, для приостановки потока
        /// </summary>
        public void CallBackSuspend()
        {
            try
            {
                scheduler.Interrupt();
            }
            catch (ThreadInterruptedException)
            {
                scheduler.Resume();
            }
        }
    }


    
}
    

