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

namespace zadacha_2
{
    public partial class FormMain : Form
    {
        private string _firstDir, _secondDir;
        private Founder _founderFirst, _founderSecond;
        private Thread _mainThread;
        public FormMain()
        {
            InitializeComponent();
            MinimumSize = Size;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 20, Size.Height - 45);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel3.Size = new Size((int)(tableLayoutPanel2.Width * 0.5), tableLayoutPanel2.Height);
            tableLayoutPanel4.Size = new Size((int)(tableLayoutPanel2.Width * 0.5), tableLayoutPanel2.Height);
            tableLayoutPanel5.Size = new Size(tableLayoutPanel4.Width, tableLayoutPanel4.Height);
            tableLayoutPanel6.Size = new Size(tableLayoutPanel4.Width, tableLayoutPanel4.Height);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (tbFirstDir.Text != "" && tbSecondDir.Text != "")
            {
                _mainThread = new Thread(Run);
                _mainThread.Start();
                Thread.Sleep(250);
            }
            else
                MessageBox.Show("Пожалуйста, выберите два каталога для работы с файлами.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnFirstDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFirstDir.Text = folderBrowserDialog1.SelectedPath;
                _firstDir = tbFirstDir.Text;

                _founderFirst = new Founder(_firstDir, tbFirstDirFiles);
                _founderFirst.GetDetailInfo();
            }
        }

        private void btnSecondDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbSecondDir.Text = folderBrowserDialog1.SelectedPath;
                _secondDir = tbSecondDir.Text;

                _founderSecond = new Founder(_secondDir, tbSecondDirFiles);
                _founderSecond.GetDetailInfo();
            }
        }

        private void tbFirstDir_DoubleClick(object sender, EventArgs e)
        {
            btnFirstDir_Click(null, null);
        }

        private void tbSecondDir_DoubleClick(object sender, EventArgs e)
        {
            btnSecondDir_Click(null, null);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 20, Size.Height - 45);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel3.Size = new Size((int)(tableLayoutPanel2.Width * 0.5), tableLayoutPanel2.Height);
            tableLayoutPanel4.Size = new Size((int)(tableLayoutPanel2.Width * 0.5), tableLayoutPanel2.Height);
            tableLayoutPanel5.Size = new Size(tableLayoutPanel4.Width, tableLayoutPanel4.Height);
            tableLayoutPanel6.Size = new Size(tableLayoutPanel4.Width, tableLayoutPanel4.Height);
        }
        public void Run()
        {
            Founder f1 = new Founder(_firstDir, tbFirstDirFiles);
            Founder f2 = new Founder(_secondDir, tbSecondDirFiles);
            Thread firstThread = new Thread(f1.ChangeAttributes);
            Thread secondThread = new Thread(f2.ChangeAttributes);
            firstThread.Start();
            secondThread.Start();
            firstThread.Join();
            secondThread.Join();
        }
    }
}
