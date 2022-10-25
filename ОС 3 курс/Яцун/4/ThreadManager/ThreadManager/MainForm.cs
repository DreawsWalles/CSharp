using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadManager
{
    public partial class MainForm : Form
    {
        static ThreadScheduler scheduler;
        bool pause = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!pause)
            {
                scheduler = new ThreadScheduler(tbLog, tbQueue, tbBlock, (int)nudThreadTime.Value);
                scheduler.Start();
            }
            else
                scheduler.Resume();

            pause = false;
            btnPause.Enabled = true;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            //scheduler.Stop();
            scheduler.Pause();
            pause = true;

            btnPause.Enabled = false;
        }
    }
}
