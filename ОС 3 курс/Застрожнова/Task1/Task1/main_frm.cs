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

namespace Task1
{
    public partial class main_frm : Form
    {
        private bool isR_stopped = false;
        private bool isW_stopped = false;
        private mainThread mainThread;

        public main_frm()
        {
            InitializeComponent();
        }

        private void btnrun_Click(object sender, EventArgs e)
        {
            mainTB.Clear();
            ReaderTB.Clear();
            WriterTB.Clear();
            BufStack Buf = new BufStack(mainTB,13);
            mainThread = new mainThread(int.Parse(buf_size.Text), Buf, ReaderTB, WriterTB);
            btn_Readers.Enabled = btn_Writers.Enabled = btn_mainBuf.Enabled = true;
            btnAbort.Enabled = true;
            btn_Run.Enabled = buf_size.Enabled = false;
        }

        private void txtBoxBuffer_TextChanged(object sender, EventArgs e)
        {
            TextBox TB = sender as TextBox;
            TB.SelectionStart = TB.Text.Length;
            TB.ScrollToCaret();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            mainThread.Abort();
            btn_Readers.Enabled = btn_Writers.Enabled = btn_mainBuf.Enabled = false;
            btn_Run.Enabled = buf_size.Enabled = true;
            btnAbort.Enabled = false;
        }

      

        private void btn_Readers_Click(object sender, EventArgs e)
        {
            if (isR_stopped)
            {
                mainThread.ResumeReaders();
                isR_stopped = false;
            }
            else
            {
                mainThread.StopReaders();
                isR_stopped = true;
            }
        }

       private void btnWriters_Click(object sender, EventArgs e)
        {
            if (isW_stopped)
            {
                mainThread.ResumeWriters();
                isW_stopped = false;
            }
            else
            {
                mainThread.StopWriters();
                isW_stopped = true;
            }
        }

        private void btn_mainBuf_Click(object sender, EventArgs e)
        {
            if (isW_stopped)
            {
                mainThread.Resume();
                btn_Readers.Enabled = btn_Writers.Enabled = true;
                isW_stopped = false;
            }
            else
            {
                mainThread.Stop();
                btn_Readers.Enabled = btn_Writers.Enabled = false;
                isW_stopped = true;
            }
        }
    }
}
