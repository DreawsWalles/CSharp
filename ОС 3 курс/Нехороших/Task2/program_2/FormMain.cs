using System;
using System.Windows.Forms;
using System.Threading;

namespace program_2
{
    public partial class FormMain : Form
    {
        Thread main;
        public FormMain()
        {
            InitializeComponent();
        }

        // Выбор первого каталога
        private void BttDirectory1_Click(object sender, EventArgs e)
        {
            DialogResult result = Fbd1.ShowDialog();
            if (result == DialogResult.OK)
                TbDirectory1.Text = Fbd1.SelectedPath;
        }

        // Выбор второго каталога
        private void BttDirectory2_Click(object sender, EventArgs e)
        {
            DialogResult result = Fbd2.ShowDialog();
            if (result == DialogResult.OK)
                TbDirectory2.Text = Fbd2.SelectedPath;
        }

        private void BttStart_Click(object sender, EventArgs e)
        {
            res1.Clear();
            res2.Clear();
            Analyzer a = new Analyzer(TbDirectory1.Text, TbDirectory2.Text);
            a.ShowROCountInDir1 += res1.AppendText;
            a.ShowROCountInDir2 += res2.AppendText;
            main = new Thread(new ThreadStart(new Action(() => { a.Solution(); })));
            BttStart.Enabled = false;
            main.Start();
            main.Join();
            BttStart.Enabled = true;

        }
    }
}
