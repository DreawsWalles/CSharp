using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Task_3
{
    public partial class FormMain : Form
    {

        List<ModulesProcess> ListModulesProcess = new List<ModulesProcess>();

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            ToolHelp32 tool = new ToolHelp32();
            
            foreach (var processEntry32 in tool.GetProcessList())
            {
                foreach (var moduleEntry32 in tool.GetModuleList(processEntry32.th32ProcessID))
                {
                    bool IsAdd = true; // флаг- добавить модуль
                    int index = 0;
                    foreach (var modulesProcess in ListModulesProcess)
                    {
                        if (modulesProcess.Module.szModule == moduleEntry32.szModule)
                        {
                            index = ListModulesProcess.IndexOf(modulesProcess);
                            IsAdd = false;
                            break;
                        }
                    }
                    if (IsAdd)
                    {
                        List<ProcessEntry32> proc = new List<ProcessEntry32>();
                        proc.Add(processEntry32);
                        ListModulesProcess.Add(new ModulesProcess
                                     {
                                         Module = moduleEntry32,
                                         Processes = new List<ProcessEntry32>(proc)
                                     });
                    }
                    else
                    {
                        bool IsAddProc = true;
                        foreach (var proc in ListModulesProcess[index].Processes)
                        {
                            if (proc.th32ProcessID == processEntry32.th32ProcessID)
                            {
                                IsAddProc = false;
                                break;
                            }
                        }
                        if (IsAddProc)
                        {
                            ListModulesProcess[index].Processes.Add(processEntry32);
                        }
                    }
                }
            }

            ListModulesProcess = ListModulesProcess.OrderByDescending(x => x.Processes.Count).ToList();

            treeViewModules.Nodes.Clear();
            foreach (var modulesProcess in ListModulesProcess)
            {
                TreeNode[] trs = new TreeNode[modulesProcess.Processes.Count];
                int i = 0;
                while (i < modulesProcess.Processes.Count)
                {
                    TreeNode tr = new TreeNode();
                    tr.Text = modulesProcess.Processes[i].szExeFile;
                    if (ListModulesProcess[tr.Index].Processes.Count > 1)
                    {
                        trs[i] = tr;
                    }
                    i++;
                }

                treeViewModules.Nodes.Add(new TreeNode(modulesProcess.Module.szModule, trs));
            }
        }

        private void treeViewModules_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            if (node.Level == 0)
            {
                txtDescription.Text = ListModulesProcess[node.Index].Module.ToString(ListModulesProcess[node.Index].Processes.Count);
            }
            if (node.Level == 1)
            {
                txtDescription.Text = ListModulesProcess[node.Parent.Index].Processes[node.Index].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Определить, есть ли модули, на которые ссылаются несколько процессов", "Task");
        }
    }
}
