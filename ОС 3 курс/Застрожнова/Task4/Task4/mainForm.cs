using System;
using System.Windows.Forms;

namespace Task4
{
    public partial class mainForm : Form
    {

        ThreadPlan sch = null;
        public static bool flag = true;

        public mainForm()
        {
            InitializeComponent();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            BtnPlay.Enabled = false;
            if (sch == null)
            {
                TB.Clear();
                sch = new ThreadPlan(TB);
                sch.MaxThreads = 5;
                sch.Timeslice = 150;
                sch.Start();
            }
            else
                sch.Resume();
            BtnStop.Enabled = true;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            BtnStop.Enabled = false;
            sch.Suspend();
            BtnPlay.Enabled = true;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            sch.Abort();
        }
    }
}
