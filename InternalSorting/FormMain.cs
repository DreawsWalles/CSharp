using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            MaximumSize = Size;
            MinimumSize = Size;
            Activate();
        }

        private void button_big_Click(object sender, EventArgs e)
        {
            FormBigValues form = new FormBigValues();
            if (form.DialogResult != DialogResult.Cancel)
                form.ShowDialog();
        }

        private void button_Small_Click(object sender, EventArgs e)
        {
            FormSmallValues form = new FormSmallValues();
            if (form.DialogResult != DialogResult.Cancel)
                form.ShowDialog();
        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult result = MessageBox.Show("Завершить работу программы?", "Завершение работы",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    Application.Exit();
            }
        }

        private void button_big_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button_Small_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
