using System.Collections.Generic;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ThreadsTask_1
{
    class Parallel
    {
        private Thread _tr;
        private int _numberOfThreads;
        private StackBuffer _stb;
        private List<object> _list;
        private TextBox txtWriter;
        private TextBox txtReader;
        private bool _rsuspend=false;
        private bool _wrsuspend = false;

        public Parallel(int _num, StackBuffer stb,TextBox r,TextBox w)
        {
            txtReader = r;
            txtWriter = w;
            _list = new List<object>();
            _numberOfThreads = _num;
            _stb = stb;
            _tr = new Thread(this.Run);
            _tr.Start();
        }

        private void Run()
        {
            int i = 0;
            int ch;
            Random rand = new Random();
            while (i<_numberOfThreads)
            {
                ch = rand.Next(2);
                switch (ch)
                {
                    case 0:
                        if (!(_wrsuspend))
                            _list.Add(new Writer(txtWriter, 5, i, _stb));
                        break;
                    case 1:
                        if (!(_rsuspend))
                            _list.Add(new Reader(txtReader, 5, i, _stb));
                        break;
                }
                Thread.Sleep(new Random().Next(200,500));
                i++;
            }
        }

        public void Abort()
        {
            _tr.Abort();
            foreach(var tr in _list)
            {
                if (tr is Writer)
                    ((Writer)tr).Abort();
                else
                    ((Reader)tr).Abort();
            }
            _list.Clear();
        }

        public void StopReaders()
        {
            _rsuspend = true;
            foreach (var tr in _list)
              if ((tr is Reader))
                 ((Reader)tr).Stop();   
        }
        public void ResumeReaders()
        {
            foreach (var tr in _list)
                if (tr is Reader)
                    ((Reader)tr).Resume();
            _rsuspend = false;
        }

        public void StopWriters()
        {
            _wrsuspend = true;
            foreach (var tr in _list)
                if ((tr is Writer))
                    ((Writer)tr).Stop();
        }
        public void ResumeWriters()
        {
            foreach (var tr in _list)
                if (tr is Writer)
                    ((Writer)tr).Resume();
            _wrsuspend = false;
        }
        public void Suspend()
        {
            _tr.Suspend();
        }
    }
}
