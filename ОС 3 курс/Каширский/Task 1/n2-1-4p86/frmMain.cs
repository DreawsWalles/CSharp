using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace n2_1_4p86 {
    public partial class frmMain : Form {
        Buffer buffer;
        ThreadCreator threadCreator;
        int max = 10;
        Thread thrd; //поток, осуществляющий работу

        public frmMain() {
            InitializeComponent();
            btnStop.Enabled = false;
            btnPause.Enabled = false;
        } //public frmMain()

        private void btnStart_Click(object sender, EventArgs e) {
            //Создаем экземпляры буфера и создателя потоков
            buffer = new Buffer (txtbxMessages, txtbxReaders, txtbxWriters);
            threadCreator = new ThreadCreator (buffer, txtbxReaders, txtbxWriters);
            thrd = new Thread(new ThreadStart (threadCreator.Run));
            thrd.Start(); //запускаем поток
             
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnPause.Enabled = true;
        } //private void btnStart_Click

        private void btnPause_Click(object sender, EventArgs e) {
            if (btnPause.Text == "Pause")
            {
                thrd.Suspend();
                threadCreator.Pause();
                btnStop.Enabled = false;
                btnPause.Text = "Continue";
            }
            else
            {
                thrd.Resume();
                threadCreator.Resume();
                btnStop.Enabled = true;
                btnPause.Text = "Pause";
            }
        } //private void btnPause_Click

        private void btnStop_Click(object sender, EventArgs e) {
            thrd.Abort();
            threadCreator.Stop();

            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnPause.Enabled = false;

            txtbxMessages.Text = "";
            txtbxReaders.Text = "";
            txtbxWriters.Text = "";
        } //private void btnStop_Click

        private void btnHelp_Click(object sender, EventArgs e) {
            string help = "Создать многопоточное приложение, в котором главный поток в случайные моменты порождает либо поток-читатель, который в случайные моменты времени удаляет данные из буфера с соответствующим сообщением, либо поток-писатель, который в случайные моменты времени помещает данные в буфер и сообщает об этом. ";
            help += "Каждый поток-читатель завершается после удаления заданного числа данных. Каждый поток-писатель завершается после занесения заданного числа данных.";
            help += "\nОчередь - Критические секции (lock)";
            MessageBox.Show(help, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } //private void btnHelp_Click

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnPause.Text == "Continue")
                btnPause.PerformClick();
            btnStop.PerformClick();
        }
    } // public partial class frmMain
} //namespace n2_1_4p86
