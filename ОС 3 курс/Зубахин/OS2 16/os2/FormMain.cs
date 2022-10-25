using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Task2
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        
        void Solver_fn()
        {
            Solver f1 = new Solver(tbDir1.Text, dateTimePicker.Value);
            Solver f2 = new Solver(tbDir2.Text, dateTimePicker.Value);
            Thread search1 = new Thread(new ThreadStart(f1.numberOfOldFiles));
            Thread search2 = new Thread(new ThreadStart(f2.numberOfOldFiles));
            search1.Start();
            search2.Start();
            search1.Join();
            search2.Join();
            MessageBox.Show("В первой папке: " + (f1.getCount() - 2) + ", во второй папке: " + (f2.getCount() - 2));
        }
        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (tbDir1.Text != "" && tbDir2.Text != "")
            {
                Thread thrd = new Thread(new ThreadStart(Solver_fn));
                thrd.Name = "Secondary";  
                thrd.Start();
            }
        }

        private void bBrowse1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbDir1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void bBrowse2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                tbDir2.Text = folderBrowserDialog2.SelectedPath;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Заданы два каталога. Для каждого из них найти файлы, у которых дата модификации позже заданной даты.", "Task");
        }
    }
}
