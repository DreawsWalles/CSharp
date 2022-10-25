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

namespace n2
{
    public partial class MainForm : Form
    {
        string dir1, dir2;
        int directory1_cnt = 0,
            directory2_cnt = 0;
        int num = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ResultBox.Clear();
            num = Convert.ToInt32(FileNum.Value);
            if (FBrDlg1.ShowDialog() == DialogResult.OK && FBrDlg2.ShowDialog() == DialogResult.OK)
            {
                
                dir1 = FBrDlg1.SelectedPath;
                dir2 = FBrDlg2.SelectedPath;
                FDirTextBox.Text = dir1;
                SDirTextBox.Text = dir2;
                if (dir1 == dir2)
                {
                    ResultBox.Text += "Указанные директории совпадают\r\n";
                    return;
                }
                Thread count_dirs_thread = new Thread(new ThreadStart(new Action(() => ResultBox.Invoke(new Action(() => ResultBox.AppendText(GetDirs()))))));
                count_dirs_thread.Start();
                count_dirs_thread.Join(1000);
            }
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Заданы два каталога. Для каждого из них подсчитать количество каталогов, содержащих более чем m файлов. Сравнить их количество.", "Условие", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public void GetDirs2()
        {
            foreach (string dir in RsdnDirectory.GetAllDirectories(dir2))
            {
                if (RsdnDirectory.GetCountAll(dir) > num)
                    directory2_cnt += 1;
            }
        }
        public void GetDirs1()
        {
            foreach (string dir in RsdnDirectory.GetAllDirectories(dir1))
            {
                if (RsdnDirectory.GetCountAll(dir) > num)
                    directory1_cnt += 1;
            }
        }

        private string GetDirs()
        {
            string result = "";
            directory1_cnt = 0;
            directory2_cnt = 0;

            Thread th1 = new Thread(new ThreadStart(GetDirs1));
            Thread th2 = new Thread(new ThreadStart(GetDirs2));
            th1.Start();
            th2.Start();
            th1.Join();
            th2.Join();
                if (directory1_cnt > directory2_cnt)
                    return result += "Каталогов в директории 1 больше, чем в директории 2\r\n(" + directory1_cnt.ToString() + " > " + directory2_cnt.ToString() + ")\r\n";
                else if (directory1_cnt < directory2_cnt)
                    return result += "Каталогов в директории 1 меньше, чем в директории 2\r\n(" + directory1_cnt.ToString() + " < " + directory2_cnt.ToString() + ")\r\n";
                else
                    return result += "Количество каталогов в обеих директориях равно\r\n(" + directory1_cnt.ToString() + " = " + directory2_cnt.ToString() + ")\r\n";
        }
    }
}
