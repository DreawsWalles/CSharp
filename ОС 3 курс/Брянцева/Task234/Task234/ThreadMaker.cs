using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Task234
{
    class ThreadMaker
    {
        private static TextBox _tb;
        private bool _isWriter;
        private bool _pausedWriters = false;
        private bool _pausedReader = false;

        private Writer _writer;
        private Reader _reader;
        private static Thread _threadWriter;
        private static Thread _threadReader;

        public ThreadMaker(TextBox tb) { _tb = tb; }

        public void ControlProcess()
        {
            Random rand = new Random();
            int num = 1;

            while (true)
            {
                if (_pausedWriters)
                    _isWriter = false;
                else
                {
                    if (_pausedReader)
                        _isWriter = true;
                    else  // случайным образом определяем, кого будет создавать: писателя или читателя
                        _isWriter = rand.Next(100) < 50;
                }

                if (_isWriter && !_pausedWriters) // текущий объект - писатель
                {
                    _writer = new Writer(num);
                    StartThread(_writer, ref num);
                }
                else if (!_pausedReader)// текущий объект - читатель
                {
                    _reader = new Reader(num);
                    StartThread(_reader, ref num);
                }

                //num++;
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

        public void PauseReaders()
        {
            _pausedReader = true;
            if ((_threadReader?.ThreadState == ThreadState.Running) || (_threadReader?.ThreadState == ThreadState.WaitSleepJoin))
                _threadReader.Suspend();
        }

        public void ResumeReaders()
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
        private readonly Queue<Reader> _readersWait = new Queue<Reader>();

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

        public void StartThread(Reader reader, ref int num)
        {
            // если буфер не пуст
            if (BufferClass.Count > 0)
            {
                // если нет читателей в очереди
                if (_readersWait.Count == 0)
                {
                    // создаем нового читателя
                    (_threadReader = new Thread(_reader.Read)).Start();
                    num++;
                }
                else // иначе берем первого в очереди читателя и запускаем его
                    (_threadReader = new Thread(_readersWait.Dequeue().Read)).Start();
            }
            else // буфер пуст
            {
                // добавляем читателя в очередь
                _readersWait.Enqueue(_reader);
                AppendToTextBox("Буфер пуст. Читатель " + num + " в очереди." + "\r\n");
                num++;
            }
        }

        #endregion
    }
}
