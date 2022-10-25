using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace task3
{
    public partial class FormMain : Form
    {
        List<ProcessesThread> procs;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnConditionTask_Click(object sender, EventArgs e)
        {
            MessageBox.Show("15");
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            if (procs == null)
            {
                procs = new List<ProcessesThread>();
                procs = ToolHelp32.GetProcList();
            }
                listBoxResult.DataSource = ToolHelp32.GetTaskResult(procs);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            treeViewProcesses.Nodes.Clear();
            tbCurrentItem.Text = "";
            listBoxResult.DataSource = null;
            listBoxResult.Items.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnShapshot_Click(object sender, EventArgs e)
        {
            procs = new List<ProcessesThread>();
            procs = ToolHelp32.GetProcList();
            ToolHelp32.GetTreeProcesses(ref treeViewProcesses, ref procs);
        }

        private void treeViewProcesses_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            if (node.Level == 0)
                tbCurrentItem.Text = procs[node.Index].Proc.ToString();
            if (node.Level == 1)
                tbCurrentItem.Text = procs[node.Parent.Index].Threads[node.Index].ToString();
        }
    }
}
