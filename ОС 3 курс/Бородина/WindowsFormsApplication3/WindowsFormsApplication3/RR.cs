using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    class RR
    {
        public Random r = new Random();
        static TextBox tbLog;
        // Очередь заданий
        private readonly Queue<Threads> threadQueue;
        // лист заблокированных заданий
        private readonly List<Threads> threadQueue_suspend;

        // квантум по умолчанию
        private int quantum = 100;

        public Thread scheduler = null; //Планировщик
        public Thread _thread = null; //Поток для выполнения задания

        public RR(TextBox _tbLog, int _quantum, int _maxCountTickets)
        {
            threadQueue = new Queue<Threads>();
            threadQueue_suspend = new List<Threads>();
            tbLog = _tbLog;
            quantum = _quantum;
            scheduler = new Thread(new ThreadStart(threadScheduler)); //планировщик
            scheduler.Name = "Round Robbin";
        }

        public int Quantum
        {
            get { return quantum; }
        }

        // Функция запуска планировщика заданий
        public void Start()
        {
            if (scheduler?.ThreadState == ThreadState.Unstarted)
                scheduler.Start();
            else if (scheduler?.ThreadState == ThreadState.Suspended)
                scheduler.Resume();
        }

        // Функция, которая ставит планировщик на паузу
        public void Pause()
        {
            scheduler.Suspend();
        }

        // Функция, которая завершает планировщик
        public void Abort()
        {
            threadQueue.Clear();
            if (scheduler?.ThreadState == ThreadState.Suspended)
                scheduler.Resume();
            scheduler.Abort();
            _thread.Abort();
        }

        /* public void Start() //Запуск
         {
             scheduler.Start();
         }*/

        public void Resume()// Перезапуск
        {
            scheduler.Resume();
        }

        public void Suspend() //Пауза
        {
            scheduler.Suspend();
        }

        //планировщик
        private void threadScheduler()
        {
            FormMain.flag = true;
            // id первого потока
            int threadNumber = 1;

            // Создаем потоки и инициализируем
            while (threadQueue.Count < 3)
            {
                int priority = r.Next(0, 4); // генер. приоритет
                Threads sThread = new Threads(threadNumber, tbLog, priority);
                threadQueue.Enqueue(sThread); // добавляем в очередь
                tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "Создан поток " + "(" + threadNumber + ") " + priority + " -го приоритета" + "\r\n");
                threadNumber++; // выводим сообщение, увел. номер потока
            }


            while (FormMain.flag)
            {

                //Создаем новые задания с заданной вероятностью
                if (new Random().Next(100) <= FormMain.v)
                {
                    int countT = r.Next(3, 10);
                    for (int i = 0; i < countT; i++)
                    {
                        int priority = r.Next(0, 4);
                        Threads sThread = new Threads(threadNumber, tbLog, priority);
                        threadQueue.Enqueue(sThread);
                        tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "Создан поток " + "(" + threadNumber + ") " + priority + " -го приоритета" + "\r\n");
                        threadNumber++;
                    }

                }
                while (threadQueue.Count > 0 || threadQueue_suspend.Count > 0)
                {
                    var thread_tmp = threadQueue.Dequeue(); // достаем очередное задание
                    quantum = quantum * (thread_tmp.priority + 1); // пересчитываем квантум согласно приоритету потока
                    tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "Поток " + thread_tmp.ID + " выполняется. Значение: " + thread_tmp.Count + " приоритет: " + thread_tmp.priority + "\r\n");
                    thread_tmp.Resume();
                    thread_tmp.thread.Join(quantum);
                    thread_tmp.Suspend();
                    //_thread = new Thread(thread_tmp.mainThread);
                    //_thread.Start();
                    //_thread.Join(quantum);
                    //_thread.Abort();

                    /*if (thread_tmp.Count < thread_tmp.VALUE)
                    {
                        tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "Поток " + thread_tmp.ID + " приостановлен. Текущее значение: " + thread_tmp.Count + " Необходимо получить: " + thread_tmp.VALUE + "\r\n");
                        //tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "Поток " + thread_tmp.ID + " завершил работу. Значение: " + thread_tmp.Count + "\r\n");
                        if (thread_tmp.timer > 0)
                        {
                            threadQueue_suspend.Add(thread_tmp);
                            foreach (var item in threadQueue_suspend)
                                if (item != thread_tmp)
                                    thread_tmp.timer--;
                            continue;
                        }
                        else
                            threadQueue.Enqueue(thread_tmp);
                    }

                    if (threadQueue_suspend.Count > 0)
                    {
                        foreach (var item in threadQueue_suspend)
                            item.timer--;

                        Threads task = null;
                        int num = 0;
                        foreach (var item in threadQueue_suspend)
                        {
                            if (item.timer == 0)
                            {
                                task = item;
                                break;
                            }
                            num++;
                        }

                        if (task != null)
                        {
                            threadQueue_suspend.RemoveAt(num);
                            tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "Поток " + task.ID + " выполняется. Значение: " + task.Count + " приоритет: " + task.priority + "\r\n");
                            quantum = quantum * (task.priority + 1);
                            _thread = new Thread(task.mainThread);
                            _thread.Start();
                            _thread.Join(quantum);
                            _thread.Abort();

                            if (task.Count < task.VALUE)
                            {
                                tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "Поток " + task.ID + " приостановлен. Текущее значение: " + task.Count + " Необходимо получить: " + task.VALUE + "\r\n");
                                if (task.timer > 0)
                                    threadQueue_suspend.Add(task);
                                else
                                    threadQueue.Enqueue(task);
                            }*/


                    //Если поток заблокирован
                    if (thread_tmp.state == true)
                    {
                        threadQueue_suspend.Add(thread_tmp);
                        tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "Поток " + thread_tmp.ID + " заблокирован. Значение: " + thread_tmp.Count + "\r\n");
                        break;
                    }
                    else
                    {
                        threadQueue.Enqueue(thread_tmp);
                        if (thread_tmp.Count >= thread_tmp.VALUE)
                        {
                            tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "Поток " + thread_tmp.ID + " завершил работу. Значение: " + thread_tmp.Count + "\r\n");
                            break;
                        }

                        else
                        {
                            tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "Поток " + thread_tmp.ID + " приостановлен. Текущее значение: " + thread_tmp.Count + " Необходимо получить: " + thread_tmp.VALUE + "\r\n");
                            break;
                        }
                    }
                }
                    //Пересчитываем время
                    foreach (var thread_tmp in threadQueue_suspend)
                    {
                        thread_tmp.timer--;

                        // Возвращаем поток в очередь
                        if (thread_tmp.timer == 0)
                        {
                            thread_tmp.state = false;
                            
                            threadQueue.Enqueue(thread_tmp);
                            tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), "Поток " + thread_tmp.ID + " разблокирован. Значение: " + thread_tmp.Count + "\r\n");

                        }

                    }

                    //Удаляем потоки из списка заблокированных
                    threadQueue_suspend.RemoveAll(thr => thr.timer == 0);

                    quantum = 100;
                    Thread.Sleep(300);


                }
            }
        }
    }

    /*
    public static void TaskCompleteEvent(Threads task, TaskStopped taskStopped)
    {
        if (taskStopped == TaskStopped.ReadWriteCommand)
            tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), ("Попытка операции ввода-вывода" + "\r\n"));
        else if (taskStopped == TaskStopped.GetMaxValue)
            tbLog.Invoke(new Action<string>((lb) => tbLog.AppendText(lb)), ("Задание " + task.ID + " завершено" + "\r\n"));
            */


