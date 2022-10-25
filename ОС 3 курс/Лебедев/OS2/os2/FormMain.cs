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
        
        void Secondary()
        {
            Founder f1 = new Founder(tbDir1.Text);
            Founder f2 = new Founder(tbDir2.Text);
            Thread search1 = new Thread(new ThreadStart(f1.countYungFiles));
            Thread search2 = new Thread(new ThreadStart(f2.countYungFiles));
            search1.Start();
            search2.Start();
            search1.Join();
            search2.Join();
            MessageBox.Show("В первой папке: " + f1.getCount() + ", во второй папке: " + f2.getCount());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (tbDir1.Text != "" && tbDir2.Text != "")
            {
                Thread thrd = new Thread(new ThreadStart(Secondary));
                thrd.Name = "Secondary";  
                thrd.Start();
            }
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
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                tbDir2.Text = folderBrowserDialog2.SelectedPath;
            }
        }

      
    }
}
