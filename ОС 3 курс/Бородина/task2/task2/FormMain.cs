using System;
using System.Threading;
using System.Windows.Forms;

namespace task2
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        void Secondary()
        {
            int cnt1 = 0;
            int cnt2 = 0;
            Founder f1 = new Founder(tbDir1.Text);
            Founder f2 = new Founder(tbDir2.Text);
            Thread search1 = new Thread(new ThreadStart(delegate () { f1.CountSameDates(out cnt1); }));
            Thread search2 = new Thread(new ThreadStart(delegate () { f2.CountSameDates(out cnt2); }));
            search1.Start();
            search1.Join();
            search2.Start();
            search2.Join();
            if (cnt1 > cnt2)
                MessageBox.Show("Количество файлов первого каталога, у которых время создания и время последнего доступа(" + cnt1 + ") >, чем количество файлов второго каталога(" + cnt2 + ")");
            if (cnt1 < cnt2)
                MessageBox.Show("Количество файлов первого каталога, у которых время создания и время последнего доступа(" + cnt1 + ") <, чем количество файлов второго каталога(" + cnt2 + ")");
            if (cnt1 == cnt2)
                MessageBox.Show("Количество файлов первого каталога, у которых время создания и время последнего доступа(" + cnt1 + ") =, количеству файлов второго каталога(" + cnt2 + ")");
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

        private void buttonGO_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(new ThreadStart(Secondary));
            thrd.Name = "Secondary";
            thrd.Start();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
