using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimePlanner
{
    public partial class MainForm : Form
    {
        ThreadPlanner planner;
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = true;
            buttonStart.Enabled = false;

            textBoxInfoThread.Clear();
            planner = new ThreadPlanner(textBoxInfoThread, (int)numThreads.Value, (int)numTime.Value);
            planner.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;

            planner.Stop();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (planner != null)
                planner.Stop();
            Application.Exit();

        }
    }
}
