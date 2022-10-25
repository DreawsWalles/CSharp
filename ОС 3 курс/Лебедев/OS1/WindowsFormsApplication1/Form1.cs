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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //private Parallel test;
        private int max = 10;
        OwnStack OS;
        Parallel ParWork;
        Thread mainThread;
        bool state;
        //private bool state = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ThreadControl = new Thread(new ThreadStart(test.ControlProcess));
            //ThreadControl.Start();
            OS = new OwnStack(textBox3, textBox2, textBox1);
            ParWork = new Parallel(OS, textBox3, textBox2);
            mainThread = new Thread(new ThreadStart(ParWork.ControlProcess));
            mainThread.Start();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case false:
                    {
                        mainThread.Suspend();
                        ParWork.PauseProcess();
                        button3.Enabled = false;
                        break;
                    }
                case true:
                    {
                        button3.Enabled = true;
                        mainThread.Resume();
                        ParWork.ResumeProcess();
                        break;
                    }
            }
            state = !state;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainThread.Abort();
            ParWork.StopProcess();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            Thread.Sleep(100);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
