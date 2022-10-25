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

namespace SnapshotApplication
{
    public partial class MainForm : Form
    {
        private MainThread maintThread;

        public MainForm()
        {
            InitializeComponent();
            OnShowLarge = onShowLarge;
        }

        MainThread.SendInfo OnShowLarge;
        private void onShowLarge(IEnumerable<string> infos) 
        {
            if (textBoxMain.InvokeRequired)
            {
                object[] param = { infos };
                textBoxMain.Invoke(OnShowLarge, param);
                return;
            }

            infos.ToList().ForEach(x => textBoxMain.Text += (x + Environment.NewLine));
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            uint n = uint.Parse(textBox1.Text);
            textBoxMain.Clear();

            maintThread = new MainThread(n);
            maintThread.ShowLarge += OnShowLarge;
            maintThread.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (maintThread.CurrentThread.IsAlive)
                maintThread.CurrentThread.Abort();
        }
    }
}
