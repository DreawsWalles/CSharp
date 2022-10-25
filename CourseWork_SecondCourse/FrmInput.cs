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
    public partial class FrmInput : Form
    {
        public string field { get { return textBox1.Text; } private set { } }
        string message;
        bool ok = false;
        Settings set;
        public string Title { get; set; }
        public Button BtnAccept { get; set; }
        public FrmInput(string mes)
        {
            InitializeComponent();
            set = new Settings();
            ActiveControl = button1;
            message = mes;
            textBox1.Text = message;
            textBox1.ForeColor = Color.Gray;
            BtnAccept = button1;
            Localization.LocalFrmInput(this, set.Node.IsEnglish);
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
                MessageBox.Show(message, Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                DialogResult = DialogResult.OK;
        }
    }
}
