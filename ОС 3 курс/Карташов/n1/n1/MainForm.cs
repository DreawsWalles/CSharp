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

namespace n1
{
    public partial class MainForm : Form
    {
        int max_cap = 10;
        Buffer buff;
        ThreadGenerator thread_gen;
        Thread main_thread;

        public MainForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            buff = new Buffer(BufferTextBox);
            thread_gen = new ThreadGenerator(buff, ReaderTextBox, WritersTextBox);
            main_thread = new Thread(new ThreadStart(thread_gen.Run));
            main_thread.Start();
            StartButton.Enabled = false;
            PauseButton.Enabled = true;
            StopButton.Enabled = true;
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (PauseButton.Text == "Пауза")
            {
                main_thread.Suspend();
                thread_gen.Pause();
                StopButton.Enabled = false;
                PauseButton.Text = "Продолжить";
            }
            else
            {
                main_thread.Resume();
                thread_gen.Resume();
                StopButton.Enabled = true;
                PauseButton.Text = "Пауза";
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            main_thread.Abort();
            thread_gen.Stop();
            StartButton.Enabled = true;
            PauseButton.Enabled = false;
            StopButton.Enabled = false;
            BufferTextBox.Clear();
            WritersTextBox.Clear();
            ReaderTextBox.Clear();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopButton.PerformClick();
        }
    }
}
