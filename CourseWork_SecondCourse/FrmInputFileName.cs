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
    public partial class FrmInputFileName : Form
    {
        public string fileName { get { return textBox1.Text; } private set { } }
        private bool ok = false;
        public FrmInputFileName()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(166, 4, 0);
            textBox1.BackColor = Color.FromArgb(255, 180, 115);
            Okey.BackColor = Color.FromArgb(255, 118, 115);
            Cansel.BackColor = Color.FromArgb(255, 118, 115);
            textBox1.Text = "Введите название файла";
            textBox1.ForeColor = System.Drawing.Color.Gray;
            ActiveControl = Okey;
        }

        private void Okey_MouseEnter(object sender, EventArgs e)
        {
            Okey.BackColor = Color.FromArgb(0, 201, 13);
        }

        private void Okey_MouseLeave(object sender, EventArgs e)
        {
            Okey.BackColor = Color.FromArgb(255, 118, 115);
        }

        private void Cansel_MouseEnter(object sender, EventArgs e)
        {
            Cansel.BackColor = Color.FromArgb(255, 69, 64);
        }

        private void Cansel_MouseLeave(object sender, EventArgs e)
        {
            Cansel.BackColor = Color.FromArgb(255, 118, 115);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0)
            {
                textBox1.Text = "Введите название файла";
                textBox1.ForeColor = System.Drawing.Color.Gray;
                ok = false;
            }
            else
                ok = true;
        }

        private void Cansel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool check(string name)
        {
            int size = name.Length;
            int i = 0;
            while (i < size)
            {
                if ((name[i] == '/') || (name[i] == '\\') || (name[i] == ':') || (name[i] == '*') || (name[i] == '?') || (name[i] == '«') || (name[i] == '<') || (name[i] == '>') || (name[i] == '|'))
                {
                    string message = "Введен некорректный символ " + name[i];
                    MessageBox.Show(message, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                i++;
            }
            return true;
        }

        private void Okey_Click(object sender, EventArgs e)
        {
            if (!ok)
                MessageBox.Show("Введите имя файла", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (check(textBox1.Text) && fileName != "1.txt" && fileName != "2.txt" && fileName != "" && fileName != "3.txt" && fileName != "4.txt")
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            
        }
    }
}
