using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace OS_task4_number3
{
    internal class TaskScheduler
    {
        // компонент формы, на который будет напечатана информация обо всех потоках
        private static TextBox _tb;

        // очередь заданий
        private readonly Queue<PlannedTask> _taskQueue;

        // очередь заблокированных заданий
        private readonly List<PlannedTask> _blockedQueue;

        // квант времени, выделяемый каждому заданию
        public static int MinQuantum { get; private set; }

        // поток для исполнения планировщика
        private readonly Thread _scheduler;

        // поток для исполнения текущего задания
        private static Thread _thread;


        // конструктор, инициализирующий основные поля класса
        public TaskScheduler(TextBox tb, int quant) 
        {
            _tb = tb;
            MinQuantum = quant;
            _taskQueue = new Queue<PlannedTask>();
            _blockedQueue = new List<PlannedTask>();
            _scheduler = new Thread(Schedule);
        }

        // Функция печати строкового значения на компонент формы
        public static void AppendToTextBox(string value)
        {
            if (_tb.InvokeRequired)
            {
                _tb.Invoke(new Action<string>(AppendToTextBox), value);
                return;
            }
            _tb.AppendText(value);
        }

        // Функция запуска планировщика заданий
        public void Start()
        {
            if (_scheduler?.ThreadState == ThreadState.Unstarted)
                _scheduler.Start();
            else if (_scheduler?.ThreadState == ThreadState.Suspended)
                _scheduler.Resume();
        }

        // Функция, которая ставит планировщик на паузу
        public void Pause()
        {
            _scheduler.Suspend();
        }

        // Функция, которая завершает планировщик
        public void Abort()
        {
            _taskQueue.Clear();
            if (_scheduler?.ThreadState == ThreadState.Suspended)
                _scheduler.Resume();
            _scheduler.Abort();
            _thread.Abort();
        }

        // Функция распределяет выполнение заданий из очереди в соответствии с типом планирования - простым круговоротом
        private void Schedule()
        {
            // инициализируем очередь заданий
            for (int i = 0; i < 3; i++)
                _taskQueue.Enqueue(new PlannedTask(i));

            // следующие задания будут созданы с данным id
            int id = 3;

            // распределяем выполнение заданий
            while (_taskQueue.Count > 0 || _blockedQueue.Count > 0)
            {
                // с вероятностью менее 15% создаем новое задание
                if (new Random().Next(100) < 15)
                {
                    _taskQueue.Enqueue(new PlannedTask(id));
                    AppendToTextBox("\r\n" + "Создано новое задание с id " + id + "\r\n");
                    _printAllTasks();
                    id++;
                }

                // проверяем, есть ли задания в основной очереди
                if (_taskQueue.Count > 0)
                {
                    var task = _taskQueue.Dequeue();
                    AppendToTextBox("Задание " + task.Id + " выполняется. Значение: " + task.CurrentCount + "\r\n");

                    _thread = new Thread(task.Run);
                    _thread.Start();
                    _thread.Join((task.Priority + 1) * MinQuantum);
                    AppendToTextBox("\r\n" + "Приоритет:  " + (task.Priority) + "\r\n");
                    AppendToTextBox("\r\n" + "Выделенный квант времени " + (task.Priority + 1) * MinQuantum + "\r\n");
                    _thread.Abort();

                    if (task.CurrentCount < task.MaxValue)
                    {
                        AppendToTextBox("Задание " + task.Id + " приостановлено. \nДосчитали до: "
                                        + task.CurrentCount + " Необходимо досчитать до" + task.MaxValue + "\r\n"
                                        + "_____________________________" + "\r\n");
                        if (task.Timer > 0)
                        {
                            // задание было заблокировано, добавляем его в очередь заблокированных
                            foreach (var item in _blockedQueue)
                                item.Tick();
                            _blockedQueue.Add(task);
                            _printAllTasks();
                            //continue;
                        }
                        else
                            _taskQueue.Enqueue(task);
                    } // if (task.CurrentCount < task.MaxValue)
                } // if (_taskQueue.Count > 0)

                // проверяем, есть ли задания в очереди заблокированных
                if (_blockedQueue.Count > 0)
                {
                    foreach (var item in _blockedQueue)
                        item.Tick();

                    // ищем первое задание, время ожидания которого истекло
                    PlannedTask task = null;
                    int num = 0;
                    foreach (var item in _blockedQueue)
                    {
                        if (item.Timer == 0)
                        {
                            task = item;
                            break;
                        }
                        num++;
                    }

                    // если задание найдено
                    if (task != null)
                    {
                        // удаляем задание из очереди заблокированных
                        _blockedQueue.RemoveAt(num);
                        AppendToTextBox("Задание " + task.Id + " выполняется. Значение: " + task.CurrentCount + "\r\n");

                        // запускаем задание
                        _thread = new Thread(task.Run);
                        _thread.Start();
                        _thread.Join((task.Priority + 1) * MinQuantum);
                        AppendToTextBox("\r\n" + "Приоритет:  " + (task.Priority) + "\r\n");
                        AppendToTextBox("\r\n" + "Выделенный квант времени " + (task.Priority + 1) * MinQuantum + "\r\n");
                        _thread.Abort();

                        if (task.CurrentCount < task.MaxValue)
                        {
                            AppendToTextBox("Задание " + task.Id + " приостановлено. Досчитали до: "
                                            + task.CurrentCount + " Необходимо досчитать до" + task.MaxValue + "\r\n"
                                            + "_____________________________" + "\r\n");
                            if (task.Timer > 0)
                                _blockedQueue.Add(task);
                            else
                                _taskQueue.Enqueue(task);
                        }
                    } // if (task != null)
                } // if (_blockedQueue.Count > 0)
                _printAllTasks();

                Thread.Sleep(200);
            } // while
            AppendToTextBox("Работа завершена!");
        }


        // Метод, который вызывается текущим заданием, если оно было заблокировано или если оно завершено
        // Метод будет вызван, когда задание оповещает планировщик о своем завершении или блокировке
        public static void TaskCompleteEvent(PlannedTask task, TaskStopped taskStopped)
        {
            if (taskStopped == TaskStopped.ReadWriteCommand)
                AppendToTextBox("Попытка операции ввода-вывода" + "\r\n");
            else if (taskStopped == TaskStopped.GetMaxValue)
                AppendToTextBox("Задание " + task.Id + " завершено. Досчитали до: "
                    + task.CurrentCount + "\r\n" + "_____________________________" + "\r\n");
        }

        // Вспомогательный метод для печати id всех заданий в текущем порядке очереди
        private void _printAllTasks()
        {
            AppendToTextBox("Текущая очередь заданий: " + "\r\n");
            string s = "";
            foreach (var t in _taskQueue)
                s += t.Id + " ";
            if (s == "")
                AppendToTextBox("пусто" + "\r\n" + "\r\n");
            else
                AppendToTextBox(s + "\r\n" + "\r\n");

            AppendToTextBox("Очередь заблокированных заданий: " + "\r\n");
            s = "";
            foreach (var t in _blockedQueue)
                s += t.Id + "(" + t.Timer + "); ";
            if (s == "")
                AppendToTextBox("пусто" + "\r\n" + "_____________________________" + "\r\n");
            else
                AppendToTextBox(s + "\r\n" + "_____________________________" + "\r\n");
        }
        // заблокированные отправляются в другую очередь
        // заблокированному процессу присваивается время ожидания, пока оно не истекло, запустить процесс нельзя
        // при выборе след задания просматривать очередь заблокированных
        // запускать процесс, если истекло его время ожидания
        // при запуске заблокированного процесса по истечении времени его ожидания, если он опять не досчитал до максимума,
        // кладем его в первую, основную очередь
    }
}
