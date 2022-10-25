using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_main
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 24, Size.Height - 44);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 24, Size.Height - 44);
        }

        private void btnTaskOne_Click(object sender, EventArgs e)
        {
            Hide();
            TaskOne.FormMain frm = new TaskOne.FormMain();
            frm.ShowDialog();
            Show();
        }

        private void btnTaskTwo_Click(object sender, EventArgs e)
        {
            Hide();
            TaskTwo.FormMain frm = new TaskTwo.FormMain();
            frm.ShowDialog();
            Show();
        }

        private void btnTaskThree_Click(object sender, EventArgs e)
        {
            Hide();
            TaskThree.FormMain frm = new TaskThree.FormMain();
            frm.ShowDialog();
            Show();
        }

        private void btnTaskFour_Click(object sender, EventArgs e)
        {
            Hide();
            TaskFour.FormMain frm = new TaskFour.FormMain();
            frm.ShowDialog();
            Show();
        }
    }
}
