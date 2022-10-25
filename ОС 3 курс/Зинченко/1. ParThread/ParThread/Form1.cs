using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParThread
{


    public partial class MainForm : Form
    {
        MessageBuffer buffer;
        ThreadController threadController;
        Thread threadForWork;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            buffer = new MessageBuffer(tbMessages, tbReaders, tbWriters);
            threadController = new ThreadController(buffer, tbReaders, tbWriters);
            threadForWork = new Thread(new ThreadStart(threadController.Run));
            threadForWork.Start(); //заускаем поток 
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnPause.Enabled = true;
        }
        


        private void btnStop_Click(object sender, EventArgs e)
        {
            if (threadForWork.ThreadState == ThreadState.Running || threadForWork.ThreadState == ThreadState.WaitSleepJoin)
            threadForWork.Abort();
            threadController.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnPause.Enabled = false;
            tbMessages.Text = "";
            tbReaders.Text = "";
            tbWriters.Text = "";

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnStop.PerformClick();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (btnPause.Text == "Пауза")
            {
                if (threadForWork.ThreadState == ThreadState.Running || threadForWork.ThreadState == ThreadState.WaitSleepJoin)
                    threadForWork.Suspend();
                threadController.Pause();
                btnStop.Enabled = false;
                btnPause.Text = "Продолжить";
            }
            else
            {
                if (threadForWork.ThreadState == ThreadState.Running || threadForWork.ThreadState == ThreadState.WaitSleepJoin)
                    threadForWork.Resume();
                threadController.Resume();
                btnStop.Enabled = true;
                btnPause.Text = "Пауза";
            }

        }
    }
}
