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
    public partial class mainForm : Form
    {
        ToolHelp32 th;
        public mainForm()
        {
            InitializeComponent();
            th = new ToolHelp32();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            NumPrior.Enabled = false;
            tbResult.Clear();
            tbAll.Clear();

            Thread AllThrd = new Thread(new ThreadStart(ShowAll));
            AllThrd.Start();
            Thread thrExec  = new Thread(new ThreadStart(ShowPrior));
            thrExec.Start();
        }

        void ShowAll()
        {

            lock (this)
            {
                foreach (ProcessEntry32 process in th.GetProcessList())
                {
                    tbAll.Invoke(new Action(() => tbAll.AppendText(process.ToString() + "\r\n")));
                    foreach (ThreadEntry32 thread in th.GetThreadList(process.th32ProcessID))
                    {
                        tbAll.Invoke(new Action(() => tbAll.AppendText(thread.ToString() + "\r\n")));
                    }
                    tbAll.Invoke(new Action(() => tbAll.AppendText("\r\n\r\n")));
                }
            }
        }

        void ShowPrior()
        {
            int prior = int.Parse(NumPrior.Text);
            int count = 0;

            lock (this)
            {
                foreach (ProcessEntry32 process in th.GetProccessesWithPrior(prior))
                {
                    count++;
                    tbResult.Invoke(new Action(() => tbResult.AppendText(process.ToString() + "\r\n")));
                    foreach (ThreadEntry32 thread in th.GetThreadList(process.th32ProcessID))
                    {
                        if (thread.tpBasePri == prior)
                        {
                            tbResult.Invoke(new Action(() => tbResult.AppendText(thread.ToString() + "\r\n")));
                        }
                    }
                    tbResult.Invoke(new Action(() => tbResult.AppendText("\r\n\r\n")));
                }
            }
            if (count == 0)
          {
                Invoke(new Action( () => MessageBox.Show("Ни одного подходящего процесса не было найдено.", "Приоритет", MessageBoxButtons.OK)));
          }
          else
          {
                Invoke(new Action(() => MessageBox.Show("Количесвто найденных процессов = " + count.ToString(), "Приоритет", MessageBoxButtons.OK)));
           }

           Invoke(new Action(() => btnStart.Enabled = true));
           Invoke(new Action(() => NumPrior.Enabled = true));
        }
    }
}
