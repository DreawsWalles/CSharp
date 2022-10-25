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

namespace ThreadsTask_1
{
    public partial class Form1 : Form
    {
        private bool _rstopped = false;
        private bool _wrstopped = false;
        private Parallel par;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            StackBuffer bf = new StackBuffer(txtBoxBuffer,13);
            par = new Parallel(40, bf, txtBoxReader, txtBoxWriter);
            btnStopRunReaders.Enabled = true;
            btnStopRunWriters.Enabled = true;
            btnAbort.Enabled = true;
        }

        private void txtBoxBuffer_TextChanged(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            t.SelectionStart = t.Text.Length;
            t.ScrollToCaret();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            par.Abort();
            btnAbort.Enabled = false;
            btnStopRunReaders.Enabled = btnStopRunWriters.Enabled= btn.Enabled = false;
        }

      

        private void btnStopRunReaders_Click(object sender, EventArgs e)
        {
            if (_rstopped)
            {
                par.ResumeReaders();
                _rstopped = false;
            }
            else
            {
                par.StopReaders();
                _rstopped = true;
            }
        }

        private void btnStopRunWriters_Click(object sender, EventArgs e)
        {
            if (_wrstopped)
            {
                par.ResumeWriters();
                _wrstopped = false;
            }
            else
            {
                par.StopWriters();
                _wrstopped = true;
            }
        }
    }
}
