using System;
using System.Windows.Forms;

namespace OS_task3_number16
{
    /* Определить, есть ли модули, на которые ссылаются несколько процессов. */

    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void twModules_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            // на нулевом уровне находятся модули
            if (node.Level == 0)
                tbInfo.Text = Founder.GetModuleInfo(node.Index);
            else
            if (node.Level == 1) // на первом уровне находятся процессы, которые ссылаются на модуль
                tbInfo.Text = Founder.GetProcessInfo(node.Parent.Index, node.Index);
        }

        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            Founder.Solve(twModules);
        }
    }
}
