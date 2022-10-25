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
    public partial class FormInput : Form
    {
        public string field { get { return textBox1.Text; } private set { } }
        string message;
        bool ok = false;
        public FormInput(string mes)
        {
            InitializeComponent();
            BackColor = Color.FromArgb(166, 4, 0);
            textBox1.BackColor = Color.FromArgb(255, 180, 115);
            ActiveControl = button1;
            button1.BackColor = Color.FromArgb(255, 118, 115);
            message = mes;
            textBox1.Text = message;
            textBox1.ForeColor = Color.Gray;
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
                textBox1.Text = message;
                textBox1.ForeColor = System.Drawing.Color.Gray;
            }
            else
                ok = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ok)
                MessageBox.Show(message, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                DialogResult = DialogResult.OK;
        }
    }
}
