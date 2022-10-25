using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace OS1
{
    public partial class FormMain : Form
    {
        List<WorkingThread> threads;
        bool started = false;

        public FormMain()
        {
            InitializeComponent();
            threads = new List<WorkingThread>();
            Application.Idle += Idle;
            Buffer.InitializeMutex();
            Buffer.InitializeSemaphore();
        }

        void Idle(object sender, EventArgs e)
        {
            threads.RemoveAll(delegate (WorkingThread wt) { return wt.State == ThreadState.Stopped; });
            textBoxQueue.Text = Buffer.BufferToString();
        }

        private void timerWorkerGenerator_Tick(object sender, EventArgs e)
        {
            threads.Add(new WorkingThread(WorkerFactory.GenerateWorker(textBoxReadersLog, textBoxWritersLog)));
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            started = !started;
            if (started)
            {
                timerWorkerGenerator.Start();
                buttonStart.Text = "Stop";
            }
            else
            {
                timerWorkerGenerator.Stop();
                buttonStart.Text = "Start";
            }
        }

        private void FormMain_FormClosed(object sender, FormClosingEventArgs e)
        {
            Buffer.DisposeMutex();
            Buffer.DisposeSemaphore();
            foreach (var t in threads)
                t.Stop();
        }
    }
}
