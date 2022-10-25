using System;

using System.Windows.Forms;

namespace task1
{
    public partial class MainForm : Form
    {
        private bool isR_stopped = false;
        private bool isW_stopped = false;
        private Controller Controller;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnrun_Click(object sender, EventArgs e)
        {
            mainTB.Clear();
            readerTB.Clear();
            writerTB.Clear();
            Buffer Buf = new Buffer(mainTB, 13);
            Controller = new Controller(40, Buf, readerTB, writerTB);
            btnReaders.Enabled = btnWriters.Enabled = btnRun.Enabled = true;
            btnStop.Enabled = true;
           // btnRun.Text = "PAUSE";
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            Controller.Abort();
            btnReaders.Enabled = btnWriters.Enabled = false;
            btnStop.Enabled = false;
            //btnRun.Text = "CONTINUE";
        }



        private void btn_Readers_Click(object sender, EventArgs e)
        {
            if (isR_stopped)
            {
                Controller.ResumeReaders();
                isR_stopped = false;
                btnWriters.Text = btnReaders.Text = "PAUSE";
            }
            else
            {
                Controller.StopReaders();
                isR_stopped = true;
                btnReaders.Text = "CONTINUE";
            }
            
        }

        private void btnWriters_Click(object sender, EventArgs e)
        {
            if (isW_stopped)
            {
                Controller.ResumeWriters();
                isW_stopped = false;
                btnWriters.Text = btnReaders.Text = "PAUSE";
            }
            else
            {
                Controller.StopWriters();
                isW_stopped = true;
                btnWriters.Text = "CONTINUE";
            }
            
        }

        private void btn_mainBuf_Click(object sender, EventArgs e)
        {
            if (isW_stopped)
            {
                Controller.Resume();
                btnReaders.Enabled = btnWriters.Enabled = true;
                isW_stopped = false;
               // btnWriters.Text = btnReaders.Text = "RUN";
            }
            else
            {
                Controller.Stop();
                btnReaders.Enabled = btnWriters.Enabled = false;
                isW_stopped = true;
               // btnWriters.Text = btnReaders.Text = "RUN";
            }
        }
    }
}
