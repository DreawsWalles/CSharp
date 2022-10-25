using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskThree
{
    public partial class FormInitAlphabet : Form
    {
        private bool isEdit = false;
        public List<string> Alphabet { get; set; }
        public FormInitAlphabet()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void FormInitAlphabet_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 34, Size.Height - 40);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel3.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);

            tableLayoutPanel1.RowStyles[1].Height = 100;
            tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Percent;
            tableLayoutPanel1.RowStyles[2].Height = 0;

            btnAccept.Enabled = false;
        }

        private void FormInitAlphabet_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel1.Size = new Size(Size.Width - 34, Size.Height - 40);
            tableLayoutPanel2.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel3.Size = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Alphabet = new List<string>();
            foreach(string node in comboBox1.Items)
                Alphabet.Add(node);
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            tableLayoutPanel1.RowStyles[2].Height = 100;
            tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Percent;
            textBox1.Focus();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(isEdit)
            {
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                comboBox1.Text = "";
                btnAccept.Enabled = comboBox1.Items.Count > 0 ? true : false;
            }
            tableLayoutPanel1.RowStyles[1].Height = 100;
            tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Percent;
            tableLayoutPanel1.RowStyles[2].Height = 0;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Contains(textBox1.Text))
            {
                MessageBox.Show("Такой элемент уже присутсвует в алфавите", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tableLayoutPanel1.RowStyles[1].Height = 100;
            tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Percent;
            tableLayoutPanel1.RowStyles[2].Height = 0;
            if (!isEdit)
            {
                comboBox1.Items.Insert(0, textBox1.Text);
                comboBox1.SelectedIndex = 0;
            }
            else
                comboBox1.Items[comboBox1.SelectedIndex] = textBox1.Text;
            btnAccept.Enabled = true;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            isEdit = true;
            textBox1.Text = (string)comboBox1.Items[comboBox1.SelectedIndex];
            tableLayoutPanel1.RowStyles[2].Height = 100;
            tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Percent;
            textBox1.Focus();
        }
    }
}
