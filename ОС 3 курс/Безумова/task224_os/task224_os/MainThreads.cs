using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace task224_os
{
    public abstract class MainThreads
    {
        /// <summary>
        /// Текстовое поле, на которое переносятся сообщения из буфера
        /// </summary>
        protected readonly TextBox MyTextBox;

        /// <summary>
        /// Буфер, в который записываются сообщение и из которого они читаются
        /// </summary>
        protected readonly Queue<int> buf = BufQueue.Buffer;

        protected Thread MyThread;
        protected MainThreads(TextBox myTextBox)
        {
            MyTextBox = myTextBox;
        }

        public virtual void MessageToTextBox(string message)
        {
            AppendToTextBox(message + ": " + Name() + " " + Thread.CurrentThread.Name + '\n');
        }

        public void AppendToTextBox(string value)
        {
            if (MyTextBox.InvokeRequired)
            {
                MyTextBox.Invoke(new Action<string>(AppendToTextBox), value);
                return;
            }
            MyTextBox.AppendText(value);
        }

        public abstract void Work();

        public abstract string Name();
        public bool ImWriter { get; } = false;

        public void Abort()
        {
            Resume();
            MyThread.Abort();
        }

        /// <summary>
        /// Пауза
        /// </summary>
        public void Stop()
        {
            if ((MyThread.ThreadState == ThreadState.Running) || (MyThread.ThreadState == ThreadState.WaitSleepJoin))
                MyThread.Suspend();
        }

        /// <summary>
        /// Возобновление
        /// </summary>
        public void Resume()
        {
            if (MyThread.ThreadState == ThreadState.Suspended)
                MyThread.Resume();
        }
    }
}
