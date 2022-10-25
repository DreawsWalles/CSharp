using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Task_4
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            btnStop.Enabled = false;
        }
        DistributedSystem ds;
        private void btnStart_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            btnStop.Enabled = true;
            btnStart.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;
            ds = new DistributedSystem(textBox2, textBox1);
            ds.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ds.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnStop.PerformClick();
        }
    }
}
