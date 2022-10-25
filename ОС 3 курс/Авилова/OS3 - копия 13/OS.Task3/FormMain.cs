using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace OS.Task3
{
    public partial class FormMain : Form
    {

        List<ProcessModules> ListProcessModules = new List<ProcessModules>();

        public FormMain()
        {
            InitializeComponent();
        }

        void Secondary()
        {

            ToolHelp32 tool = new ToolHelp32();

            foreach (var processEntry32 in tool.GetProcessList())
            {
                uint maxsize = 0;
                bool added = false;

                foreach (var moduleEntry32 in tool.GetModuleList(processEntry32.th32ProcessID))
                {
                    maxsize += moduleEntry32.modBaseSize;
                    added = true;
                }

                if (added)
                {
                    ListProcessModules.Add(new ProcessModules
                    {
                        Process = processEntry32,
                        sizeModulse = maxsize
                    });
                }
            }    
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(new ThreadStart(Secondary));
            thrd.Start();
            thrd.Join();
            treeViewModules.Nodes.Clear();//очищаем на форме
            txtMax_size.Text = "";
            txtDescription.Text = "";

            foreach (var modulesProcess in ListProcessModules)
            {
                TreeNode[] trs = new TreeNode[1];
                treeViewModules.Nodes.Add(modulesProcess.Process.szExeFile);// печать путь и имя файла, связанного с данным процессом   
            }
        }

        private void treeViewModules_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            txtDescription.Text =ListProcessModules[node.Index].Process.ToString()+"Суммарный размер модулей: "+ListProcessModules[node.Index].sizeModulse.ToString();//вывод сумарного размера на форму
        }

        private void btnFaund_Click(object sender, EventArgs e)
        {
            txtMax_size.Text = "";
            txtDescription.Text = "";
            uint maxSize = 0;
            foreach (var modulesProcess in ListProcessModules)
            {
                if (modulesProcess.sizeModulse > maxSize)
                    maxSize = modulesProcess.sizeModulse;    
            }
            foreach (var modulesProcess in ListProcessModules)
            {
                if (modulesProcess.sizeModulse == maxSize)
                    txtMax_size.Text += modulesProcess.Process.ToString() + "Суммарный размер модулей: " + modulesProcess.sizeModulse.ToString();//вывод сумарного размера на форму
            }
        }
    }
}
