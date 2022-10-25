using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ThreadsTask_1
{
    class Writer
    {
        private TextBox _txtBox;
        private int _numOfMessages;
        private int _numOfWriter;
        private StackBuffer _stb;
        private Thread _thread;
        
        public Writer(TextBox t, int n,int nw, StackBuffer s)
        {
            _txtBox = t;
            _numOfMessages = n;
            _stb = s;
            _numOfWriter= nw;
            _thread = new Thread(this.Write);
            _thread.Start();
        }

        public void Write()
        {
            Random rand = new Random();
            _txtBox.Invoke(new Action(() => _txtBox.Text += "Писатель_" + _numOfWriter.ToString() + " был  создан"+ "\n"));
               
            while(_numOfMessages>0)
            {
                
                int tmp = rand.Next(4*(_numOfWriter+1));
                _stb.Push(_numOfWriter, tmp.ToString());
                _numOfMessages--;
                Thread.Sleep(rand.Next(300, 1000));
            }
            _txtBox.Invoke(new Action(() =>_txtBox.Text += "Писатель_" + _numOfWriter.ToString() + " был уничтожен"+ "\n"));
        }

        public void Abort()
        {
            _thread.Abort();
        }

        public void Stop()
        {
            if ((_thread.ThreadState == ThreadState.Running) || (_thread.ThreadState == ThreadState.WaitSleepJoin))
                _thread.Suspend();
        }

        public void Resume()
        {
            if (_thread.ThreadState == ThreadState.Suspended)
                _thread.Resume();
        }
    }

}

