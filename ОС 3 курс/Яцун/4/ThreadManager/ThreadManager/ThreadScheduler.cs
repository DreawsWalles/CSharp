using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ThreadManager
{
    //Планировщик задач
    class ThreadScheduler
    {
        TextBox tbLog;
        TextBox tbQueue;
        TextBox tbBlock;

        int time;
        public Thread scheduler;
        Thread SearchInBlock;
        volatile bool flag = true;
        Queues queues;

        public ThreadScheduler(TextBox tbLog, TextBox tbQueue, TextBox tbBlock, int time)
        {
            this.tbLog = tbLog;
            this.tbQueue = tbQueue;
            this.tbBlock = tbBlock;
            this.time = time;
            queues = new Queues();

            scheduler = new Thread(new ThreadStart(threadScheduler));
            SearchInBlock = new Thread(new ThreadStart(TransferFreeThreads));
            SearchInBlock.Start();
        }        

        public void Start()
        {
            scheduler.Start();
        }

        public void Stop()
        {
            flag = false;
            scheduler.Abort();
            scheduler.Join();          
        }

        public void Resume()
        {
            scheduler.Resume();
        }

        public void Pause()
        {
            scheduler.Suspend();            
        }

        void threadScheduler()
        {
            while (flag) //пока не остановлен
            {
                Random rnd = new Random();
                if (rnd.Next(-5, 100) < 0) //создаем поток с лучайный момент времени
                {
                    PlannedThread sThread = new PlannedThread(time);
                    sThread.eventBlock += eventHandler;
                    queues.Enqueue(sThread);
                }

                if (queues.QueueCount() > 0) //если в исполняемой очереди что-то есть
                {
                    tbQueue.Invoke(new Action<string>((str) => tbQueue.Text = str), queues.QueueToString());
                    tbBlock.Invoke(new Action<string>((str) => tbBlock.Text = str), queues.ListToString());

                    PlannedThread thread = queues.Dequeue(); //достать из этой очереди                    
                    
                    tbLog.Invoke(new Action<string>((str) => tbLog.AppendText(str)), Environment.NewLine + "Поток " + thread.ThreadName + " выполняется. Значение: " + thread.Count + Environment.NewLine);
                                               
                    System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
                    stopWatch.Start();
                    TimeSpan ts = stopWatch.Elapsed;
                    thread.ThreadResume();
                    while(ts.Milliseconds - DateTime.Now.Millisecond <=time && thread.ThreadState != ThreadState.Suspended)
                    {
                        ts = stopWatch.Elapsed;
                    }
                    stopWatch.Stop();

                    if (thread.ThreadState != ThreadState.Stopped)
                        thread.ThreadSuspend();

                    if (thread.ThreadState == ThreadState.Stopped)
                        tbLog.Invoke(new Action<string>((str) => tbLog.AppendText(str)), "xxx Поток " + thread.ThreadName + " завершил работу. Досчитали до: " + thread.Count + Environment.NewLine);
                    else if (thread.ThreadState != ThreadState.Suspended)
                    {
                        tbLog.Invoke(new Action<string>((str) => tbLog.AppendText(str)), "Поток " + thread.ThreadName + " заблокирован на: " + thread.BlockTime + ". Досчитали до: " + thread.Count + " Необходимо досчитать до: " + thread.VALUE + Environment.NewLine);
                    }
                    else if(thread.ThreadState == ThreadState.Suspended)
                    {
                        tbLog.Invoke(new Action<string>((str) => tbLog.AppendText(str)), "Поток " + thread.ThreadName + " приостановлен. Досчитали до: " + thread.Count + " Необходимо досчитать до: " + thread.VALUE + Environment.NewLine);
                        queues.Enqueue(thread); // если еще поток не закончился, полложить в конец исполняемой
                    }                  
                }       
            }
        }

        void TransferFreeThreads()
        {
            while(flag)
            {
                if (queues.ListCount() > 0)
                {
                    PlannedThread thread = queues.TakeFirstFromList();
                    if (thread.ThreadState == ThreadState.Suspended)
                        queues.Enqueue(thread);
                    else
                        queues.AddToList(thread);
                }
            }
        }

        public void eventHandler(PlannedThread varThread)
        {
            Monitor.Enter(varThread.Thread);

            try
            {
                queues.AddToList(varThread);
            }
            finally
            {
                Monitor.Exit(varThread.Thread);
            }
        }
    }
}
