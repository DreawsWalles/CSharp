using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task
{
    public partial class MainForm : Form
    {
        GeneralThread generalThread;

        public MainForm()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(generalThread.Thread.IsAlive)
            {
                progressBar.Value--;
            }
            else
            {
                timer.Stop();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            generalThread = new GeneralThread(tbProcesses, lblProcesses, lblSize);

            generalThread.Thread.Start();
            timer.Start();
        }
    }
}
