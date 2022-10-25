using System;
using System.Threading;

namespace OS4
{
    /// <summary>
    /// Перечислимый тип значений приоритета потока
    /// </summary>
    enum ThreadPriority
    {
        Lowest,
        LowMedium,
        Medium,
        HighMedium,
        Highest
    }

    /// <summary>
    /// Событие, вызываемое при окончании работы потока PriorityThread
    /// </summary>
    delegate void ThreadStoppedEvent();

    /// <summary>
    /// Обертка над стандартным потоком, дополнительно включает в себя приоритет для потока
    /// </summary>
    class PriorityThread: IComparable
    {
        //Статический генератор случайных чисел
        private static Random generator;

        /// <summary>
        /// Статический конструктор для инициализации статических членов класса
        /// </summary>
        static PriorityThread()
        {
            generator = new Random(DateTime.Now.Millisecond);
        }

        //Стандартный поток
        private Thread thread;

        //Приоритет потока
        private ThreadPriority priority;

        //Время работы потока, выбирается случайным образом
        private int workTime;

        /// <summary>
        /// Возвращает значение приоритета потока. Свойство только на чтение
        /// </summary>
        public ThreadPriority Priority
        {
            get { return priority; }
        }

        /// <summary>
        /// Возвращает состояние потока. Свойство только на чтение
        /// </summary>
        public ThreadState State
        {
            get { return thread.ThreadState; }
        }

        /// <summary>
        /// Возвращает или задает имя потока
        /// </summary>
        public string Name
        {
            get { return thread.Name; }
            set { thread.Name = value; }
        }

        /// <summary>
        /// Событие, вызываемое в случае окончания работы потока
        /// </summary>
        public event ThreadStoppedEvent ThreadStopped;

        /// <summary>
        /// Конструктор потока с приоритетом
        /// </summary>
        /// <param name="Priority">Приоритет потока</param>
        public PriorityThread(ThreadPriority Priority)
        {
            thread = new Thread(ThreadProcedureWrapper);
            thread.IsBackground = true;
            priority = Priority;
            ThreadStopped = null;
            //Генерируем рандомное время работы потока в миллисекундах
            workTime = generator.Next(1000, 10000);
        }

        /// <summary>
        /// Процедура, исполняемая потоком
        /// </summary>
        private void ThreadProcedure()
        {
            //Процедура имитирует работу потока, заставляя его спать время, равное workTime
            while(workTime > 0)
            {
                Thread.Sleep(workTime >= 500 ? 500 : workTime);
                workTime -= 500;
            }
        }

        /// <summary>
        /// Обертка над процедурой, выполняемой потоком, для выполнения самой процедуры и вызова события о его завершении
        /// </summary>
        private void ThreadProcedureWrapper()
        {
            //Запускаем процедуру
            ThreadProcedure();
            //Вызываем событие о завершении потока
            ThreadStopped?.Invoke();
        }

        /// <summary>
        /// Запускает поток
        /// </summary>
        public void Start()
        {
            thread.Start();
        }

        /// <summary>
        /// Возобновляет приостановленную работу потока
        /// </summary>
        public void Resume()
        {
            thread.Resume();
        }

        /// <summary>
        /// Приостанавливает поток
        /// </summary>
        public void Suspend()
        {
            thread.Suspend();
        }

        /// <summary>
        /// Метод сравнения потоков для реализации интерфейса IComparable
        /// </summary>
        /// <param name="Thread"></param>
        /// <returns></returns>
        public int CompareTo(object Thread)
        {
            PriorityThread temp = (PriorityThread)Thread;
            if (priority > temp.priority)
                return 1;
            if (priority < temp.priority)
                return -1;
            return 0;
        }
    }
} 