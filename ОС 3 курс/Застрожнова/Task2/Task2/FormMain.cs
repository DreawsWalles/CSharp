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

namespace Task2
{
    public partial class FormMain : Form
    {
        Thread myThread = null;
        Threads threads = null;

        public FormMain()
        {
            InitializeComponent();
        }
        
        private void tbPath1_DoubleClick(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbPath1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void tbPath2_DoubleClick(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbPath2.Text = folderBrowserDialog1.SelectedPath;
            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            if ((tbPath1.Text!="")&&(tbPath2.Text != ""))
            {
                threads = new Threads(tbPath1.Text, tbPath2.Text, lbl,lbl_, _lbl_);
                myThread = new Thread(threads.Start);
                myThread.Start();
                lbl_info.Visible = lbl_abs.Visible = lbl.Visible = lbl_.Visible = _lbl_.Visible = true;
            }

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (threads != null)
                threads.Abort();
        }
    }
}
