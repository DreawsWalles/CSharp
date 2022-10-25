using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace os2
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        
        private void bBrowse1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbDir1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void bBrowse2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbDir2.Text = folderBrowserDialog1.SelectedPath;
            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            if ((tbDir1.Text!="")&&(tbDir2.Text != ""))
            {
                ThreadManager tm = new ThreadManager(tbDir1.Text, tbDir2.Text, labelRes1,labelRes2);
                labelInfo.Visible = true;
            }

        }
    }
}
