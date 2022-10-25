using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewerFiles
{
    public partial class MainForm : Form
    {
        private Finder finder1, finder2;
        private bool firstOpened, secondOpened;
        MainThread mainThread;

        public MainForm()
        {
            InitializeComponent();
            firstOpened = secondOpened = false;
            OnShowOlder = onShowOlder;
        }

        MainThread.GetFiles OnShowOlder;
        private void onShowOlder(IEnumerable<FileInfo> files) 
        {
            if (textBoxResult1.InvokeRequired)
            {
                object[] param = { files };
                textBoxResult1.Invoke(OnShowOlder, param);
                return;
            }

            foreach (FileInfo file in files) {
                textBoxResult1.AppendText(file.Name + "\n");
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            textBoxResult1.Clear();

            if (labelDirectory1.Text.Equals("") ||
                labelDirectory2.Text.Equals(""))
            {
                return;
            }

            finder1 = new Finder(labelDirectory1.Text);
            finder2 = new Finder(labelDirectory2.Text);
            mainThread = new MainThread(finder1, finder2);
            mainThread.ShowOlderFiles += onShowOlder;
            mainThread.StartWork();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mainThread != null && mainThread.CurrentThread.IsAlive)
                mainThread.CurrentThread.Abort();
        }

        private void buttonOpenDirectory1_Click(object sender, EventArgs e)
        {
            labelDirectory1.Text = openFolder();
            checkButton();
        }

        private void buttonOpenDirectory2_Click(object sender, EventArgs e)
        {
            labelDirectory2.Text = openFolder();
            checkButton();
        }

        private string openFolder()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return "";
            }

            return dialog.SelectedPath;
        }

        private void checkButton()
        {
            if (!labelDirectory1.Text.Equals("") &&
                !labelDirectory2.Text.Equals(""))
            {
                buttonSearch.Enabled = true;
            }

        }
    }
}
