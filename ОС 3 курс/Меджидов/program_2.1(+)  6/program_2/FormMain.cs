using System;
using System.Windows.Forms;
using System.Threading;

namespace program_2
{
    public partial class FormMain : Form
    {
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

        // Проверка наличия файлов во втором каталоге, созданные позже, чем любой из первого
        private void BttStart_Click(object sender, EventArgs e)
        {
            FormResult form2 = new FormResult();
            CompareCreationTime finder = new CompareCreationTime(new FileFinder(TbDirectory1.Text), new FileFinder(TbDirectory2.Text), form2.TbOutput);
            finder.Find();
            if (form2.TbOutput.Text.Equals("")) // не найдено
                MessageBox.Show("Во втором каталоге нет ни одного файла, младше хотя бы одного из первого.", "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                form2.ShowDialog();
        }
    }
}
