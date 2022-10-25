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

namespace n3
{
    public partial class MainForm : Form
    {
        ToolHelp32 th;
        public MainForm()
        {
            InitializeComponent();
            th = new ToolHelp32();
        }

        void GetAllProcesses()
        {
            lock(this)
            {
                Invoke(new Action(() => GetProcessButton.Enabled = StartButton.Enabled = false));
                foreach (ProcessEntry32 pe in th.GetProcessList())
                    ProcessTB.Invoke(new Action(() => ProcessTB.AppendText(pe.ToString() + "Количество модулей: " + 
                        th.GetModuleList(pe.th32ProcessID).Count().ToString() + Environment.NewLine + Environment.NewLine)));
                Invoke(new Action(() => GetProcessButton.Enabled = StartButton.Enabled = true));
            }
        }

        void GetProcWithMods()
        {
            IEnumerable<ProcessEntry32> result = th.GetProcessesWithModsNum(Convert.ToInt32(ProcessNum.Value));
            if (result.Count() == 0)
                ResultTB.Invoke(new Action(() => ResultTB.AppendText("Процесс с заданным количеством модулей не найден")));
            else
            {
                foreach (ProcessEntry32 pe in result)
                    ResultTB.Invoke(new Action(() => ResultTB.AppendText(pe.ToString() + "Количество модулей: " + 
                        th.GetModuleList(pe.th32ProcessID).Count().ToString() + Environment.NewLine + Environment.NewLine)));
            }
            
        }

        private void GetProcessButton_Click(object sender, EventArgs e)
        {
            ProcessTB.Clear();
            Thread get_process_th = new Thread(new ThreadStart(GetAllProcesses));
            get_process_th.Start();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Определить, есть ли процесс с заданным количеством модулей.", "Условие", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ResultTB.Clear();
            ProcessTB.Clear();
            GetProcessButton.PerformClick();
            Thread task_th = new Thread(new ThreadStart(GetProcWithMods));
            task_th.Start();
        }
    }
}
