using System;
using System.Windows.Forms;
using System.Threading;

namespace OS4
{
    public partial class FormMain : Form
    {
        delegate void Del();

        Scheduler scheduler;

        private void ThreadEventDelegate(object sender, PriorityThreadStateEventArgs e)
        {
            Del d = () =>
            {
                textBox1.Text += e.Info+ Environment.NewLine;
            };
            if (textBox1.InvokeRequired)
                textBox1.Invoke(d);
        }

        public FormMain()
        {
            InitializeComponent();
            scheduler = new Scheduler();
            scheduler.ThreadResumedEvent += ThreadEventDelegate;
            scheduler.ThreadStartedEvent += ThreadEventDelegate;
            scheduler.ThreadStoppedEvent += ThreadEventDelegate;
            scheduler.ThreadSuspendedEvent += ThreadEventDelegate;
            buttonPause.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (scheduler.SchedulerState == (ThreadState.Unstarted | ThreadState.Background))
                scheduler.Start();
            else
                scheduler.Resume();
            buttonPause.Enabled = true;
            buttonStart.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            scheduler.Suspend();
            buttonPause.Enabled = false;
            buttonStart.Enabled = true;
        }
    }
}
