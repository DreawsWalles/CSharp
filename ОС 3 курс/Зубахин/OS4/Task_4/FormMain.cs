using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_4
{
    public partial class FormMain : Form
    {
        LotteryScheduler scheduler = null;
       // public static int maxTime;
        public static int Quantum;
        //Вероятность создания нового процесса
        public static int probability;
        //
        public static bool flag = true;
        public FormMain()
        {
            InitializeComponent();
            buttonStop.Enabled = false;
            numericMaxTicket.Minimum = 20;
        }

        private void buttonTask_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Лотерейный планировщик.", "Task");
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (scheduler == null)
            {
                textBoxLog.Clear();
                scheduler = new LotteryScheduler(textBoxLog, (int)numericQuantum.Value, (int)numericMaxTicket.Value);
                Quantum = (int)numericQuantum.Value;
                probability = (int)numericProbability.Value;
                scheduler.Start();
            }
            else
            {
                scheduler.Resume();
            }
            buttonStop.Enabled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            //flag = false;
            scheduler?.Suspend();
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
    }
}
