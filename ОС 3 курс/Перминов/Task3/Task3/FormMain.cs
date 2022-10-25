using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Task3
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            textBoxOutput.Clear();

            Kernel32Tools tools = new Kernel32Tools();
            
            foreach (ProcessEntry32 processEntry32 in tools.GetProcessList())
            {
                if (processEntry32.cntThreads == numericUpDownThreadsNumber.Value)
                {
                    textBoxOutput.Text += processEntry32.szExeFile + ", ID: " + processEntry32.th32ProcessID + Environment.NewLine;
                    List<ThreadEntry32> threads = tools.GetThreadList(processEntry32).ToList();
                    textBoxOutput.Text += "  Threads ID: ";
                    foreach (ThreadEntry32 thread in threads)
                    {
                        textBoxOutput.Text += thread.th32ThreadID + " ";
                    }
                    textBoxOutput.Text += Environment.NewLine;                 
                }
            }

            if (textBoxOutput.Text == "")
                textBoxOutput.Text += "No proccesses with this number of threds exist";
        }
    }
}

