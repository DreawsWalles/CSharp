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

namespace lab1N132
{
    //Поставщик-потребитель. Стек. Монитор. Один читатель, много писателей.
    public partial class Form1 : Form
    {
        Controller c;
        int capacity = 10;
        object obj = new object();

        void ControllerMessageHandler(string msg)
        {
            lock (textBoxLog)
            {
                textBoxLog.AppendText(msg + Environment.NewLine);
            }
        }

        void ControllerStackHandler(bool increase)
        {
            lock (progressBar1)
            {
                if (increase)
                    progressBar1.Increment(1);
                else
                    progressBar1.Increment(-1);
            }
        }

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            progressBar1.Step = 1;
            progressBar1.Maximum = capacity;
            c = new Controller(capacity);
            c.SendMessage += ControllerMessageHandler;
            c.BufferChanged += ControllerStackHandler;
        }

        private void buttonPauseWriters_Click(object sender, EventArgs e)
        {
            if (c.WritersStopped)
            {
                c.WritersStopped = false;
                buttonPauseWriters.Text = "Приостановить писателей";
                return;
            }
            c.WritersStopped = true;
            buttonPauseWriters.Text = "Возобновить писателей";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(c.Run);
            t.IsBackground = true;
            t.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            c.Stop = true;
        }

        private void buttonPauseReaders_Click(object sender, EventArgs e)
        {
            if (c.ReadersStopped)
            {
                c.ReadersStopped = false;
                buttonPauseReaders.Text = "Приостановить читателей";
                return;
            }
            c.ReadersStopped = true;
            buttonPauseReaders.Text = "Возобновить читателей";
        }
    }
}
