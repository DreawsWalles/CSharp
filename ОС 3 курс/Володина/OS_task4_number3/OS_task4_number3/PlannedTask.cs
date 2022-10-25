using System;

namespace OS_task4_number3
{
    // перечисление, отображающее причину прекращения выполнения задания

    internal enum TaskStopped
    {
        TimeIsOver,  // завершился квант времени
        GetMaxValue, // досчитали до максимума
        ReadWriteCommand // вызов операции ввода-вывода
    }

    internal class PlannedTask
    {
        private static Random random = new Random();

        // начальное значение времени ожидания, которое будет присвоено таймеру при блокировке процесса
        private const int InitialTime = 4000;

        // значение, на которое будет меняться время ожидания
        private const int IncrementTime = 500;

        // ID задания
        public int Id { get; }
        
        /// <summary>
        /// Приоритет
        /// </summary>
        public int Priority { get; }

        // начальное максимальное значение; конечное будет получено путем умножения начального значения на случайное число
        private long _initialMaxValue = 1000000;

        // конечное максимальное значение, досчитав до которого задание завершается
        public long MaxValue { get; } 

        // текущее значение, до которого досчитали
        public long CurrentCount { get; private set; }

        // время ожидания, по истечении которого процесс будет разблокирован
        public int Timer { get; private set; }

        // делегат, которому передается статический метод планировщика
        // если задание было заблокировано или завершено, оно оповещает об этом планировщик, используя callback
        private delegate void TaskCompleteDelegate(PlannedTask task, TaskStopped taskStopped);

        // Конструктор
        public PlannedTask(int id)
        {
            Id = id;
            MaxValue = _initialMaxValue; // * new Random().Next(1, 3);
            // инициализировать случайным числом от 0 до 255 (в процессе выделяется байт)
            Priority = random.Next(256);
        }

        // Счетчик для таймера
        public void Tick()
        {
            Timer -= IncrementTime;
        }

        // Задание: считаем значение, пока не достигнем максимума
        public void Run() 
        {
            bool flagReadWrite = false;
            // пока не досчитали до максимума и пока не нужно прервать выполнение задания
            while (CurrentCount < MaxValue && !flagReadWrite) 
            {
                ++CurrentCount;
                // блокировка задания при операции ввода-вывода
                flagReadWrite = new Random().Next(1000) > 998;
                if (flagReadWrite)
                {
                    // оповещаем планировщик, что задание было заблокировано операцией ввода-вывода
                    Timer = InitialTime;
                    TaskCompleteDelegate eventReadWrite = TaskScheduler.TaskCompleteEvent;
                    eventReadWrite(this, TaskStopped.ReadWriteCommand);
                }
            }
            // оповещаем планировщик, что задание было завершено (досчитали до максимума)
            if (CurrentCount == MaxValue)
            {
                TaskCompleteDelegate eventTaskComlete = TaskScheduler.TaskCompleteEvent;
                eventTaskComlete(this, TaskStopped.GetMaxValue);
            }
        } // Run
    }
}
