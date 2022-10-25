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

namespace ThreadPriority
{
    public partial class Form1 : Form
    {
        ToolHelp32 th;
        public Form1()
        {
            InitializeComponent();
            th = new ToolHelp32();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            textBoxOrig.Clear();

            Thread AllThrd = new Thread(new ThreadStart(ShowAll));
            AllThrd.Start();

        }

        void ShowAll()
        {

            lock (this)
            {
                textBoxOrig.Invoke(new Action(() => textBoxOrig.AppendText("Все процессы: " + "\r\n\r\n")));
                Invoke(new Action(() => buttonLoad.Enabled = buttonMakeTask.Enabled = false));
                foreach (ProcessEntry32 process in th.GetProcessList())
                {
                    textBoxOrig.Invoke(new Action(() => textBoxOrig.AppendText(process.ToString() +
                        "Максимальный приоритет потоков: " + th.CountMaxPriorityByProcess(process.th32ProcessID).ToString() + "\r\n\r\n")));
                }
                Invoke(new Action(() => buttonLoad.Enabled = buttonMakeTask.Enabled = true));
            }
        }

        private void buttonMakeTask_Click(object sender, EventArgs e)
        {
            textBoxResult.Clear();
            textBoxOrig.Clear();
            buttonLoad.PerformClick();

            Thread thrExec;

            thrExec = new Thread(new ThreadStart(ShowMaxPrior));

            thrExec.Start();

        }

        void ShowMaxPrior()
        {
            Invoke(new Action(() => buttonMakeTask.Enabled = false));
            
            textBoxOrig.Invoke(new Action(() => textBoxResult.AppendText("Процессы, имеющие потоки с большим, чем у этих процессов реальным приоритетом: " + "\r\n\r\n")));

            foreach (ProcessEntry32 process in th.GetProccessesMaxPriorInRange())
            {
                textBoxResult.Invoke(new Action(() => textBoxResult.AppendText(process.ToString())));
                textBoxResult.Invoke(new Action(() => textBoxResult.AppendText("Максимальный приоритет потоков: " + th.CountMaxPriorityByProcess(process.th32ProcessID).ToString() + "\r\n\r\n")));
            }

            Invoke(new Action(() => buttonMakeTask.Enabled = true));
        }


    }
}
