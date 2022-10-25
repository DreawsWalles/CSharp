using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace threads
{
    public partial class MainForm : Form
    {        
        public delegate void PrintStr(string str);       
        PrintStr PrintOnStatus; 
        MutStack mutStack;        

        public MainForm()
        {
            InitializeComponent();

            mutStack = new MutStack(tbStack);
            PrintOnStatus = new PrintStr(PrintOntbStatus);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            Thread generalThread = new Thread(new ThreadStart(LaunchTask));
            generalThread.Start();
        }

        public void LaunchTask()
        {
            Random r = new Random();
            int count = 1;

            Provider provider = new Provider(mutStack, tbStatus, PrintOnStatus);
            Thread providerThread = new Thread(new ThreadStart(provider.AddProduct));
            providerThread.Start();
                                
            while (true)
            {
                int t = r.Next(500, 2000);
               
                Thread.Sleep(t);
                Consumer consumer = new Consumer(mutStack, count.ToString(), PrintOnStatus, r.Next(1,3));                
                
                count++;                
            }
        }

        void PrintOntbStatus(string str)
        {
            if (tbStatus.InvokeRequired)
            {
                tbStatus.Invoke(new Action<string>((s) => tbStatus.AppendText(s)), str);
            }
            else
            {
                tbStatus.AppendText(str);
            }
        }
    }
}
