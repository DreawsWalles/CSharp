using System;
using System.Threading;
using System.Windows.Forms;

namespace OS_task2_number14
{
    /* Заданы два каталога. В каждом из них поменять атрибут у файлов, имеющих атрибут faReadonly, на faHidden. */

    public partial class FormMain : Form
    {
        private string _firstDir, _secondDir;
        private Founder _founderFirst, _founderSecond;
        private Thread _mainThread;

        public FormMain()
        {
            InitializeComponent();
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (tbFirstDir.Text != "" && tbSecondDir.Text != "")
            {
                _mainThread = new Thread(Solve);
                _mainThread.Start();
                Thread.Sleep(250);
            }
            else
                MessageBox.Show(@"Пожалуйста, выберите два каталога для работы с файлами.");
        }

        private void Solve()
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
