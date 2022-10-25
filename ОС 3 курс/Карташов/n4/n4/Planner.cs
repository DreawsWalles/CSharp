using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace n4
{
    class Planner
    {
        private TextBox tb;
        private Queue<SampleThread> thrs, blocked_thrs;
        private int processing_time;
        private int quantum;
        private SampleThread thread;
        private Thread planner_thread;
        public int th_num = 0, curr_th_num = 0;
        public int cnt;
        volatile private bool stopped = false;

        public Planner(TextBox v_tb, int th_start_num, int pt)
        {
            thrs = new Queue<SampleThread>();
            blocked_thrs = new Queue<SampleThread>();
            tb = v_tb;
            processing_time = pt;
            planner_thread = new Thread(new ThreadStart(Run));
            for (int i = 0; i < th_start_num; i++)
            {
                th_num++;
                thrs.Enqueue(new SampleThread(th_num.ToString(), CallbackMethod));
                tb.Invoke(new Action(() => tb.AppendText("Создан поток " + th_num.ToString() + Environment.NewLine)));
            }
            cnt = curr_th_num = th_num;
        }
        public void CallbackMethod()
        {
            try
            {
                planner_thread.Interrupt();
            }
            catch (ThreadInterruptedException)
            {
                planner_thread.Resume();
            }
        }
        public void Start()
        {
            if (planner_thread != null)
                planner_thread.Start();
        }
        public void Stop()
        {
            stopped = true;
            foreach (SampleThread st in thrs)
            {
                st.Stop();
            }
            foreach (SampleThread st in blocked_thrs)
            {
                st.Stop();
            }
            planner_thread.Abort();
            th_num = 0;
            curr_th_num = th_num;
        }
        private void Run()
        {
            lock (this)
            {
                stopped = false;
                bool blocked = false;
                while (!stopped)
                {
                    try
                    {
                        blocked = false;
                        //if (thrs.Count < curr_th_num)
                        if (thrs.Count == 0)
                        {
                            th_num++;
                            thrs.Enqueue(new SampleThread(th_num.ToString(), CallbackMethod));
                            tb.Invoke(new Action(() => tb.AppendText("Создан поток " + th_num.ToString() + Environment.NewLine)));
                        }
                        quantum = processing_time / thrs.Count;
                        thread = thrs.Dequeue();
                        for (int i = 0; i < blocked_thrs.Count; i++)
                        {
                            SampleThread tmp = blocked_thrs.Dequeue();
                            tmp.Timeout--;
                            if (tmp.Timeout <= 0)
                            {
                                tb.Invoke(new Action(() => tb.AppendText("Поток " + tmp.ThreadName + " разблокирован" + Environment.NewLine)));
                                thrs.Enqueue(tmp);
                            }
                            else
                                blocked_thrs.Enqueue(tmp);
                        }
                        thread.Resume();
                        Thread.Sleep(quantum);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        thread.Suspend();
                        if (thread.CurrentCountState < thread.MaxCountNumber)
                            if (!tb.IsDisposed)
                            {
                                tb.Invoke(new Action(() => tb.AppendText("Поток " + thread.ThreadName + " приостановлен. Высчитанное значение: " + thread.CurrentCountState.ToString() + Environment.NewLine + "Требуемое значение: " + thread.MaxCountNumber.ToString() + Environment.NewLine + Environment.NewLine)));
                                blocked_thrs.Enqueue(thread);
                            }
                        /*if (thread.CurrentCountState == thread.MaxCountNumber)
                            if (!tb.IsDisposed)
                            {
                                tb.Invoke(new Action(() => tb.AppendText("Поток " + thread.ThreadName + " завершил работу" + Environment.NewLine)));
                            }
                            */
                    }
                    finally
                    {
                        thread.Suspend();
                        if (!stopped && !blocked)
                        {
                            try
                            {
                                tb.Invoke(new Action(() => tb.AppendText("Поток " + thread.ThreadName + " приостановлен. Высчитанное значение: " + thread.CurrentCountState.ToString() + Environment.NewLine + "Требуемое значение: " + thread.MaxCountNumber.ToString() + Environment.NewLine + Environment.NewLine)));
                                if (thread.MaxCountNumber == thread.CurrentCountState)
                                    tb.Invoke(new Action(() => tb.AppendText("Поток " + thread.ThreadName + " завершил работу" + Environment.NewLine + Environment.NewLine)));
                                else
                                    blocked_thrs.Enqueue(thread);
                            }
                            catch
                            { }
                        }
                    }
                }
            }
        }
    }
}
