using System;
using System.Windows.Forms;

namespace WriterAndReaders
{
    public partial class FormMain : Form
    {
        private bool _rstopped;
        private bool _wrstopped;
        private Controller _controller;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            _controller = new Controller(txtBoxReader, txtBoxWriter, txtBoxBuffer);
            btn.Enabled = false;
            btnStopRunReaders.Enabled = btnStopRunWriters.Enabled = btnAbort.Enabled = true;
        }

        private void txtBoxBuffer_TextChanged(object sender, EventArgs e)
        {
            var t = (TextBox) sender;
            t.SelectionStart = t.Text.Length;
            t.ScrollToCaret();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            _controller.Abort();
            btn.Enabled = true;
            btnAbort.Enabled = btnStopRunReaders.Enabled = 
                btnStopRunWriters.Enabled = false;
            txtBoxWriter.Clear();
            txtBoxBuffer.Clear();
            txtBoxReader.Clear();
        }

      

        private void btnStopRunReaders_Click(object sender, EventArgs e)
        {
            if (_rstopped)
            {
                btnStopRunReaders.Text = "Stop Readers";
                _controller.ResumeReaders();
                _rstopped = false;
            }
            else
            {
                btnStopRunReaders.Text = "Run Reders";
                _controller.StopReaders();
                _rstopped = true;
            }
        }

        private void btnStopRunWriters_Click(object sender, EventArgs e)
        {
            if (_wrstopped)
            {
                btnStopRunWriters.Text = "Stop Writer";
                _controller.ResumeWriter();
                _wrstopped = false;
            }
            else
            {
                btnStopRunWriters.Text = "Run Writer";
                _controller.StopWriter();
                _wrstopped = true;
            }
        }
    }
}
