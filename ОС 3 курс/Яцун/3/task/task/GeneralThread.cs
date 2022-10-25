using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace task
{
    class GeneralThread
    {
        Thread thread;
        TextBox textBox;
        Label lblProcesses;
        Label lblSize;
        List<PROCESSENTRY32> processes;

        public Thread Thread
        {
            get
            {
                return thread;
            }
        }

        public GeneralThread(TextBox textBox, Label lblProcesses, Label lblSize)
        {
            this.textBox = textBox;
            this.lblProcesses = lblProcesses;
            this.lblSize = lblSize;
            thread = new Thread(new ThreadStart(PerformTask));
        }

        void PerformTask()
        {
            WorkProcesses.GetMaxProcesses();

            PrintToTextBox();
            PrintToLables();
        }

        string ProcessesToString()
        {
            StringBuilder result = new StringBuilder();
            processes = WorkProcesses.maxProcesses;

            foreach (PROCESSENTRY32 pr in processes)
            {
                result.Append(pr).Append(Environment.NewLine)
                    .Append("---------------------------")
                    .Append(Environment.NewLine);
            }

            return result.ToString();
        }

        void PrintToTextBox()
        {
            string result = ProcessesToString();

            if (textBox.InvokeRequired)
                textBox.Invoke(new Action<string>((s) => textBox.AppendText(s)), result);
            else
                textBox.AppendText(result);
        }

        private void PrintToLables()
        {
            int amount = processes.Count;
            if (lblProcesses.InvokeRequired)
                lblProcesses.Invoke(new Action<int>((s) => lblProcesses.Text += s), amount);
            else
                lblProcesses.Text += amount;

            uint size = WorkProcesses.maxSize;
            if (lblSize.InvokeRequired)
                lblSize.Invoke(new Action<uint>((s) => lblSize.Text += s), size);
            else
                lblSize.Text += size;
        }
    }
}
