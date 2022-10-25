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

namespace os2
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        
        void Secondary()
        {
            DateTime date = DateTime.Now;

            ToFind f1 = new ToFind(tbDir1.Text);

            ToFind f2 = new ToFind(tbDir2.Text);

            //первый поток ищет самый молодой из первого каталога, т.е. который создан позже всех 
            Thread search1 = new Thread(new ThreadStart(delegate() { f1.FindYungestDate(out date); }));

            //второй поток считает кол-во файлов из второго каталога, которые моложе любого из первого, т.е. который созданы позже
            Thread search2 = new Thread(new ThreadStart(delegate() { f2.countOldestFiles(date); }));

            search1.Start();
            search1.Join();
            search2.Start();
            search2.Join();
            MessageBox.Show("Количество файлов второго каталога, созданных позже, чем любой из первого: " + f2.Count);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (tbDir1.Text != "" && tbDir2.Text != "")
            {
                Thread thrd = new Thread(new ThreadStart(Secondary));
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



        private void folderBrowserDialog2_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
