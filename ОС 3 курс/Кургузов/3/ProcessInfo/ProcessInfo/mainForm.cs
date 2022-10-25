using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessInfo
{
    public partial class mainForm : Form
    {
        private Snapshot s = null;
        private bool flag = true;
        private Thread thread = null;
        public mainForm()
        {
            InitializeComponent();

            thread = new Thread(() =>
            {
                while (flag)
                {
                    s = new Snapshot();
                    lblCountID.Invoke(new Action(() => lblCountID.Text = s.ID.ToString()));
                    lblCaption.Invoke(new Action(() => lblCaption.Text = s.Caption.ToString()));
                    lblMemorySize.Invoke(new Action(() => lblMemorySize.Text = s.MemorySize.ToString() + " байт"));
                }
            });

            thread.Start();
        }

        private void btnCreateSnapshot_Click(object sender, EventArgs e)
        {
            flag = !flag;
            thread.Suspend();
            if (!flag)
                btnCreateSnapshot.Text = "Продолжить съемку";
            else
            {
                btnCreateSnapshot.Text = "Остановить";
                thread.Resume();
            }              
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            flag = false;
            thread.Abort();
            s = null;
        }
    }
}
