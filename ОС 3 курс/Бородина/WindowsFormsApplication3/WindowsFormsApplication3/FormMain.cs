using System;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class FormMain : Form
    {
        RR scheduler = null;
        public static int Quantum;

        //Вероятность
        public static int v;
        public static bool flag = true;

        public FormMain()
        {
            InitializeComponent();
            buttonStop.Enabled = false;
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            v = (int)numericProbability.Value;
            if (scheduler == null)
            {
                textBoxLog.Clear();
                scheduler = new RR(textBoxLog, 100, 0);
            }
            scheduler.Start();
            /*if (scheduler == null)
            {
                textBoxLog.Clear();
                scheduler = new RR(textBoxLog, 100, 0);
                Quantum = 100;
                v = (int)numericProbability.Value;
                scheduler.Start();
            }
            else
            {
                scheduler.Resume();
            }*/
            buttonStop.Enabled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            scheduler?.Pause();
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            flag = false;
            scheduler?.Abort();
            Application.Exit();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            scheduler?.Abort();
            flag = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
