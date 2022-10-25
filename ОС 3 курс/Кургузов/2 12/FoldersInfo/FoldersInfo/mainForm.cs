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

namespace FoldersInfo
{
    public partial class mainForm : Form
    {
        private Counter _c = null;
        private Thread _th = null;
        private string _fPath = string.Empty;
        private string _sPath = string.Empty;

        public mainForm()
        {
            InitializeComponent();

            Application.Idle += (sender, e) =>
            {
                посчитатьToolStripMenuItem.Enabled = _fPath != string.Empty && _sPath != string.Empty;
            };
        }

        private void выбратьПервуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fldDialog = new FolderBrowserDialog())
            {
                if (fldDialog.ShowDialog() == DialogResult.OK)
                {
                    _fPath = fldDialog.SelectedPath;
                    tbFirstFolder.Clear();
                }
                fldDialog.Dispose();
            }
        }

        private void выбратьВторуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fldDialog = new FolderBrowserDialog())
            {
                if (fldDialog.ShowDialog() == DialogResult.OK)
                {
                    _sPath = fldDialog.SelectedPath;
                    tbSecondFolder.Clear();
                }
                fldDialog.Dispose();
            }
        }

        private void посчитатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _c = Counter.CreateObject(tbFirstFolder, tbSecondFolder, _fPath, _sPath);
            _th = new Thread(_c.Start);
            _th.Start();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _c = null;
            _th = null;
            Close();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _c?.Abort();
        }
    }
}
