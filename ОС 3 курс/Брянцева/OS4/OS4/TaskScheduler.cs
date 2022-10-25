using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace OS4
{
    internal class TaskScheduler
    {
        //текстбокс для печати информации о заданиях
        private static TextBox _tb;
        //очередь заданий
        private readonly List<PlannedTask> _taskQueue;
        //очередь заблокированных заданий
        private readonly List<PlannedTask> _blockedQueue;
        //максимальный и минимальный квант времени, случайно присваеваемый заданию
        private static int quantMax = 1500;
        private static int quantMin = 500;
        //поток для исполнения планировщика
        private readonly Thread _scheduler;
        // поток для исполнения текущего задания
        private Thread _thread;
        //количество созданных изначально заданий
        private static int taskNum = 4;

        //конструктор
        public TaskScheduler(TextBox tb) 
        {
            _tb = tb;
            _taskQueue = new List<PlannedTask>();
            _blockedQueue = new List<PlannedTask>();
            _scheduler = new Thread(Schedule);
        }

        //функция для вывода на форму текста
        public static void AppendToTextBox(string value)
        {
            if (_tb.InvokeRequired)
            {
                _tb.Invoke(new Action<string>(AppendToTextBox), value);
                return;
            }
            _tb.AppendText(value);
        }

        //запуск планировщика
        public void Start()
        {
            
            if (_scheduler?.ThreadState == ThreadState.Unstarted)
                _scheduler.Start();
            else if (_scheduler?.ThreadState == ThreadState.Suspended)
                _scheduler.Resume();
        }

        //функция, возвращающая текущее состояние потока
        public ThreadState State()
        {
            return _scheduler.ThreadState;
        }

        //поставить поток на паузу
        public void Pause()
        {
            _scheduler.Suspend();
        }

        //прерывание потока
        public void Abort()
        {
            _taskQueue.Clear();
            if (_scheduler?.ThreadState == ThreadState.Suspended)
                _scheduler.Resume();
            _scheduler.Abort();
            _thread.Abort();
        }

        //запускаем планировщик
        private void Schedule()
        {
            int id = 0;
            Random r = new Random();

            //инициализируем очередь заданным количеством заданий
            for (int i = 0; i < taskNum; i++)
            {
                _taskQueue.Add(new PlannedTask(i, r.Next(quantMin, quantMax)));
                id++;
            }

            //пока очереди не пусты, продолжаем работу планировщика
            while (_taskQueue.Count > 0 || _blockedQueue.Count > 0)
            {
                //с некоторой вероятностью создаем новое задание
                if (new Random().Next(100) < 25)
                {
                    _taskQueue.Add(new PlannedTask(id, r.Next(quantMin, quantMax)));
                    AppendToTextBox("\r\n" + "Создано новое задание с id " + id + "\r\n");
                    printAllTasks();
                    id++;
                }

                //если очередь не пуста, достаем из нее новое задание
                if (_taskQueue.Count > 0)
                {
                    int mintime = quantMax; int i = 0; int numMin = 0;
                    //находим задание с минимальным квантом времени
                    while (i < _taskQueue.Count)  
                    {
                        if (_taskQueue[i].Quantum < mintime)
                        {
                            numMin = i;
                            mintime = _taskQueue[i].Quantum;
                        }
                        i++;
                    }

                    //достаем найденное задание из очереди
                    var task = _taskQueue[numMin];
                    _taskQueue.RemoveAt(numMin);

                    AppendToTextBox("Задание " + task.Id + " выполняется. Выделенный квант времени: "
                        + task.Quantum + " Значение: "
                                    + task.CurrentCount + "\r\n");

                    //выполняем его
                    _thread = new Thread(task.Run);
                    _thread.Start();
                    _thread.Join(task.Quantum);
                    _thread.Abort();

                    //если задание не успело досчитать, выводим сообщение об этом
                    if (task.CurrentCount < PlannedTask.maxValue)
                    {
                        AppendToTextBox("Задание " + task.Id + " приостановлено. Досчитали до: "
                                        + task.CurrentCount + " Необходимо досчитать до" + PlannedTask.maxValue + "\r\n"
                                        +  "\r\n");
                        //в случае, если задание было заблокировано, 
                        //добавляем его в очередь заблокированных
                        if (task.Timer > 0)
                        {
                            _blockedQueue.Add(task);
                            foreach (var item in _blockedQueue)
                                if (item != task)
                                    item.Tick();
                            printAllTasks();
                            continue;
                        }
                        //иначе возвращаем его в общую очередь
                        else
                            _taskQueue.Add(task);
                    }
                }

                //если в очереди заблокированных есть задания
                if (_blockedQueue.Count > 0)
                {
                    //уменьшаем значение времени ожидания для каждого
                    foreach (var item in _blockedQueue)
                        item.Tick();

                    PlannedTask task = null;
                    int num = 0;
                    //ищем задания с истекшим временем ожидания
                    foreach (var item in _blockedQueue)
                    {
                        if (item.Timer <= 0)
                        {
                            task = item;
                            break;
                        }
                        num++;
                    }

                    //если задание найдено, достаем его из очереди и выполняем
                    if (task != null)
                    {
                        _blockedQueue.RemoveAt(num);
                        AppendToTextBox("Задание " + task.Id + " выполняется. Выделенный квант времени: " + 
                             task.Quantum + " Значение: "
                                        + task.CurrentCount + "\r\n");

                        _thread = new Thread(task.Run);
                        _thread.Start();
                        _thread.Join(task.Quantum);
                        _thread.Abort();

                        //проверяем, досчитало ли задание
                        if (task.CurrentCount < PlannedTask.maxValue)
                        {
                            AppendToTextBox("Задание " + task.Id + " приостановлено. Досчитали до: "
                                            + task.CurrentCount + " Необходимо досчитать до" + PlannedTask.maxValue + "\r\n"
                                            +  "\r\n");
                            //если задание снова заблокировано, 
                            //возвращаем его в очередь заблокированных
                            if (task.Timer > 0)
                                _blockedQueue.Add(task);
                            //иначе добавляем в очередь заданий
                            else
                                _taskQueue.Add(task);
                        }
                    }
                }
                printAllTasks();

                Thread.Sleep(200);
            }
            AppendToTextBox("Работа завершена!");
            Abort();
        }

        //метод будет вызван, когда задание оповещает планировщик о своем завершении или блокировке
        public static void TaskCompleteEvent(PlannedTask task, stopTask taskStopped)
        {
            if (taskStopped == stopTask.ReadWriteCommand)
                AppendToTextBox("Попытка операции ввода-вывода" + "\r\n");
            else if (taskStopped == stopTask.GetMaxValue)
                AppendToTextBox("Задание " + task.Id + " завершено. Досчитали до: "
                    + task.CurrentCount + "\r\n" +  "\r\n");
        }

        //печать текущего состояния очередей
        private void printAllTasks()
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
                AppendToTextBox("пусто" + "\r\n" + "\r\n");
            else
                AppendToTextBox(s + "\r\n" + "\r\n");
        }
    }
}
