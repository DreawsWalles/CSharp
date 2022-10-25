using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TaskManager
{
    //Планировщик потоков
    class ThreadManager
    {
        TextBox Log; //лог
        TextBox Queue; //показ очереди
        TextBox tbBlocked; //показ заблокированных

        Random r;
        int time;
        ThreadHandle currentThread;
        Thread scheduler;
        ManualResetEvent resetEvent = new ManualResetEvent(false); //для приостановки извне
        bool stopped = false; //признак остановки

        SortedSet<ThreadHandle> threads; //пул потоков. Используется SortedSet для упрощения выделения потока с наименьшим оставшимся временем выполнения
        List<ThreadHandle> blocked; //заблокированные потоки

        /// <summary>
        /// Инициализирует объект TaskManager начальными значениями
        /// </summary>
        /// <param name="tbLog">TextBox, в который выводится лог</param>
        /// <param name="tbQueue">TextBox, в который выводится текущий набор потоков</param>
        /// <param name="time">Квант времени, который выдаётся потоку</param>
        public ThreadManager(TextBox tbLog, TextBox tbQueue, TextBox Blocked, int time)
        {
            Log = tbLog;
            Queue = tbQueue;
            tbBlocked = Blocked;
            this.time = time;
            ThreadHandle.QuantumLength = time;
            threads = new SortedSet<ThreadHandle>(new ComparerByWork());
            blocked = new List<ThreadHandle>();
            r = new Random();

            scheduler = new Thread(new ThreadStart(threadScheduler));
            scheduler.IsBackground = true;
        }        

        /// <summary>
        /// Запуск таскменеджера
        /// </summary>
        public void Start()
        {
            resetEvent.Set();
            scheduler.Start();
        }

        /// <summary>
        /// Остановка таскменеджера
        /// </summary>
        public void Stop()
        {
            stopped = true;
            resetEvent.Set();
        }

        /// <summary>
        /// Возобновление таксменеджера
        /// </summary>
        public void Resume()
        {
            resetEvent.Set();
        }

        /// <summary>
        /// Приостановка таскменеджера
        /// </summary>
        public void Pause()
        {
            resetEvent.Reset();  
        }

        /// <summary>
        /// Метод для потока
        /// </summary>
        void threadScheduler()
        {
            while (!stopped) //пока не остановлен
            {
                resetEvent.WaitOne(); //для внешней приостановки
                if (r.Next(0, 100) % 5 == 0)
                {
                    ThreadHandle th = new ThreadHandle(r.Next(1, 5) * ThreadHandle.QuantumLength);
                    th.UnexpectedEndOrBlocking += PrematureEndingHandler;
                    Log.Invoke(new Action<string>((str) => Log.AppendText(str)), "Поток " + th.ThreadName + " создан. Работы: " + th.RemainingWork + Environment.NewLine);
                    threads.Add(th);
                }

                if (blocked.Count > 0)
                {
                    tbBlocked.Invoke(new Action(() => tbBlocked.Clear()));
                    string threadsStr = "";
                    ThreadHandle th;
                    for (int i = 0; i < blocked.Count;)
                    {
                        th = blocked[i];
                        if (blocked[i].Blocked == false)
                        {
                            blocked.RemoveAt(i);
                            threads.Add(th);
                        }
                        else
                        {
                            ++i;
                            threadsStr += th.ThreadName + "(" + th.RemainingWork + ")" + " - ";
                        }
                    }
                    tbBlocked.Invoke(new Action<string>((s) => tbBlocked.Text = s), threadsStr);
                }

                if (threads.Count > 0) //если в списке потоков что-то есть
                {
                    Queue.Invoke(new Action(() => Queue.Clear()));
                    string threadsStr = "";
                    foreach (ThreadHandle t in threads)
                    {
                       threadsStr += t.ThreadName + "(" + t.RemainingWork + ")" + " - ";
                    }
                    Queue.Invoke(new Action<string>((s) => Queue.Text = s), threadsStr);

                    Thread.Sleep(1000);

                    GetThread(threads.First());
                    Log.Invoke(new Action<string>((str) => Log.AppendText(str)), Environment.NewLine + "Поток " + currentThread.ThreadName + " выполняется. Осталось работы: " + currentThread.RemainingWork + Environment.NewLine);

                    //ожидание завершения работы текущего потока                           
                    try
                    {
                        currentThread.Resume();
                        Thread.Sleep(ThreadHandle.QuantumLength);
                    }
                    //Если поток завершился досрочно, или заблокирован
                    catch (Exception) { }
                    finally
                    {
                        currentThread.Pause();
                    }
                    //проверка состояния потока
                    //Т.к. ThreadState содержит комбинацию флагов, проверять следует так
                    if ((currentThread.ThreadState & ThreadState.Stopped) != 0)
                        Log.Invoke(new Action<string>((str) => Log.AppendText(str)), "Поток " + currentThread.ThreadName + " завершил работу." + Environment.NewLine);
                    else
                    {
                        if (currentThread.Blocked)
                        {
                            Log.Invoke(new Action<string>((str) => Log.AppendText(str)), "(!) Поток " + currentThread.ThreadName + " заблокирован на " + currentThread.BlockTime + "мс. Осталось работы: " + currentThread.RemainingWork + Environment.NewLine);
                            blocked.Add(currentThread);
                        }
                        else
                        {
                            Log.Invoke(new Action<string>((str) => Log.AppendText(str)), "Поток " + currentThread.ThreadName + " приостановлен. Осталось: " + currentThread.RemainingWork + Environment.NewLine);
                            threads.Add(currentThread);
                        }
                    }

                    Thread.Sleep(1000);
                }

                resetEvent.WaitOne(); //для внешней приостановки     
            }
        }
        
        /// <summary>
        /// Получение очередного потока с наименьшим оставшимся временем выполнения
        /// </summary>
        /// <param name="th"></param>
        void GetThread(ThreadHandle th)
        {
            if (th == null)
                throw new ArgumentException();

            threads.Remove(th);
            currentThread = th;
        }

        /// <summary>
        /// Обработка преждевременного завершения текущего процесса
        /// </summary>
        void PrematureEndingHandler()
        {
            scheduler.Interrupt();
        }
    }
}
