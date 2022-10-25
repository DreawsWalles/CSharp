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
using DirectoryWork;

namespace DirectoryWork
{
    public partial class Form1 : Form
    {

        DirectoryAnalyser dir1Analyser;
        DirectoryAnalyser dir2Analyser;
        public Form1()
        {
            InitializeComponent();
            folderBrowserDialog1.SelectedPath = @"C:\labs\dir1";
            folderBrowserDialog2.SelectedPath = @"C:\labs\dir2";
        }


        private void taskInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Заданы два каталога. Проверить, есть ли в них совпадающие по названию, и вывести названия тех, в которых есть совпадения.", "Условие");
        }

        private void maketaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxInfo.Clear();
            //Если оба диалога завершили корректно
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK &&
                folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                string dir1, dir2;
                dir1 = folderBrowserDialog1.SelectedPath;
                dir2 = folderBrowserDialog2.SelectedPath;
                textBoxInfo.Text += "1-я директория: " + dir1 + "\r\n" + "2-я директория: " + dir2 + "\r\n" + "------------------------" + "\r\n";
                Thread datFilesThread = new Thread(new ThreadStart(new Action(() =>
                textBoxInfo.Invoke(new Action(() =>
                textBoxInfo.AppendText(Analysis(dir1, dir2)))))));
                datFilesThread.Start();
            }

        }
        public string Analysis(string dir1, string dir2)
        {
            if (dir1 == dir2)
                return "Передано две одинаковых директории";


            //List<string> dir1List = DirectoryMethods.GetAllDirectoriesNames(dir1).ToList();
            //List<string> dir2List = DirectoryMethods.GetAllDirectoriesNames(dir2).ToList();
            dir1Analyser = new DirectoryAnalyser(dir1);
            dir2Analyser = new DirectoryAnalyser(dir2);

            dir1Analyser.LoadDirectoriesAsync();
            dir2Analyser.LoadDirectoriesAsync();



            //Список директорий для сравнения
            List<string> comparingDirectories = new List<string>();


            foreach (string dirname in dir1Analyser.dirList)
            {
                comparingDirectories.AddRange(dir2Analyser.dirList.FindAll(x => x == dirname));
            }

            if (comparingDirectories.Count == 0)
                return "Нет каталогов с одинаковыми именами.";
            else
            {
                string result = "Каталоги с одинаковыми именами: \r\n";

                foreach (string comparename in comparingDirectories)
                    result += comparename + "\r\n";
                return result;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dir1Analyser.Stop();
            dir2Analyser.Stop();
        }
    }
}
