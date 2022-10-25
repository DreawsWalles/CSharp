using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace n4
{
    public partial class MainForm : Form
    {
        Planner planner;
        public MainForm()
        {
            InitializeComponent();
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            ResultTB.Clear();
            planner = new Planner(ResultTB, Convert.ToInt32(ThreadsNum.Value), Convert.ToInt32(TimeNum.Value));
            planner.Start();
            StopButton.Enabled = true;
            StartButton.Enabled = false;
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            planner.Stop();
            StopButton.Enabled = false;
            StartButton.Enabled = true;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (planner != null)
                planner.Stop();
        }
    }
}
