using System;
using System.Threading;

namespace OS4
{
    /// <summary>
    /// Класс аргументов события изменения состояния потока
    /// </summary>
    class PriorityThreadStateEventArgs : EventArgs
    {
        private string info;

        public string Info
        {
            get { return info; }
        }

        public PriorityThreadStateEventArgs(string Info)
        {
            info = Info;
        }
    }

    /// <summary>
    /// Делегат обработчика события изменения состояния потока
    /// </summary>
    /// <param name="sender">Объект, вызвавший событие</param>
    /// <param name="e">Аргументы события</param>
    delegate void ThreadStateEventHandler(object sender, PriorityThreadStateEventArgs e);
    
    /// <summary>
    /// Класс планировщика потоков с приоритетом
    /// </summary>
    class Scheduler
    {
        //Статический генератор случайных чисел
        private static Random Generator = new Random(DateTime.Now.Millisecond);

        //Расчетная единица времени в миллисекундах, от которой в процентном соотношении будут вычисляться 
        //периоды активности потоков
        private const int TimeUnit = 100;

        //Таймаут итерации рабочего потока в миллисекундах
        private const int WorkTimeout = 100;

        //Сумма "приоритетов" всех потоков
        private const int PrioritySum = 10;

        //Поток, в котором выполняется планирование рабочих потоков
        private Thread mainThread;

        //Таймер, осуществляющий исполнение рабочего потока заданное время
        private System.Timers.Timer timer;

        //Очередь с приоритетом из рабочих потоков
        private PriorityQueue<PriorityThread> threads;

        //Очередь с приоритетом из потоков, находящихся в состоянии ожидания
        private PriorityQueue<PriorityThread> temp;

        //Квант времени, выделенный потоку в соотвтествии с его приоритетом
        private int executingTime;

        //Количество сгенерированных потоков - чтобы давать им соотвтетствующие имена
        private int threadsCount;

        /// <summary>
        /// Событие, вызываемое сразу после первого запуска очередного потока
        /// </summary>
        public event ThreadStateEventHandler ThreadStartedEvent;

        /// <summary>
        /// Событие, вызываемое сразу после возобновления очередного потока
        /// </summary>
        public event ThreadStateEventHandler ThreadResumedEvent;

        /// <summary>
        /// Событие, вызываемое при приотановке очередного потока
        /// </summary>
        public event ThreadStateEventHandler ThreadSuspendedEvent;

        /// <summary>
        /// Событие, вызываемое сразу после завершения одного из потоков
        /// </summary>
        public event ThreadStateEventHandler ThreadStoppedEvent;

        //Поле, предназначенное для принудительного окончания работы планировщика извне
        private bool stopScheduling;

        //Очередной поток, взятый из очереди
        private PriorityThread MostForegroundThread;

        /// <summary>
        /// Состояние потока планировщика. Свойство только на чтение
        /// </summary>
        public ThreadState SchedulerState
        {
            get { return mainThread.ThreadState; }
        }

        /// <summary>
        /// Конструктор планировщика потоков
        /// </summary>
        public Scheduler()
        {
            mainThread = new Thread(Scheduling);
            mainThread.IsBackground = true;
            timer = new System.Timers.Timer();
            timer.AutoReset = false;
            //Событие, вызываемое при каждом срабатывании таймера
            timer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) =>
            {
                //В зависимости от того, закончился поток или приостановлен, выдаем соответствующее сообщение
                if (MostForegroundThread?.State == ThreadState.Stopped)
                    ThreadStoppedEvent?.Invoke(this, new PriorityThreadStateEventArgs(MostForegroundThread.Name + " [" + MostForegroundThread.Priority.ToString() + "] закончил работу"));
                else
                {
                    //Если поток не закончился на момент срабатывания таймера, усыпляем его
                    MostForegroundThread.Suspend();
                    //Вызываем событие о приостановлении потока
                    ThreadSuspendedEvent?.Invoke(this, new PriorityThreadStateEventArgs(MostForegroundThread.Name + " [" + MostForegroundThread.Priority.ToString() + "] приостановлен, отработав " + executingTime + " миллисекунд"));
                    //И кладем его в очередь приостановленных потоков
                    temp.Enqueue(MostForegroundThread);
                }
                //Возобновляем поток планировщика
                mainThread.Resume();
            };
            threads = new PriorityQueue<PriorityThread>();
            temp = new PriorityQueue<PriorityThread>();
            stopScheduling = false;
            MostForegroundThread = null;
            executingTime = 0;
            threadsCount = 0;
        }

        /// <summary>
        /// Приостанавливает поток планировщика
        /// </summary>
        public void Suspend()
        {
            timer.Stop();
            mainThread.Suspend();
        }

        /// <summary>
        /// Возобновляет работу потока планировщика
        /// </summary>
        public void Resume()
        {
            mainThread.Resume();
        }

        /// <summary>
        /// Метод создания очередного потока
        /// </summary>
        /// <returns>Возвращает созданный поток</returns>
        private PriorityThread GeneratePriorityThread(string Name)
        {
            //Создаем новый поток
            var thread = new PriorityThread((ThreadPriority)Generator.Next(0, 4));
            //Даем ему имя, переданное в параметре
            thread.Name = Name;
            //Устанавливаем обработчик события завершения потока
            thread.ThreadStopped += () =>
            {
                //В случае завершения потока останавливаем таймер
                //При этом не нужно
                timer.Stop();
            };
            return thread;
        }

        /// <summary>
        /// Метод планирования времени работы потоков, находящихся в workingThreads
        /// </summary>
        private void Scheduling()
        {
            //Пока планирование не прекращено извне
            while(!stopScheduling)
            {
                //Если количество рабочих потоков в очереди равно нулю, переносим потоки из очереди ожиддания в очередь рабочих
                //Естественно, из-за приоритета очередность потоков сохранится
                if (threads.Count == 0)
                    while (temp.Count != 0)
                        threads.Enqueue(temp.Dequeue());
                //Если же все потоки окончили работу, генерируем новые
                if(threads.Count == 0)
                    for (int i = 0; i < 5; ++i)
                        threads.Enqueue(GeneratePriorityThread("Thread" + threadsCount++.ToString()));
                //Берем наиболее приоритетный поток
                MostForegroundThread = threads.Dequeue();
                //Вызываем событие о запуске или возобновлении потока соответственно
                if (MostForegroundThread.State == (ThreadState.Unstarted | ThreadState.Background))
                {
                    MostForegroundThread.Start();
                    ThreadStartedEvent?.Invoke(this, new PriorityThreadStateEventArgs(MostForegroundThread.Name + " [" + MostForegroundThread.Priority.ToString() + "] стартовал"));
                }
                else
                {
                    MostForegroundThread.Resume();
                    ThreadResumedEvent?.Invoke(this, new PriorityThreadStateEventArgs(MostForegroundThread.Name + " [" + MostForegroundThread.Priority.ToString() + "] возобновлен"));
                }
                //Рассчитываем время выполнения потока исходя из его приоритета и времени ожидания
                executingTime = Generator.Next((int)MostForegroundThread.Priority * TimeUnit + 1, ((int)MostForegroundThread.Priority + 1) * TimeUnit);
                //Устанавливаем интервал работы таймера
                timer.Interval = executingTime;
                //Запускаем таймер
                timer.Start();
                //Блокируем поток, пока таймер не остановится и не вызовет метод Resume() для потока планировщика
                mainThread.Suspend();
            }
        }

        /// <summary>
        /// Метод запуска планировщика потоков
        /// </summary>
        public void Start()
        {
            mainThread.Start();
        }

        /// <summary>
        /// Метод принудительного окончания работы планировщика потоков
        /// </summary>
        public void Stop()
        {
            stopScheduling = true;
        }
    }
}
