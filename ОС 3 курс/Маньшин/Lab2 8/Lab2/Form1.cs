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

namespace Lab2
{
    /*Сравнить два каталога по количеству скрытых файлов*/
    public partial class Form1 : Form
    {
        string Path1 = @"F:\Sample1";
        string Path2 = @"F:\Sample2";
        int cnt1, cnt2;

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            textBoxPath1.Text = Path1;
            textBoxPath2.Text = Path2;
            labelFirst.Text = "";
            labelSecond.Text = "";
        }

        public void OnIdle(object sender, EventArgs args)
        {
            buttonCheck.Enabled = Path1 != null && Path2 != null;
        }

        private void buttonFirstDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Path1 = folderBrowserDialog.SelectedPath;
                textBoxPath1.Text = Path1;
            }
        }

        private void buttonSecondDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Path2 = folderBrowserDialog.SelectedPath;
                textBoxPath2.Text = Path2;
            }
        }

        void Finished(ThreadObserver sender)
        {
            cnt1 = sender.Result1;
            cnt2 = sender.Result2;
            labelFirst.Text = cnt1.ToString();
            labelSecond.Text = cnt2.ToString();

            labelResult.Visible = true;
            if (cnt1 > cnt2)
                labelResult.Text = "больше в первой директории.";
            else if (cnt2 > cnt1)
                labelResult.Text = "больше во второй директории.";
            else
                labelResult.Text = "поровну.";
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            cnt1 = -1;
            cnt2 = -1;
            ThreadObserver observer = new ThreadObserver();
            observer.AllFinished += Finished;

            DirectoryHandler dh1 = new DirectoryHandler(Path1),
                             dh2 = new DirectoryHandler(Path2);
            dh1.Finished += observer.Finished1;
            dh2.Finished += observer.Finished2;

            Thread tObserver = new Thread(observer.Observe),
                   t1 = new Thread(dh1.CountHidden),
                   t2 = new Thread(dh2.CountHidden);
            try
            {
                tObserver.Start();
                t1.Start();
                t2.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошишка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
