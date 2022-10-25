using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading;

namespace ThreadsTask_1
{
    class Reader
    {
        private TextBox _txtBox;
        private int _numOfMessages;
        private int _numOfReader;
        private Thread _thread;
        private StackBuffer _stb;

        public Reader(TextBox t, int n,int nw,StackBuffer s)
        {
            _txtBox = t;
            _numOfMessages = n;
            _stb = s;
            _numOfReader= nw;
            _thread = new Thread(this.Read);
            _thread.Start();
        }

        public void Read()
        {
            Random rand = new Random();
            _txtBox.Invoke(new Action(() => _txtBox.Text += "Читатель_" + _numOfReader.ToString() + " был  создан" + "\n"));

            while (_numOfMessages > 0)
            { 
                if (_stb.Count > 0)
                {
                    string tmp;
                    tmp = _stb.Pop(_numOfReader);
                    _numOfMessages--;
                }
                Thread.Sleep(rand.Next(300, 1000));
            }
            _txtBox.Invoke(new Action(() => _txtBox.Text += "Читатель_" + _numOfReader.ToString() + " был уничтожен" + "\n"));
        }

        public void Abort()
        {
            _thread.Abort();
        }
        public void Stop()
        {
            if ((_thread.ThreadState == ThreadState.Running)||(_thread.ThreadState == ThreadState.WaitSleepJoin))
                _thread.Suspend();
        }

        public void Resume()
        {
            if (_thread.ThreadState == ThreadState.Suspended)
                _thread.Resume();
        }
    }
}
