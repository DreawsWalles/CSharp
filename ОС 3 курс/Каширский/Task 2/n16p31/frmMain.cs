using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace n16p31 {
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
        } //public frmMain()

        void Secondary () {
            Founder f1 = new Founder(txt1stDirectory.Text, dtpDate.Value);
            Founder f2 = new Founder(txt2ndDirectory.Text, dtpDate.Value);

            Thread search1 = new Thread(new ThreadStart(f1.cntYoungFiles));
            Thread search2 = new Thread(new ThreadStart(f2.cntYoungFiles));
            search1.Start();
            search2.Start();
            search1.Join();
            search2.Join();

            int cnt = f1.getCnt();
            int cnt2 = f2.getCnt();

            string msg = "В первой папке - " + cnt + ", во второй папке - " + cnt2 + ".\n";
            if (cnt > cnt2)
                msg += "В первой папке находится больше файлов, удовлетворяющих условию.";
            else 
                if (cnt == cnt2)
                    msg += "В обеих папках находится одинаковое количество файлов, удовлетворяющих условию.";
                else
                    msg += "Во второй папке находится больше файлов, удовлетворяющих условию.";
            MessageBox.Show(msg, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } //void Secondary

        private void btn1stDirectory_Click (object sender, EventArgs e) {
            if (fldDlg1stdir.ShowDialog() == DialogResult.OK)
                txt1stDirectory.Text = fldDlg1stdir.SelectedPath;
        } //private void btn1stDirectory_Click

        private void btn2ndDirectory_Click (object sender, EventArgs e) {
            if (fldDlg2nddir.ShowDialog() == DialogResult.OK)
                txt2ndDirectory.Text = fldDlg2nddir.SelectedPath;
        } //private void btn2ndDirectory_Click

        private void btnRun_Click (object sender, EventArgs e) {
            if (txt1stDirectory.Text != "" && txt2ndDirectory.Text != "" && txt1stDirectory.Text != txt2ndDirectory.Text) {
                Thread thrd = new Thread(new ThreadStart(Secondary));
                thrd.Name = "Secondary";
                thrd.Start();
            }
            else {
                string msg = "Указанны некорректные директории";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } //private void btnRun_Click

        private void btnHelp_Click (object sender, EventArgs e) {
            string help = "Заданы два каталога. Для каждого из них найти файлы, у которых дата модификации позже заданной даты. Сравнить их количество.";
            MessageBox.Show(help, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } //private void btnHelp_Click
    } //public partial class frmMain
} //namespace n16p31
