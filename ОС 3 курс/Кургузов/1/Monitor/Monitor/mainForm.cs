using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public partial class mainForm : Form
    {
        private Process p = null;

        private bool isStoppedWriters;
        private bool isAborted;
        private bool isStoppedReaders;

        public mainForm()
        {
            InitializeComponent();

            Application.Idle += (sender, e) =>
            {
                if (p != null)
                {
                    pbMaxBufferSize.Maximum = p.BufferSize;
                    pbMaxBufferSize.Minimum = 0;
                    pbMaxBufferSize.Value = p.BufferSize;
                    lblMaxBufferSize.Text = p.BufferSize.ToString();

                    pbBufferSizeCurrent.Minimum = 0;
                    pbBufferSizeCurrent.Maximum = p.BufferSize;

                    if (p.InBufferNow != 0)
                    {
                        pbBufferSizeCurrent.Value = p.InBufferNow;
                        lblPercent.Text = p.InBufferNow.ToString();

                        if (pbMaxBufferSize.Value != 0)
                            pbMaxBufferSize.Value -= p.InBufferNow;

                        lblMaxBufferSize.Text = (p.BufferSize - p.InBufferNow).ToString();
                    }

                    if (p.InBufferNow == 0)
                    {
                        lblPercent.Text = 0.ToString();
                        pbBufferSizeCurrent.Value = 0;
                    }
                }

                if (p == null)
                {
                    pbMaxBufferSize.Maximum = 0;
                    pbMaxBufferSize.Value = 0;

                    pbBufferSizeCurrent.Value = 0;
                    pbBufferSizeCurrent.Maximum = 0;

                    pbBufferSizeCurrent.Minimum = 0;

                    lblMaxBufferSize.Text = 0.ToString();
                    lblPercent.Text = 0.ToString();
                }

                nudActionsNumber.Enabled = nudBufferSize.Enabled = nudThreadsNumber.Enabled = p == null;

                btnStart.Enabled = p != null;
                btnAbort.Enabled = p != null;
                btnStartReader.Enabled = p != null;
                btnStartWriter.Enabled = p != null;
                btnStopReader.Enabled = p != null;
                btnStopWriter.Enabled = p != null;

                btnCreate.Enabled = p == null;
                btnDelete.Enabled = p != null;
            };
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var settings = new Settings();

            settings.TxtWriter = tbWriter;
            settings.TxtReader = tbReader;
            settings.TxtBuffer = tbBuffer;

            settings.ActionsNumber = int.Parse(nudActionsNumber.Text);
            settings.BufferSize = int.Parse(nudBufferSize.Text);
            settings.ThreadsNumder = int.Parse(nudThreadsNumber.Text);

            p = Process.CreateObject(settings);

            settings.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            tbBuffer.Clear();
            tbWriter.Clear();
            tbReader.Clear();
            if (p != null)
            {
                if (!isAborted)
                {
                    p.Dispose();
                    p = null;
                }
            }
            
            pbBufferSizeCurrent.Value = 0;
            pbMaxBufferSize.Value = 0;

            pbBufferSizeCurrent.Maximum = 0;
            pbMaxBufferSize.Maximum = 0;

            lblPercent.Text = 0.ToString();
            lblMaxBufferSize.Text = 0.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (p != null)
                p.Run();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            if (p != null)
            {
                p.Abort();
                isAborted = true;
            }
        }

        private void btnStartWriter_Click(object sender, EventArgs e)
        {
            if (isStoppedWriters && p != null)
            {
                p.ResumeWriters();
                isStoppedWriters = false;
            }                
        }

        private void btnStopWriter_Click(object sender, EventArgs e)
        {
            if (!isStoppedWriters && p != null)
            {
                p.StopWriters();
                isStoppedWriters = true;
            }            
        }

        private void btnStartReader_Click(object sender, EventArgs e)
        {
            if (isStoppedReaders && p != null)
            {
                p.ResumeReaders();
                isStoppedReaders = false;
            }
        }

        private void btnStopReader_Click(object sender, EventArgs e)
        {
            if (!isStoppedReaders && p != null)
            {
                p.StopReaders();
                isStoppedReaders = true;
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnDelete_Click(sender, e);
        }
    }
}
