using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskOne
{
    public partial class FormMain : Form
    {
        private Text text;
        private string tmp;
        public FormMain()
        {
            InitializeComponent();
            text = new Text();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 24, Size.Height - 44);
            tableLayoutPanel3.Size = new Size(Size.Width - 24, Size.Height - 44);

            tbTitle.ForeColor = Color.Gray;
            lblText.ForeColor = Color.Gray;
            tbSend.ForeColor = Color.Gray;

            tableLayoutPanel4.ColumnStyles[2].Width = 0;
            tableLayoutPanel4.ColumnStyles[1].Width = 20;
            tableLayoutPanel4.ColumnStyles[1].SizeType = SizeType.Percent;
            tableLayoutPanel4.ColumnStyles[0].Width = 100;
            tableLayoutPanel4.ColumnStyles[0].SizeType = SizeType.Percent;

            btnEdit.Enabled = false;

        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 24, Size.Height - 44);
            tableLayoutPanel2.Size = new Size(Size.Width - 24, Size.Height - 44);
            tableLayoutPanel3.Size = new Size(Size.Width - 24, Size.Height - 44);
            tableLayoutPanel4.Size = new Size(Size.Width - 24, Size.Height - 44);
            tableLayoutPanel5.Size = new Size(Size.Width - 24, Size.Height - 44);
            tableLayoutPanel6.Size = new Size(Size.Width - 24, Size.Height - 44);
            tableLayoutPanel7.Size = new Size(Size.Width - 24, Size.Height - 44);
        }

        private void tbTitle_Enter(object sender, EventArgs e)
        {
            if(tbTitle.Text.Trim() == "Заголовок")
                tbTitle.Text = "";
            tbTitle.ForeColor = Color.Black;
            if (tbSend.Text.Trim() == "")
            {
                tbSend.Text = "Введите текст...";
                tbSend.ForeColor = Color.Gray;
            }
        }

        private void tbTitle_Leave(object sender, EventArgs e)
        {
            if (tbTitle.Text.Trim() == "")
            {
                tbTitle.Text = "Заголовок";
                tbTitle.ForeColor = Color.Gray;
            }
            else
                text.Title = new Sentence(tbTitle.Text);
        }

        private void tbSend_Enter(object sender, EventArgs e)
        {
            if(tbSend.Text.Trim() == "Введите текст...")
                tbSend.Text = "";
            tbSend.ForeColor = Color.Black;
            if (tbTitle.Text.Trim() == "")
            {
                tbTitle.Text = "Заголовок";
                tbTitle.ForeColor = Color.Gray;
            }
        }

        private void tbSend_Leave(object sender, EventArgs e)
        {
            if(tbSend.Text.Trim() == "")
            {
                tbSend.Text = "Введите текст...";
                tbSend.ForeColor = Color.Gray;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (tbSend.Text == "Введите текст...")
                tbSend.Text = "";
            tbSend.Text += "\r\n";
            tbSend.Focus();
            tbSend.Select(tbSend.Text.Length, 0);
        }

        private void btnTab_Click(object sender, EventArgs e)
        {
            if (tbSend.Text == "Введите текст...")
                tbSend.Text = "";
            tbSend.Text += "\t";
            tbSend.Focus();
            tbSend.Select(tbSend.Text.Length, 0);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tableLayoutPanel4.ColumnStyles[1].Width = 0;
            tableLayoutPanel4.ColumnStyles[2].Width = 31;
            tableLayoutPanel4.ColumnStyles[2].SizeType = SizeType.Percent;
            tableLayoutPanel4.ColumnStyles[0].Width = 100;
            tableLayoutPanel4.ColumnStyles[0].SizeType = SizeType.Percent;
            tmp = tbSend.Text;
            tbSend.Text = lblText.Text;
            tbSend.ForeColor = Color.Black;
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            tbSend.Text = tmp;
            tableLayoutPanel4.ColumnStyles[2].Width = 0;
            tableLayoutPanel4.ColumnStyles[1].Width = 20;
            tableLayoutPanel4.ColumnStyles[1].SizeType = SizeType.Percent;
            tableLayoutPanel4.ColumnStyles[0].Width = 100;
            tableLayoutPanel4.ColumnStyles[0].SizeType = SizeType.Percent;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tableLayoutPanel4.ColumnStyles[2].Width = 0;
            tableLayoutPanel4.ColumnStyles[1].Width = 20;
            tableLayoutPanel4.ColumnStyles[1].SizeType = SizeType.Percent;
            tableLayoutPanel4.ColumnStyles[0].Width = 100;
            tableLayoutPanel4.ColumnStyles[0].SizeType = SizeType.Percent;
            if (tbSend.Text == "Введите текст...")
            {
                text = new Text();
                tbSend.Text = tmp;
                lblText.Text = "Текст...";
                lblText.ForeColor = Color.Gray;
                btnEdit.Enabled = false;
                return;
            }
            text = new Text(tbSend.Text);
            tbSend.Text = tmp;
            lblText.Text = text.ToString();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tbSend.Text.Trim() == "Введите текст...")
                return;
            text.Append(tbSend.Text);
            tbSend.Text = "Введите текст...";
            lblText.Text = text.ToString();
            tbSend.ForeColor = Color.Gray;
            lblText.ForeColor = Color.Black;
            btnEdit.Enabled = true;
        }

        private void tbSend_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
