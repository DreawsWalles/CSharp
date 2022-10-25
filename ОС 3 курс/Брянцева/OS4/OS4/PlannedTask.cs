using System;

namespace OS4
{
    // перечисление, отображающее причину прекращения выполнения задания
    internal enum stopTask
    {
        GetMaxValue, //досчитали до максимума
        ReadWriteCommand //вызов операции ввода-вывода
    }

    internal class PlannedTask
    {
        //начальное значение времени ожидания
        private const int initialTime = 2000;
        //значение, на которое будет меняться время ожидания
        private const int incrementTime = 500;
        //значение, до которого должно досчитать задание
        public const int maxValue = 500000; 
        //ID задания
        public int Id { get; }
        //значение до которого досчитали
        public long CurrentCount { get; private set; }
        //квант времени
        public int Quantum { get; private set; }
        //время ожидания заблокированного потока
        public int Timer { get; private set; }
        //делегат, которому передается статический метод планировщика
        //если задание было заблокировано или завершено, оно оповещает об этом планировщик, используя callback
        private delegate void TaskCompleteDelegate(PlannedTask task, stopTask taskStopped);

        //конструктор
        public PlannedTask(int id, int q)
        {
            Id = id;
            Quantum = q;
        }

        //функция, уменьшающая время ожидания
        public void Tick()
        {
            Timer -= incrementTime;
        }

        //запуск задания
        public void Run() 
        {
            bool flagReadWrite = false;
            while (CurrentCount < maxValue && !flagReadWrite) 
            {
                ++CurrentCount;
                //с маленькой вероятностью запускаем операцию ввода-вывода
                flagReadWrite = new Random().Next(1000) > 980;
                if (flagReadWrite)
                {
                    //сообщаем планировщику, что задание было заблокировано операцией ввода-вывода
                    Timer = initialTime;
                    TaskCompleteDelegate eventReadWrite = TaskScheduler.TaskCompleteEvent;
                    eventReadWrite(this, stopTask.ReadWriteCommand);
                    return;
                }
            }
            //сообщаем планировщику, что задание завершено 
            TaskCompleteDelegate eventTaskComlete = TaskScheduler.TaskCompleteEvent;
            eventTaskComlete(this, stopTask.GetMaxValue);
        }
    }
}
