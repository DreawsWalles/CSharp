using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace task
{
    public partial class MainForm : Form
    {
        RsdnDirectory rsdn;

        string path1, path2;        
        List<string> allDirectories1, allDirectories2, unique;
        bool wasLaunch;

        public MainForm()
        {
            InitializeComponent();
            
            rsdn = new RsdnDirectory();
            path1 = "";
            path2 = "";
            wasLaunch = false;
        }
        
        private void FileSearchFunction(string Dir)
        {
            System.IO.DirectoryInfo DI = new System.IO.DirectoryInfo(Dir);
            System.IO.DirectoryInfo[] SubDir = DI.GetDirectories();
            for (int i = 0; i < SubDir.Length; ++i)
                this.FileSearchFunction(SubDir[i].FullName);
            System.IO.FileInfo[] FI = DI.GetFiles();
            for (int i = 0; i < FI.Length; ++i)
                label1.Text = FI[i].FullName;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (path1 == "" || path2 == "")
                MessageBox.Show("Не все директории поиска указаны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (!wasLaunch)
                {                    
                    wasLaunch = true;
                }
                else
                {
                    lblAllDirectories1.Text = lblAllDirectories1.Text.Substring(0, lblAllDirectories1.Text.IndexOf(':') + 2);

                    lblAllDirectories2.Text = lblAllDirectories2.Text.Substring(0, lblAllDirectories2.Text.IndexOf(':') + 2);

                    lblUnique.Text = lblUnique.Text.Substring(0, lblUnique.Text.IndexOf(':') + 2);
                }

                Thread generalThread = new Thread(new ThreadStart(MainTask));
                generalThread.Start();
            }
        }      

        void MainTask()
        {
            unique = RsdnDirectory.FindUniqDirectories(path1, path2, out allDirectories1, out allDirectories2);

            tbDirectories1.Invoke(new Action(() => tbDirectories1.Lines = allDirectories1.ToArray()));
            lblAllDirectories1.Invoke(new Action(() => lblAllDirectories1.Text += tbDirectories1.Lines.Count()));

            tbDirectories2.Invoke(new Action(() => tbDirectories2.Lines = allDirectories2.ToArray()));
            lblAllDirectories2.Invoke(new Action(() => lblAllDirectories2.Text += tbDirectories2.Lines.Count()));

            if (unique.Count == 0)
                MessageBox.Show("Уникальных директорий нет", "Задание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                tbUnique.Invoke(new Action(() => tbUnique.Lines = unique.ToArray()));
                lblUnique.Invoke(new Action(() => lblUnique.Text += tbUnique.Lines.Count()));
            }
        } 

        private void btnBrowserFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                path1 = tbPath1.Text = FBD.SelectedPath + @"\";
            }
        }

        private void btnBrowserFolder2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                path2 = tbPath2.Text = FBD.SelectedPath + @"\";
            }
        }
    }
}
