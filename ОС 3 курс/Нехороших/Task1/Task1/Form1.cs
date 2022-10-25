using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Task1
{
    public partial class Form1 : Form
    {
        ThreadCreator threadCreator;
        Thread maint;

        public Form1()
        {
            InitializeComponent();
            newstart.Enabled = false;
        }

        private void start_Click(object sender, EventArgs e)
        {
            tbBuff.Clear();
            tboutput.Clear();
            threadCreator = new ThreadCreator(tboutput, tbBuff);
            maint = new Thread(new ThreadStart(threadCreator.Start));
            maint.Start();
            newstart.Enabled = true;
            start.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void newstart_Click(object sender, EventArgs e)
        {
            maint.Abort();
            threadCreator.Stop();
            start.Enabled = true;
            newstart.Enabled = false;
        }
    }
}
