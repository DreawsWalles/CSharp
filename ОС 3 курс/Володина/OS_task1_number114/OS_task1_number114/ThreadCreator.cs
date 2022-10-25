using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace OS_task1_number114
{
    public class ThreadCreator
    {
        private static readonly Stack<int> Buffer = new Stack<int>();

        // максимальный размер буфера
        private const int Max = 4;
        // текущий номер объекта
        private static int _num;

        private static readonly object Lock = new object();

        private static TextBox _tb;

        // флажок, показывающий, является ли текущий объект писателем
        private static bool _isWriter = false;

        private static Thread _threadWriter;
        private static Thread _threadReader;

        public ThreadCreator(TextBox tb) { _tb = tb; }

        private static void AppendToTextBox(string value)
        {
            if (_tb.InvokeRequired)
            {
                _tb.Invoke(new Action<string>(AppendToTextBox), value);
                return;
            }
            _tb.AppendText(value);
        }

        private static void Write()
        {
            lock (Lock)
            {
                if (Buffer.Count < Max)
                {
                    int temp = new Random().Next(100);
                    Buffer.Push(temp);
                    AppendToTextBox(@"Писатель " + _num + @" положил число " + temp + "\r\n");
                    Thread.Sleep(150);
                    _threadWriter.Abort();
                }
                else
                {
                    //AppendToTextBox(@"Писатель " + _num + @": Буфер полностью заполнен." + "\r\n");
                    _num = 0;
                }
            }
        }

        private static void Read()
        {
            lock (Lock)
            {
                if (Buffer.Count > 0)
                {
                    int temp = Buffer.Pop();
                    AppendToTextBox(@"Читатель " + _num + @" забрал число " + temp + "\r\n");
                    Thread.Sleep(150);
                    _threadReader.Abort();
                }
                else
                {
                    //AppendToTextBox(@"Читатель " + _num + @": Буфер пуст." + "\r\n");
                    _num = 0;
                }
            }
        }

        /*private static void DoWork()
        {
            int i = 0;
            bool canWork;
            string name, action;
            if (_isWriter)
            {
                canWork = Buffer.Count < Max;
                name = "Писатель ";
                action = " положил число ";
            }
            else
            {
                canWork = Buffer.Count > 0;
                name = "Читатель ";
                action = " забрал число ";
            }

            lock (Lock)
            {
                if (canWork)
                {
                    int temp;

                    if (_isWriter)
                    {
                        temp = new Random().Next(100);
                        Buffer.Push(temp);
                    }
                    else
                        temp = Buffer.Pop();

                    AppendToTextBox(name + _num + action + temp + "\r\n");
                    Thread.Sleep(150);
                }
            }
        }*/

        public void ControlProcess()
        {
            Random rand = new Random();
            _num = 0;
            while (true)
            {
                _isWriter = rand.Next(100) < 50;

                if (_isWriter)
                    (_threadWriter = new Thread(Write)).Start();
                else
                    (_threadReader = new Thread(Read)).Start();

                _num++;
                Thread.Sleep(rand.Next(900, 1900));
            }
        }

        public void PauseProcess()
        {
            if ((_threadWriter?.ThreadState == ThreadState.Running) || (_threadWriter?.ThreadState == ThreadState.WaitSleepJoin))
                _threadWriter.Suspend();
            if ((_threadReader?.ThreadState == ThreadState.Running) || (_threadReader?.ThreadState == ThreadState.WaitSleepJoin))
                _threadReader.Suspend();
        }

        public void StopProcess()
        {
            _threadReader?.Abort();
            _threadWriter?.Abort();
            Buffer.Clear();
        }

        public void ResumeProcess()
        {
            if (_threadWriter?.ThreadState == ThreadState.Suspended)
                _threadWriter.Resume();
            if (_threadReader?.ThreadState == ThreadState.Suspended)
                _threadReader.Resume();
        }
    }
}
