using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        ThreadManager tm;
        bool paused = false;

        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Value = 300;
        }

        public void OnIdle(object sender, EventArgs e)
        {
            buttonPauseResume.Enabled = !buttonStart.Enabled;
            buttonStop.Enabled = !buttonStart.Enabled;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            tm = new ThreadManager(textBoxLog, textBoxQueue, textBoxBlocked, (int)numericUpDown1.Value);
            buttonStart.Enabled = false;
            tm.Start();
        }

        private void buttonPauseResume_Click(object sender, EventArgs e)
        {
            if (!paused)
            {
                buttonPauseResume.Text = "Возобновить";
                tm.Pause();
            }
            else
            {
                buttonPauseResume.Text = "Пауза";
                tm.Resume();
            }
            paused = !paused;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            tm.Stop();
            buttonStart.Enabled = true;
        }
    }
}
