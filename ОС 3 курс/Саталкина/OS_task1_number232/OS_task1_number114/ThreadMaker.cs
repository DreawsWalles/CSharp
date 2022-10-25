using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace OS_task1_number232
{
    class ThreadMaker
    {
        private static TextBox _tb;
        private bool _pausedWriters = false;
        private bool _pausedReader = false;

        private Writer _writer;
        private Reader _reader;
        private static Thread _threadWriter;
        private static Thread _threadReader;

        public ThreadMaker(TextBox tb) { _tb = tb; _reader = new Reader(); }

        public void ControlProcess()
        {
            Random rand = new Random();
            int num = 1;

            while (true)
            {
                int x = rand.Next(100);
                if (!_pausedWriters)
                {
                    if (x < 80)
                    _writer = new Writer(num);
                    StartThread(_writer, ref num);
                }
                if (!_pausedReader)
                {
                    if (x > 40)
                        ReadThread(_reader);
                }

                Thread.Sleep(rand.Next(900, 1900));
            }
        }

        public void StopProcess()
        {
            _threadReader?.Abort();
            _threadWriter?.Abort();
            BufferClass.Buffer.Clear();
        }

        public void PauseWriters()
        {
            _pausedWriters = true;
            if ((_threadWriter?.ThreadState == ThreadState.Running) || (_threadWriter?.ThreadState == ThreadState.WaitSleepJoin))
                _threadWriter.Suspend();
        }

        public void ResumeWriters()
        {
            _pausedWriters = false;
            if (_threadWriter?.ThreadState == ThreadState.Suspended)
                _threadWriter.Resume();
        }

        public void PauseReader()
        {
            _pausedReader = true;
            if ((_threadReader?.ThreadState == ThreadState.Running) || (_threadReader?.ThreadState == ThreadState.WaitSleepJoin))
                _threadReader.Suspend();
        }

        public void ResumeReader()
        {
            _pausedReader = false;
            if (_threadReader?.ThreadState == ThreadState.Suspended)
                _threadReader.Resume();
        }

        public static void AppendToTextBox(string value)
        {
            if (_tb.InvokeRequired)
            {
                _tb.Invoke(new Action<string>(AppendToTextBox), value);
                return;
            }
            _tb.AppendText(value);
        }

        #region 

        private readonly Queue<Writer> _writersWait = new Queue<Writer>();

        public void StartThread(Writer writer, ref int num)
        {
            // если буфер заполнен не полностью
            if (BufferClass.Count < BufferClass.Max)
            {
                // если нет писателей в очереди
                if (_writersWait.Count == 0)
                {
                    // создаем нового писателя
                    (_threadWriter = new Thread(_writer.Write)).Start();
                    num++;
                }
                else // иначе берем первого в очереди писателя и запускаем его 
                    (_threadWriter = new Thread(_writersWait.Dequeue().Write)).Start();
            }
            else // буфер полностью заполнен
            {
                // добавляем писателя в очередь
                _writersWait.Enqueue(_writer);
                AppendToTextBox("Буфер полностью заполнен. Писатель " + num + " в очереди." + "\r\n");
                num++;
            }
        }

        public void ReadThread(Reader reader)
        {
            // если буфер не пуст
            if (BufferClass.Count > 0)
            {
                (_threadReader = new Thread(_reader.Read)).Start();
            }
            else // буфер пуст
            {
                AppendToTextBox("Буфер пуст. Читатель ожидает." + "\r\n");
            }
        }

        #endregion
    }
}
