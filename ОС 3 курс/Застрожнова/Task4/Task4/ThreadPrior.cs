using System;
using System.Threading;
using System.Windows.Forms;

namespace Task4
{
    //класс потоков с приоритетами
    class ThreadPrior : IComparable
    {
        //текстовое поле для вывода инфо о состоянии потока
        private TextBox tb;
        public Thread thread;
        //приоритет потока
        private int priority;
        //время работы
        private int workTime;
        //массив приоритетов(для перевода численного значения приоритета в текстовый, для понимания какой важней)
        private string[] priorityName = new string[] { "Высокий", "Выше среднего", "Средний", "Ниже среднего", "Низкий" };

        // Конструктор
        public ThreadPrior(int threadNumber, TextBox tb, int workTime, int priority)
        {
            this.tb = tb;
            this.workTime = workTime;
            this.priority = priority;
            thread = new Thread(new ThreadStart(mainThread));
            thread.Name = threadNumber.ToString();
        }

        /// <summary>
        /// Возвращает разность приоритетов
        /// 0 - приоритеты одинаковы
        /// > 0 - другой поток имеет меньший приоритет
        /// 0 > - другой поток важнее
        /// </summary>
        public int CompareTo(object obj)
        {
            if (obj is ThreadPrior)
                return (obj as ThreadPrior).priority - this.priority;
            else return -1;
        }

        // Время работы
        public int Worktime
        {
            get { return workTime; }
            set { workTime = value; }
        }

        // Приоритет
        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        // Перезапуск
        public void Resume()
        {
            Monitor.Enter(thread);
            try
            {
                if (thread.ThreadState == ThreadState.Unstarted)
                    thread.Start();
                if (thread.ThreadState != ThreadState.Running)
                    thread.Resume();
            }
            finally
            {
                Monitor.Exit(thread);
            }
        }

        //Приостанавливаем
        public void Suspend()
        {
            Monitor.Enter(thread);
            try
            {
                if (thread.ThreadState != ThreadState.Stopped && thread.ThreadState != ThreadState.Suspended)
                    thread.Suspend();
            }
            finally
            {
                Monitor.Exit(thread);
            }
        }

        //инфо о состоянии потока
        private void mainThread()
        {
            if (tb.InvokeRequired)
                tb.Invoke(new Action<string>((lb) => tb.AppendText(lb)), "Поток " + thread.Name + " [" + priorityName[priority] + "] запущен. Время работы: " + workTime + " ms\r\n");
            while (workTime > 0)
            {
                Thread.Sleep(50);//приостанавливаем работу потока
                workTime = (workTime - 100 > 0) ? workTime - 100 : 0; // если workTime - 100 > 0, то  workTime = workTime - 100, иначе  workTime = 0
                if (workTime > 0)
                {
                    if (tb.InvokeRequired)
                        tb.Invoke(new Action<string>((lb) => tb.AppendText(lb)), "Поток " + thread.Name + " работает. Осталось " + workTime + "\r\n");
                }
                else
                {
                    if (tb.InvokeRequired)
                        tb.Invoke(new Action<string>((lb) => tb.AppendText(lb)), "Поток " + thread.Name + " завершился!\r\n");
                }
            }
        }
    }
}
